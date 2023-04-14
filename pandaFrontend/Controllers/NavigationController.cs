using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pandacommerce_dal.Model;
using System.Net.Http.Headers;

namespace pandaFrontend.Controllers
{
    public class NavigationController : Controller
    {
        private static string url = "https://localhost:7175/";

        public async Task<IActionResult> AllNavigationList()
        {
            List<NavCategory> listNav = new List<NavCategory>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("/api/v1/NavApiController/GetAllNavigationCategory");
                if(response != null)
                {
                    var navigationlist = response.Content.ReadAsStringAsync().Result;
                    listNav = JsonConvert.DeserializeObject<List<NavCategory>>(navigationlist);
                }
            }
        return View(listNav); 
        }


    }
}
