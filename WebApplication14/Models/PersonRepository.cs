using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class PersonRepository : IRepository<Person>
    {
        PersonEntity db;
        public PersonRepository(PersonEntity db)
        {
            this.db = db;
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Person;
        }

        public Person Get(int id)
        {
            return db.Person.Find(id);
        }

        public void Create(Person item)
        {
            db.Person.Add(item);
        }

        public void Edit(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.Person.Find(id);
            db.Person.Remove(item);
            db.SaveChanges();
        }

       

       

       
    }
}
