using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        static DBContext db = new DBContext();

        public ActionResult Index()
        {
            // SELECT*FROM OBJETOS;
            var List = db.ObjetosDB.ToList();
            // SELECT*FROM OBJETOS WHERE ID_OBJETO=?;
            var WhereList = db.ObjetosDB.Where(x => x.ID_OBJETO ==1).ToList();
            // seleccionamos uno
            var Select1 = db.ObjetosDB.Where(x => x.ID_OBJETO == 1).FirstOrDefault();
            return View(List);
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


        // JSONS
        public JsonResult ObtenerObjeto(int idObjeto)
        {
            var objeto = db.ObjetosDB.Where(x => x.ID_OBJETO == idObjeto).FirstOrDefault();
            return Json(objeto, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AgregarObjeto(string nombre, string color, DateTime fechaRegistro, decimal precio)
        {
            OBJETOS objNuevo = new OBJETOS();
            objNuevo.NOMBRE = nombre;
            objNuevo.COLOR = color;
            objNuevo.FECHA_REGISTRO = fechaRegistro;
            objNuevo.PRECIO = precio;

            try
            {
                db.ObjetosDB.Add(objNuevo);
                db.SaveChanges();
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        public JsonResult EditarObjeto(int idObjeto, string nombre, string color, DateTime fechaRegistro, decimal precio)
        {
            var objeto = db.ObjetosDB.Where(x => x.ID_OBJETO == idObjeto).FirstOrDefault();
            objeto.NOMBRE = nombre;
            objeto.COLOR = color;
            objeto.FECHA_REGISTRO = fechaRegistro;
            objeto.PRECIO=precio;
            try
            {
                db.SaveChanges();
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        public JsonResult EliminarObjeto(int idObjeto)
        {
            OBJETOS objeto = db.ObjetosDB.Find(idObjeto);
            try
            {
                db.ObjetosDB.Remove(objeto);
                db.SaveChanges();
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
                throw;
            }
            
            //var objeto = db.ObjetosDB.Where(x => x.ID_OBJETO == idObjeto).FirstOrDefault();
            return Json(objeto, JsonRequestBehavior.AllowGet);
        }
    }
}