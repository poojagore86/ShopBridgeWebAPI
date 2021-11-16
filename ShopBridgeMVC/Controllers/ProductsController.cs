using ShopBridgeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ShopBridgeMVC.Controllers
{
    public class ProductsController : Controller
    {

        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<ProductMVCModel> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<ProductMVCModel>>().Result;
            return View(prodList);
        }

        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
            {
                return View(new ProductMVCModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProductMVCModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductMVCModel prod)
        {
            if (prod.ProductID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", prod).Result;
                TempData["SuccessMessage"] = "Saved Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/"+prod.ProductID.ToString(),prod).Result;
                TempData["SuccessMessage"] = "Updated Successfully!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}