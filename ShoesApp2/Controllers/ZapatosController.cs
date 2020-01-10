using ShoesApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesApp2.Controllers
{
    public class ZapatosController : Controller
    {
        // GET: Zapatos
        DataProductsEntities db = new DataProductsEntities();

        public ActionResult Index(string searching, string Bnombre)
        {
            try
            {


                var zapatos = from s in db.FASV1_GetAllProducts()
                              select s;

                if (!String.IsNullOrEmpty(searching))
                {
                    zapatos = zapatos
                        .Where(s => s.Id == Convert.ToInt32(searching));
              
                }

                if (!String.IsNullOrEmpty(Bnombre))
                {
                    zapatos = zapatos
                        .Where(s => s.Nombre.Contains(Bnombre));

                }

                ViewBag.Search = null;
                ModelState.Remove("searching");
                ModelState.Remove("Bnombre");


                return View(zapatos.ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult Agregar()
        {   
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(FASV1_GetAllProducts_Result p)
        {
            if (!ModelState.IsValid)            
                return View();

            try
            {
                p.DateUpdate = DateTime.Now;

                SqlParameter param1 = new SqlParameter("@Title", p.Nombre);
                SqlParameter param2 = new SqlParameter("@descripcion", p.Description);
                SqlParameter param3 = new SqlParameter("@price", p.PriceClient);
                SqlParameter param4 = new SqlParameter("@color", p.IdColor);
                SqlParameter param5 = new SqlParameter("@date", p.DateUpdate);
                var db = new DataProductsEntities();
                var data = db.Database.ExecuteSqlCommand("FASV1_InsertProduct @Title , @descripcion , @price , @color, @date", param1,param2,param3,param4, param5);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new DataProductsEntities())
                {
                    FASV1_GetAllProducts_Result Ez = db.FASV1_GetAllProducts().Where(a => a.Id == id).FirstOrDefault();

                    return View(Ez);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FASV1_GetAllProducts_Result e)
        {
            try
            {
                using (var db = new DataProductsEntities())
                {


                    Products p = db.Products.Find(e.Id);
                    p.Nombre = e.Nombre;
                    p.IdColor = e.IdColor;
                    p.Description = e.Description;
                    p.PriceClient = e.PriceClient;
                    p.IsEnabled = e.IsEnabled;
                    p.DateUpdate = DateTime.Now;


                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        public ActionResult Delete(int id)
        {
            using (var db = new DataProductsEntities())
            {
                FASV1_GetAllProducts_Result Ez = db.FASV1_GetAllProducts().Where(a => a.Id == id).FirstOrDefault();
                db.FASV1_DeleteLogic(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }                
        }

        public ActionResult ListaColor()
        {
            using (var db = new DataProductsEntities())
            {
                return PartialView(db.CatColors.ToList());
            }
        }

        public static string NombreColor(int IdColor)
        {
            using (var db = new DataProductsEntities())
            {
                return db.CatColors.Find(IdColor).Name;
            }
        }
    }
}   