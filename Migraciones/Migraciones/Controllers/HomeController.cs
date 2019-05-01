using Migraciones.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Migraciones.Controllers
{
    public class HomeController : Controller
    {
        //Ene sta clase es donde se alamcenaran los datos del procedimiento alamacenado
        //que retornaran del QUERY, ya que utilizan parametros
        private class NombreEdad
        {
            public string Nombre { get; set; }
            public DateTime Nacimiento { get; set; }
            public int Edad { get; set; }
            public int Sexo { get; set; }
        }


        public ActionResult Index()
            
        {

            //CONSUMIMOS LOS PROCEDIMIENTOS ALMACENADOS
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Este procedure utuliza parametros, por lo tanto usamos el "SqlQuery"
                var personas = db.Database.SqlQuery<NombreEdad>("sp_Personas_Por_Edad @Edad",
                    new SqlParameter("@Edad", 27)).ToList();

                //Este no retorna ni utiliza parametros
                db.Database.ExecuteSqlCommand("sp_Borra_Personas_Menores");

            }
                return View();
        }

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