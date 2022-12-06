using Intranet.web.Data.Entities;
using Intranet.web.Data.Entities.Activos;
using Intranet.web.Data.Entities.Compras;
using Intranet.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            //await ChekPositionAsyn();
            await ChekSiteAsyn();
            await ChekAreaAsyn();
            await ChekExamTypeAsyn();
            await ChekEndowmentTypeAsyn();
            await ChekEpsAsyn();
            await ChekPensionAsyn();
            await ChekCajaCompAsyn();
            await ChekCategoryAsyn();
            await ChekFabricAsyn();
            await ChekModelAsyn();
            await ChekProviderAsyn(); 
            await ChekMesAsyn();
          
            var manager = await CheckUserAsync(1117498993, "Luis Carlos", "Sanchez Cabrera","luc0189@gmail.com",
                                                "Calle Luna Calle Sol","3107957939", "Manager",true);
                  
            await CheckManagerAsync(manager);
          
         
           
        }

        private async Task ChekEndowmentTypeAsyn()
        {
            if (!_context.EndowmentsTypes.Any())
            {

                _context.EndowmentsTypes.Add(new EndowmentType
                {

                    NameType = "Pantalones",
                    DateRegistro=DateTime.Now,
                    UserRegistra="System",
                    EspirationDate= 6
                    

                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task  ChekExamTypeAsyn()
        {
            if (!_context.ExamsTypes.Any())
            {

                _context.ExamsTypes.Add(new ExamsType
                {

                    Name = "Manipulacion De Alimentos",
                    
                });

                await _context.SaveChangesAsync();
            }
        }



        //private async Task ChekPositionAsyn()
        //{
        //    if (!_context.PositionEmp.Any())
        //    {
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "ADMINISTRADOR"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "APRENDIZ SENA"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "PROCESOS INFORMATICOS Y DE SISTEMAS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILAR DE SEGURIDAD"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR  DE RECURSOS HUMANOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR ADMINISTRATIVO"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE BODEGA Y SURTIDO"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE CARNES"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE COMPRAS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE CONTABILIDAD"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE FRUVER"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE MANTENIMIENTO"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE PUBLICIDAD Y PRECIOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE REGISTRO"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE SERVICIOS GENERALES"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "AUXILIAR DE SISTEMAS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "CONTADOR"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "COORDINADOR DE INVENTARIOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "DIRECTORA COMERCIAL"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "INGENIERA DE ALIMENTOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "JEFE DE RECURSOS HUMANOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "LIDER BODEGA"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "LIDER DE CARNICOS"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "LIDER DE FRUVER"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "LIDER DE SALA DE VENTA"
        //        });
        //        _context.PositionEmp.Add(new PositionEmp
        //        {

        //            Position = "LIDER DE CARNICOS"
        //        });

        //        await _context.SaveChangesAsync();
        //    }
        //}
        private async Task ChekSiteAsyn()
        {
            if (!_context.SiteHeadquarters.Any())
            {
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "ADMINISTRACION"
                });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "SUPERMIO LA 16"
                });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "SUPERMIO LA 13"
                });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "SUPERMIO VERSALLES"
                });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "SUPERMIO CIUDADELA"
                });
               _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "BODEGA"
               });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "MANTENIMIENTO"
                });
                _context.SiteHeadquarters.Add(new SiteHeadquarters
                {
                    
                    Nombre = "SERVICIOS"
                });
               

                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekAreaAsyn()
        {
            if (!_context.Areas.Any())
            {
                
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "SISTEMAS",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "ADMINISTRACION")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "OFICINA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "ADMINISTRACION")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "ADMINISTRACION",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "TESORERIA LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "SURTIDO LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "FRUVER LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "VIGILANCIA LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "CARNICOS LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "PUBLICIDAD LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "REGISTRO LA 13",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 13")
                });  
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "ADMINISTRACION VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                });
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "SURTIDO VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                });
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "TESORERIA VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                }); 
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "FRUVER VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                });
                _context.Areas.Add(new Area
                {
                   
                    Nombre = "VIGILANCIA VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "CARNICOS VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                }); 
                   _context.Areas.Add(new Area
                {
                   
                    Nombre = "REGISTRO VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                }); 
                   _context.Areas.Add(new Area
                {
                   
                    Nombre = "BODEGA VERSALLES",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO VERSALLES")
                }); 
                   _context.Areas.Add(new Area
                {
                   
                    Nombre = "ADMINISTRACION CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "SURTIDO CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "CARNICOS CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "REGISTRO CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "FRUVER CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "VIGILANCIA CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "BODEGA CIUDADELA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO CIUDADELA")
                }); 
                
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "OFICINA",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SERVICIOS")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "SISTEMAS",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SERVICIOS")
                }); 
                 _context.Areas.Add(new Area
                {
                   
                    Nombre = "MAESTRO",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "MANTENIMIENTO")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "CENDIS",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "BODEGA")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "BODEGA 18",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "BODEGA")
                }); 
                  _context.Areas.Add(new Area
                {
                   
                    Nombre = "REGISTRO LA 16",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "SUPERMIO LA 16")
                }); 


                await _context.SaveChangesAsync();
            }
        }
    
        private async Task ChekEpsAsyn()
        {
            if (!_context.Eps.Any())
            {
                _context.Eps.Add(new Eps
                {
                   
                    Nombre = "COOMEVA"
                });
                _context.Eps.Add(new Eps
                {

                    Nombre = "SURA"
                }); _context.Eps.Add(new Eps
                {

                    Nombre = "SANITAS"
                }); _context.Eps.Add(new Eps
                {

                    Nombre = "ASMETSALUD"
                }); _context.Eps.Add(new Eps
                {

                    Nombre = "NUEVA EPS"
                }); _context.Eps.Add(new Eps
                {

                    Nombre = "MEDIMAS"
                }); _context.Eps.Add(new Eps
                {

                    Nombre = "PIMENTEL"
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekPensionAsyn()
        {
            if (!_context.Pensions.Any())
            {
                _context.Pensions.Add(new Pension
                {
                   
                    Nombre = "PORVENIR"
                }); _context.Pensions.Add(new Pension
                {

                    Nombre = "COLFONDOS"
                }); _context.Pensions.Add(new Pension
                {

                    Nombre = "COLPENSIONES"
                }); _context.Pensions.Add(new Pension
                {

                    Nombre = "PROTECCION"
                }); _context.Pensions.Add(new Pension
                {

                    Nombre = "NO APLICA"
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekCajaCompAsyn()
        {
            if (!_context.CajaCompensacions.Any())
            {
                _context.CajaCompensacions.Add(new CajaCompensacion
                {
                   
                    Nombre = "COMFACA"
                });
                 _context.CajaCompensacions.Add(new CajaCompensacion
                {
                   
                    Nombre = "NO APLICA"
                });


                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekMesAsyn()
        {
            if (!_context.Mes.Any())
            {
                _context.Mes.Add(new Mes
                {
                    Name = "Enero"
                });
                _context.Mes.Add(new Mes
                { Name = "Febrero"
                });
                _context.Mes.Add(new Mes
                { Name = "Marzo"
                });
                _context.Mes.Add(new Mes
                {Name = "Abril"
                });
                _context.Mes.Add(new Mes
                { Name = "Mayo"
                });
                _context.Mes.Add(new Mes
                { Name = "Junio"
                });
                _context.Mes.Add(new Mes
                {Name = "Julio"
                });
                _context.Mes.Add(new Mes
                { Name = "Agosto"
                });
                _context.Mes.Add(new Mes
                {Name = "Septiembre"
                });
                _context.Mes.Add(new Mes
                { Name = "Octubre"
                }); _context.Mes.Add(new Mes
                { Name = "Noviembre"
                }); _context.Mes.Add(new Mes
                { Name = "Diciembre"
                });



                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekCategoryAsyn()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category
                {

                    Name = "EQ DE COMPUTACION Y COMUNICACION",
                    Datecreate = DateTime.Now,
                    LifeUse=60,
                    Usucreo="system",
                    Otros=false
                }) ;


                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekFabricAsyn()
        {
            if (!_context.Fabrics.Any())
            {
                _context.Fabrics.Add(new Fabric
                {

                    Name = "APPLE",
                    Datecreate=DateTime.Now,
                    Usucreo="system"

                });


                await _context.SaveChangesAsync();
            }
        }
        private async Task ChekModelAsyn()
        {
            if (!_context.Models.Any())
            {
                _context.Models.Add(new Model
                {

                    Name = "XR",
                    Datecreate = DateTime.Now,
                    Usucreo="system"
                }) ;


                await _context.SaveChangesAsync();
            }
        } 
        private async Task ChekProviderAsyn()
        {
            if (!_context.Providers.Any())
            {
                _context.Providers.Add(new Provider
                {

                    Name = "PROVEEDOR DE PRUEBA",
                    Di = "11111",
                    Direccion = "CALLE NORTE",
                    Email = "LUC01@HOTMAIL.COM",
                    Phone = "311214",
                    Usucreo = "SYSTEM",
                    Datecreate = DateTime.Today
                    
                }) ;


                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager {
                   
                    User = user});
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            int document,
            string firstName,
            string lastName,
            string email,
            string address,
            string movil,
            string role,
             bool activo
            
            )
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = movil,
                    Movil= movil,
                    Address = address,
                    Document = document,
                    DateRegistro=DateTime.Today,
                    Activo=activo,
                    
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Recursoshumanos");
            await _userHelper.CheckRoleAsync("purchasing");
            await _userHelper.CheckRoleAsync("StoreLeader");
            await _userHelper.CheckRoleAsync("UserApp");
         
        }

      
       

       

      

       
    }
}
