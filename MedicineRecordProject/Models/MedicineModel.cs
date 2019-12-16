using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineRecordProject.Models
{
    public class MedicineModel
    {
        public int ID { get; set; }
        public string MedicineName { get; set; }
        public string Company { get; set; }
        public string Reason { get; set; }
        public string ExpiryDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}