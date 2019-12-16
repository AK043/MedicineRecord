using MedicineRecordProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MedicineRecordProject.Controllers
{
    public class MedicinesController : Controller
    {
        // GET: Medicines
        public ActionResult Index()
        {
            IEnumerable<MedicineModel> medicineModels;
            HttpResponseMessage response = MedicineClass.Clt.GetAsync("Medicines").Result;
            medicineModels = response.Content.ReadAsAsync<IEnumerable<MedicineModel>>().Result;
            return View(medicineModels);
        }
        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            if (id == 0)
                return View(new MedicineModel());
            else
            {
                HttpResponseMessage response = MedicineClass.Clt.GetAsync("Medicines/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MedicineModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddEdit(MedicineModel medicine)
        {
            if (medicine.ID == 0)
            {
                HttpResponseMessage response = MedicineClass.Clt.PostAsJsonAsync("Medicines", medicine).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = MedicineClass.Clt.PutAsJsonAsync("Medicines/" + medicine.ID, medicine).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = MedicineClass.Clt.DeleteAsync("Medicines/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}