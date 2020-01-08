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
        public ActionResult Index()
        {
            try
            {
                DataProductsEntities db = new DataProductsEntities();
                //db.FASV1_GetAllProducts();

                return View(db.FASV1_GetAllProducts());
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

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }              
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}