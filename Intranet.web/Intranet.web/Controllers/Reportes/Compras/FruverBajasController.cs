using Intranet.web.Models.Report.Compras;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers
{
    public class FruverBajasController : Controller
    {
        public IActionResult Index()
        {
            BajasFruverViewModel listadobajas = new BajasFruverViewModel();

            using (SqlConnection connection = new SqlConnection("Server=192.168.1.113,7433;Database=supermio;Persist Security Info=True;User Id=l.sanchez;Password=Team0103"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select codigo, detalle from articulo where codigo='23183'";
                command.CommandType = System.Data.CommandType.Text;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listadobajas.Codigo = Convert.ToInt32(reader[0].ToString());
                            listadobajas.Nombre = reader[1].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("articulo no Existe");
                    }
                    reader.Close();
                }
            }
            return View(listadobajas);
        }

        public IActionResult Out_focus(string plu)
        {
           BajasFruverViewModel  listadobajas = new BajasFruverViewModel();

            using (SqlConnection connection = new SqlConnection("Server=192.168.1.113,7433;Database=supermio;Persist Security Info=True;User Id=l.sanchez;Password=Team0103"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select codigo, detalle from articulo where codigo='23183'";
                command.CommandType = System.Data.CommandType.Text;

                connection.Open();
              
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listadobajas.Codigo = Convert.ToInt32( reader[0].ToString());
                            listadobajas.Nombre = reader[1].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("articulo no Existe");
                    }
                    reader.Close();
                }
            }
            //return Ok(listadobajas);
            return View(listadobajas);
        }
    }
}
