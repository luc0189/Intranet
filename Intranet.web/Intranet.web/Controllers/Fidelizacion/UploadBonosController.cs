using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Intranet.web.Data;
using Intranet.web.Data.Entities.Fidelizacion;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Controllers.Fidelizacion
{
    public class UploadBonosController : Controller

   
    {
        private readonly DataContext _dataContext;
        public UploadBonosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public IActionResult Index(List<Bono> bonos = null)
        {
            bonos = bonos == null ? new List<Bono>() : bonos;

            return View(bonos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (file == null)
            {
                ViewBag.Message = $"Seleccione un Documento de Excel";
            }
            try
            {
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                var Employes = await this.GetBonoList(file.FileName);
                return Index();
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message}";
                return View();
            }

        }


        private async Task<Bono> GetBonoList(string fName)
        {
            Bono bono = new Bono();
            int contadorSave = 0;
            int contadorUpdate = 0;
            try
            {

                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {

                        _dataContext.ChangeTracker.AutoDetectChangesEnabled = false;
                        while (reader.Read())
                        {

                           
                            string codigo = reader.GetValue(0).ToString();
                            string actividad = reader.GetValue(1).ToString();
                            int valor = Convert.ToInt32(reader.GetValue(2).ToString());
                            
                            var exits = await _dataContext.Bonos.FirstOrDefaultAsync(s => s.Codigo == codigo);

                            if (exits == null)
                            {
                                _dataContext.Bonos.Add(new Bono()
                                {
                                    Codigo = codigo,
                                    Actividad = actividad,
                                    Redimido = false,
                                    Valor = valor,
                                    Fechacreado = DateTime.Now.ToString(),
                                    Usuariocrea = User.Identity.Name,
                                    

                                    //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                                })
                                ; contadorSave++;
                                await _dataContext.SaveChangesAsync();

                            }
                            else
                            {
                                //exits.NOrden = $"{exits.NOrden}, {nOder}";
                                //exits.Document = exits.Document;
                                //exits.sedes2 = $"{exits.sedes2},{sede}";
                                //exits.Sedes = await _dataContext.Sedes.FirstAsync(o => o.NameSedes == sede);
                                //exits.FullName = exits.FullName;
                                //exits.AcudienteName = exits.AcudienteName;
                                //exits.DocumentAcu = exits.DocumentAcu;
                                //exits.FechaActualización = DateTime.Now;
                                //exits.AutDelivery = $"{exits.AutDelivery}, {autorized}";
                                //exits.Mesas = $"{exits.Mesas}, {mesa}";
                                //exits.Jornada = exits.Jornada;
                                contadorUpdate++;

                            }



                        }
                        //_dataContext.ChangeTracker.AutoDetectChangesEnabled = true;
                        //_dataContext.ChangeTracker.DetectChanges();

                        // await _dataContext.SaveChangesAsync();
                        ViewBag.Success = $"Se Encontraron {reader.RowCount} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";
                    }
                }

                return bono;
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException} ITEM ERROR: {contadorSave} - {contadorUpdate}";

            }

            return bono;

        }



    }
}
