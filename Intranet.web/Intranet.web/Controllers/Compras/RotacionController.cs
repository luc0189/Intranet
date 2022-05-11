using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.Compras
{
    public class RotacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Out_focus(string fechai,string fechaf,string proveedor)
        {
            ProductSearchResult productSearchResult = new ProductSearchResult();

            using (SqlConnection connection = new SqlConnection("Server=192.168.1.113,7433;Database=supermio;Persist Security Info=True;User Id=l.sanchez;Password=Team0103"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"SET NOCOUNT ON; " +
					$" declare @fecha1 as date = '{fechai}'" +
					$" ,@fecha2 as date = '{fechaf}' " +
					$"select" +
					$"			fin.articuloID," +
					$"			fin.Articulo," +
					$"			 CantidadInicial," +
					$"			format(round(CantidadInicial * costoPromedio, 2), '$ ###.###,##') as CostoInicial," +
					$"			fin.cantventa," +
					$"			fin.PromedioCantidadVentaDia," +
					$"			fin.saldocant," +
					$"			format(round(fin.saldocant * fin.costoPromedio, 2), '$ ###.###,##') as CostoFinal," +
					$"					(fin.saldocant / fin.PromedioCantidadVentaDia) DiasInventario" +
					$"					,FechaUltimoTraslado" +
					$"					,FechaUltimaCompra," +
					$"			fin.[Nombre Bodega]," +
					$"			fin.Marca," +
					$"			fin.Grupo," +
					$"			fin.Linea," +
					$"			fin.nombre as Proveedor," +
					$"			fin.costoPromedio," +
					$"			fin.proveedorID" +
					$" from(" +
					$"	SELECT  t.articuloID," +
					$"			a.detalle[Articulo]," +
					$"			t.cantventa," +
					$"			t.cantventa / DATEDIFF(dd, @fecha1, @fecha2) as PromedioCantidadVentaDia," +
					$"			t.saldocant," +
					$"			t.saldocosto," +
					$"			b.nombre[Nombre Bodega]," +
					$"			ma.nombre[Marca]," +
					$"			gr.nombre[Grupo]," +
					$"			ln.nombre[Linea]," +
					
					$"			lc.proveedorID," +
					$"			ter.nombre," +
					$"			lc.fechadesde," +
					$"			CantidadInicial," +
					$"			UltimoTraslado.FechaUltimoTraslado," +
					$"			UltimaCompra.FechaUltimaCompra," +
					$"			costoPromedio" +
					$"	FROM(" +
					$"		SELECT COALESCE(venta.articuloID, s.articuloID) articuloID," +
					$"			COALESCE(venta.bodegaID, s.bodegaID) bodegaID," +
					$"			venta.cantventa," +
					$"			s.saldocant," +
					$"			venta.vrtotal," +
					$"			s.saldocosto," +
					$"			costoPromedio" +
					$"		FROM(" +
					$"				SELECT itventa.articuloID," +
					$"						itventa.bodegaID," +
					$"						SUM(itventa.vrtotal) vrtotal," +
					$"						SUM(itventa.cantidad) cantventa" +
					$"				FROM dbo.itart itventa INNER JOIN dbo.documento venta ON itventa.documentID = venta.id" +
					$"						INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
					$"				WHERE venta.fecha BETWEEN @fecha1 AND @fecha2" +
					$"						AND venta.anulado = 0" +
					$"						AND td.clasedoc IN('FV', 'FP', 'DV', 'DP')" +
					$"				GROUP BY itventa.articuloID" +
					$"						, itventa.bodegaID" +
					$"			) venta FULL JOIN" +
					$"				(SELECT articuloID" +
					$"						, bodegaID" +
					$"						, saldocant" +
					$"						, saldocosto" +
					$"						, fn.costoPromedio" +
					$"				FROM dbo.fnInventInventariosBaseRotacion(@fecha1, @fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) fn" +
					$"				) s ON venta.articuloID = s.articuloID AND venta.bodegaID = s.bodegaID" +
					$"		) t" +
					$"			OUTER APPLY(" +
					$"			select top 1 d.fecha as FechaUltimoTraslado" +
					$"			from dbo.documento d inner" +
					$"			join itart it on it.documentID = d.id inner" +
					$"			join tipodoc td on td.codigo = d.tipo" +
					$"			where td.clasedoc = 'NT'" +
					$"					and it.articuloID = t.articuloID" +
					$"					and it.bodegaID = t.bodegaID" +
					$"					and d.fecha <= @fecha2" +
					$"					order by d.fecha desc" +
					$"				)UltimoTraslado" +
					$"			OUTER APPLY(" +
					$"			select top 1 d.fecha as FechaUltimaCompra" +
					$"			from dbo.documento d inner" +
					$"			join itart it on it.documentID = d.id inner" +
					$"			join tipodoc td on td.codigo = d.tipo" +
					$"			where td.clasedoc = 'FC'" +
					$"					and it.articuloID = t.articuloID" +
					$"					and it.bodegaID = t.bodegaID" +
					$"					and d.fecha <= @fecha2" +
					$"					order by d.fecha desc" +
					$"				)UltimaCompra" +
					$"			inner join dbo.bodega b on b.codigo = t.bodegaID" +
					$"			inner join articulo a on t.articuloID = a.codigo" +
					$"			inner join dbo.grupo as gr on a.grupoID = gr.codigo" +
					$"			inner join dbo.linea as ln on a.lineaID = ln.codigo" +
					$"			inner join dbo.marca as ma on a.marcaID = ma.codigo" +
					$"			left join(select SUM(it.cantidad) as CantidadInicial" +
					$"							  ,it.articuloID" +
					$"							  ,it.bodegaID" +
					$"					   FROM dbo.itinvent it" +
					$"								INNER JOIN dbo.documento venta ON it.documentID = venta.id" +
					$"								INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
					$"							WHERE venta.fecha < @fecha1" +
					$"								AND venta.anulado = 0" +
					$"								GROUP BY" +
					$"								it.articuloID,it.bodegaID" +
					$"						)salini on salini.articuloID = t.articuloID and t.bodegaID = salini.bodegaID" +
					$"			LEFT JOIN(SELECT t.articuloID, t.proveedorID, t.fechadesde" +
					$"						FROM (" +
					$"							SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
					$"							articuloID, " +
					$"							proveedorID," +
					$"							fechadesde" +
					$"							from arthistocompra lc" +
					$"							WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta) T" +
					$"						  where T.rnum = 1 ) lc ON lc.articuloID = t.articuloID" +
					$"			left join dbo.tercero as ter on ter.id = lc.proveedorID" +
					$"			where a.inactivo = 0" +
					$"			)fin where fin.proveedorID = '{proveedor}'";

				command.CommandType = System.Data.CommandType.Text;

                connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				DataTable schemaTable = reader.GetSchemaTable();
				
				{
					if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            productSearchResult.Codigo = reader[0].ToString();
                            productSearchResult.Nombre = reader[1].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("articulo no Existe");
                    }
                    reader.Close();
                }
            }
            return Ok(productSearchResult.Nombre);

        }
    }
}
