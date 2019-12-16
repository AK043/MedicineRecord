using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MedicineRecordProject
{
    public static class MedicineClass
    {
        public static HttpClient Clt = new HttpClient();
        static MedicineClass()
        {
            Clt.BaseAddress = new Uri("http://localhost:59767/api/");
            Clt.DefaultRequestHeaders.Clear();
            Clt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}