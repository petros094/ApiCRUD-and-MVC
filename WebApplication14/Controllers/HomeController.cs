using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class HomeController : Controller
    {

        public HttpClient ApiClient()
        { 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49607/api/");
            return client;
        }


        public ActionResult Index()
        {
            IEnumerable<PersonModel> personlist;

           
            var response = ApiClient().GetAsync("Values");
            response.Wait();
            var result = response.Result;
                var read = result.Content.ReadAsAsync<IList<PersonModel>>();
                read.Wait();
                personlist = read.Result;
            return View(personlist);
        }


        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(PersonModel person)
        {
            var post = ApiClient().PostAsJsonAsync<PersonModel>("Values", person);
            post.Wait();
            var result = post.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View(person);
        }


        public ActionResult Edit(int id)
        {
            var respons = ApiClient().GetAsync("Values?id=" + id.ToString());
            respons.Wait();
            var result = respons.Result;
            var read = result.Content.ReadAsAsync<PersonModel>();
            read.Wait();
            PersonModel person = read.Result;
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(PersonModel person)
        {
            var put = ApiClient().PutAsJsonAsync<PersonModel>("Values/" +person.Personid.ToString(), person);
            put.Wait();
            var result = put.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View(person);
        }

        public ActionResult Delete(int id)
        {
            var delete = ApiClient().DeleteAsync("Values/" + id.ToString());
            delete.Wait();

            return RedirectToAction("index");
        }
    }
}
