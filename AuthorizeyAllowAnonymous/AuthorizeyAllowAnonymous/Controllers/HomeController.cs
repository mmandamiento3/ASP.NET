using AuthorizeyAllowAnonymous.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizeyAllowAnonymous.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var estaAutenticado = User.Identity.IsAuthenticated;
            //if (estaAutenticado)
            //{
            //var Nombreusuario = User.Identity.Name;
            //var id = User.Identity.GetUserId();

            //Toda la informacion del Usuario
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            ///*1era forma con EF*/var usuario = db.Users.Where(x => x.Id == id).FirstOrDefault();
            //                   var emailConfirmado = usuario.EmailConfirmed;


            /*El atributo usermanager nos ofrece una variedad de 
           cosas que podemos ahcerle a los usuarios */
            //var userManager = new UserManager<ApplicationUser>
            //    (new UserStore<ApplicationUser>(db));

            /*2da forma mas sencilla
             con el usermanager*/ /*var usuario2=userManager.FindById(id);*/

            //var user = new ApplicationUser();
            //user.UserName = "Christian";
            //user.Email = "dos@gmail.com";

            ////Crear usuario
            //var resultado = userManager.Create(user,"MiPasswordSecreto");

            //}
            //}


            /*MANEJANDO ROLES*/
            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var idusuarioActual = User.Identity.GetUserId();

                    var roleManager = new RoleManager<IdentityRole>
                        (new RoleStore<IdentityRole>(db));

                    //Crear Rol
                    var resultado = roleManager.Create(new IdentityRole("ApruebaPrestamos"));                 
                    var userManager = new UserManager<ApplicationUser>
                        (new UserStore<ApplicationUser>(db));

                    //Agregar usuario a rol
                    resultado = userManager.AddToRole(idusuarioActual,"ApruebaPrestamos");

                    //Verificamos si el Usuario esta en algun rol?
                    var usuarioEstaEnRol = userManager.IsInRole(idusuarioActual,"ApruebaPrestamos");
                    var usuarioEstaEnRol2 = userManager.IsInRole(idusuarioActual,"OTRO Rol");

                    //roles del Usuario
                    var roles = userManager.GetRoles(idusuarioActual);

                    //Remover a usuario de Rol
                    resultado = userManager.RemoveFromRole(idusuarioActual,"ApruebaPrestamos");

                    //Borrar ROl
                    var RolVendedor = roleManager.FindByName("ApruebaPrestamos");
                    roleManager.Delete(RolVendedor);


                    
                }
            }


            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}