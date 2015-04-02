using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (var context = new InheritanceMappingContext())
            {
                context.Employees.Add(emp);

                context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new InheritanceMappingContext())
            {
                context.Employees.Remove(this.GetEmployee(id));

                context.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (var context = new InheritanceMappingContext())
            {
                Employee aux = this.GetEmployee(emp.Id);
                aux = emp;
                context.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var context = new InheritanceMappingContext())
            {
                return (from emp in context.Employees select emp).ToList();
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var context = new InheritanceMappingContext())
            {
                return (from emp in context.Employees where emp.Id == id select emp).First();
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
