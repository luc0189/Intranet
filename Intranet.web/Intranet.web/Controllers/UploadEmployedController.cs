using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Controllers
{
    public class UploadEmployedController : Controller
    {
        private readonly DataContext _dataContext;
        public UploadEmployedController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       

        [HttpGet]
        public IActionResult Index(List<Employee> employees = null)
        {
            employees = employees == null ? new List<Employee>() : employees;

            return View(employees);
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
                var Employes = await this.GetEmployeList(file.FileName);
                return Index();
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message}";
                return View();
            }

        }


        private async Task<Employee> GetEmployeList(string fName)
        {
            Employee employes = new Employee();
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
                           
                            int documento = Convert.ToInt32(reader.GetValue(0).ToString());
                            string siteExpedition = reader.GetValue(1).ToString();
                            string firstName = reader.GetValue(2).ToString();
                            string lastname = reader.GetValue(3).ToString();
                            string jobTitle = reader.GetValue(4).ToString();
                            string email = reader.GetValue(5).ToString();
                            string nivelEducation = reader.GetValue(6).ToString();
                            string siteBirth = reader.GetValue(7).ToString();
                            string address = reader.GetValue(8).ToString();
                            string rh = reader.GetValue(9).ToString();
                            string movil = reader.GetValue(10).ToString();
                            bool arl = true;
                            bool activo =true;
                            string dateCumple = reader.GetValue(11).ToString();
                            string dateIngreso = reader.GetValue(12).ToString();
                            string areaId = reader.GetValue(13).ToString();
                            string epsId = reader.GetValue(14).ToString();
                            string pensionId = reader.GetValue(15).ToString();
                            string cajaCompenId = reader.GetValue(16).ToString();
                            string positionEmpId = reader.GetValue(17).ToString();
                           
                            var exits = await _dataContext.Employees.FirstOrDefaultAsync(s => s.Document == documento);

                            if (exits == null)
                            {
                                _dataContext.Employees.Add(new Employee()
                                {
                                    Document = documento,
                                    SiteExpedition  = siteExpedition,
                                    FirstName = firstName,
                                    LastName = lastname,
                                    JobTitle = jobTitle,
                                    Email = email,
                                    NivelEducation = nivelEducation,
                                    SiteBirth = siteBirth,
                                    Address = address,
                                    Rh = rh,
                                    Movil = movil,
                                    Arl = arl,
                                    Activo = activo,
                                    DateCumple = dateCumple,
                                    DateRegistro = DateTime.Now,
                                    DateIngreso = dateIngreso,
                                    UserRegistra = User.Identity.Name,
                                    Area = await _dataContext.Areas.FirstAsync(o => o.Nombre == areaId),
                                    Eps = await _dataContext.Eps.FirstAsync(o => o.Nombre == epsId),
                                    Pension = await _dataContext.Pensions.FirstAsync(o => o.Nombre == pensionId),
                                    CajaCompensacion = await _dataContext.CajaCompensacions.FirstAsync(o => o.Nombre == cajaCompenId),
                                    PositionEmployee = await _dataContext.PositionEmployees.FirstAsync(o => o.Position == positionEmpId)
                                    //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                                }); contadorSave++;
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

                return employes;
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException} ITEM ERROR: {contadorSave} - {contadorUpdate}";

            }

            return employes;

        }
    }
}
