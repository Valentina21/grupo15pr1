using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.Data.Entity;

//Probando si anda
//prueba2
namespace PresentationLayerConsole
{
    class Program
    {
        static void Main(string[] args)
        {           
            IBLEmployees blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());

            //your code goes here!
            //use the blHandler reference to the business logic layer
            //...
            //...

            //Descomentar solo la primera vez. Esto genera la base de datos e inserta un elemento
           /* using (var context = new InheritanceMappingContext())
            {
                FullTimeEmployee full = new FullTimeEmployee()
                {
                    Name = "Juan",
                    Salary = 500,
                    StartDate = DateTime.Today
                };

                context.Employees.Add(full);

                context.SaveChanges();
            }*/
        }
    }

    
}

