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

        public int GetLastIdEmployee()
        {
            using (var context = new InheritanceMappingContext())
            {
                return context.Employees.Max(p => p.Id);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new InheritanceMappingContext())
            {
                Employee emp = this.GetEmployee(id);
                context.Employees.Attach(emp);
                context.Employees.Remove(emp);

                context.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (var context = new InheritanceMappingContext())
            {
                context.Employees.Attach(emp);
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
                if ((from emp in context.Employees where emp.Id == id select emp).Count() > 0)
                {
                    Employee emple = (from emp in context.Employees where emp.Id == id select emp).First();
                    return emple;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            using (var context = new InheritanceMappingContext())
            {
                return (from emp in context.Employees where emp.Name == searchTerm select emp).ToList();
            }
        }
    }
}