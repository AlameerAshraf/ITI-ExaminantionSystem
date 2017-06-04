using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace App_iti.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        HttpClient App;
        public ActionResult Test()
        {
            App = new HttpClient();
            Use Test = new Use() { id = 1, name = "Alameer" };
            var s = JsonConvert.SerializeObject(Test);
            App.DefaultRequestHeaders.Add("Authorization", "bearer ezFSrM3EdKJzqAlXsUjRT2GBUVy9L__E5SeqxZ8fEIQosBGvhGqNanIw5d5vtxJnkVgHmTaVvPEh2A_tyO6EWDSU4KIQKvSRlG8d8BdmIoNqD_slGSb3xRcKIHaeuxYKZ4y6pS0tS3bLriCbrnup_-GxFbBeJqblHGbNQbaTwI8xJ7uOzkfvY-JCGd5rJ5LI8B01WvGpwGTiynVnLw-d4gTgjhXD3pmaI1_lUEolNPf1WlfAR1v5ZmJjSTWgwC7mj1YoLxleHmfVYJ7_DkUOPZxiPPBM0ZxtButKJNGXrak");
            var response = App.PostAsync("http://localhost:51822/api/Values/UseTest", new StringContent(
                 new JavaScriptSerializer().Serialize(Test), Encoding.UTF8, "application/json")).Result;
            return Content(response.Content.ReadAsStringAsync().Result);
        }

        HttpClient client; 
        public ActionResult DeleteTest()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer ezFSrM3EdKJzqAlXsUjRT2GBUVy9L__E5SeqxZ8fEIQosBGvhGqNanIw5d5vtxJnkVgHmTaVvPEh2A_tyO6EWDSU4KIQKvSRlG8d8BdmIoNqD_slGSb3xRcKIHaeuxYKZ4y6pS0tS3bLriCbrnup_-GxFbBeJqblHGbNQbaTwI8xJ7uOzkfvY-JCGd5rJ5LI8B01WvGpwGTiynVnLw-d4gTgjhXD3pmaI1_lUEolNPf1WlfAR1v5ZmJjSTWgwC7mj1YoLxleHmfVYJ7_DkUOPZxiPPBM0ZxtButKJNGXrak");
            var response = client.DeleteAsync("http://localhost:51822/api/Values/DeleteTest/10").Result;

            return Content(response.ToString());
        }

    }

    public class Use
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}