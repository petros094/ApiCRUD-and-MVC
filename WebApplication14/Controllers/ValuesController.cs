using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class ValuesController : ApiController
    {

        UnitOfWork unitofwork;

        public ValuesController()
        {
            unitofwork = new UnitOfWork();
        }

        public IEnumerable<Person> Get()
        {
            return unitofwork.Person.GetAll();
        }

        public Person Get(int id)
        {
            var person = unitofwork.Person.Get(id);
            return person;
        }

        public void Post(Person person)
        {
            unitofwork.Person.Create(person);
            unitofwork.SaveChanges();
        }

        public void Put(int id,Person person)
        {
            if(id==person.Personid)
            {
                unitofwork.Person.Edit(person);
                unitofwork.SaveChanges();
            }
        }

        public void Delete(int id)
        {

            unitofwork.Person.Delete(id);
            unitofwork.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                unitofwork.Dispose();

            base.Dispose(disposing);
        }
    }
}
