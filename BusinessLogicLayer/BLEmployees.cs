using DataAccessLayer;
using Shared.Entities;
using Shared.Exception; //PRUEBA REPO NACHO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;


        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Employee emp)
        {
            _dal.AddEmployee(emp) ;
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            _dal.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return _dal.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _dal.GetEmployee(id);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                throw new EmployeeNotExist("Empleado no encontrado");
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
           return _dal.SearchEmployees(searchTerm) ;
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            Employee emp = _dal.GetEmployee(idEmployee);
            if (emp != null)
            {
                if (emp is PartTimeEmployee)
                {
                    PartTimeEmployee empPT = (PartTimeEmployee)emp;
                    return empPT.HourlyDate * hours;
                }
                else
                {
                    throw new EmployeeDifferentType("El Empleado no es Part Time");
                }
            }
            else
            {
                throw new EmployeeNotExist("Empleado no encontrado");
            }
        }
    }
}
