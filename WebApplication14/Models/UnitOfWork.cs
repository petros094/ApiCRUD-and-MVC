using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class UnitOfWork:IDisposable
    {
        PersonEntity db = new PersonEntity();
        PersonRepository repository;

        public PersonRepository Person
        {
            get
            {
                if(repository==null)
                {
                    repository = new PersonRepository(db);
                }
                return repository;
            }
        }

        public void SaveChanges()
        { 
            db.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
