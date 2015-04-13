using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesMock : IDALEmployees
    {
        private List<Employee> employeesRepository = new List<Employee>()
        {
            new PartTimeEmployee(){HourlyDate = 100},
            new PartTimeEmployee(){HourlyDate = 150},
            new PartTimeEmployee(){HourlyDate = 200},
            new PartTimeEmployee(){HourlyDate = 250},
            new PartTimeEmployee(){HourlyDate = 300},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
        };

        public void AddEmployee(Employee emp)
        {
            using (var context = new InheritanceMappingContext())
            {
                 context.Employees.Add(emp);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new InheritanceMappingContext())
            {
                context.Employees.Remove(this.GetEmployee(id));
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (var context = new InheritanceMappingContext())
            {
               Employee aux = (context.Employees.First(p => p.Id == emp.Id));
               aux = emp;
               context.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var context = new InheritanceMappingContext())
            {
                return context.Employees.ToList();
            }
        }

        public int GetLastIdEmployee()
        {
            using (var context = new InheritanceMappingContext())
            {
                return context.Employees.Max(p=>p.Id);
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var context = new InheritanceMappingContext())
            {
                if (context.Employees.Where(p => p.Id == id).Count() > 0)
                {
                    return context.Employees.First(p => p.Id == id);
                }
                return null;
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            using (var context = new InheritanceMappingContext())
            {
                return context.Employees.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
        }
    }
}
