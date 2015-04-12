using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.Data.Entity;
using Shared.Exception;

//Probando si anda
//prueba2
namespace PresentationLayerConsole
{
    class Program
    {
        static void Main(string[] args)
        {           
            IBLEmployees blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            Console.WriteLine("Comandos Aceptados:");
            Console.WriteLine("-------------------");
            Console.WriteLine("Insert {Nombre:string} {Fecha Comienzo: string dd/mm/aaaa} {Tipo: F o P} {Si F Salario: int ? Valor Hora: double} ");
            Console.WriteLine("Delete {Id: int}");
            Console.WriteLine("Update {Id: int} {Nombre:string} {Fecha Comienzo: string dd/mm/aaaa} {Si F Salario: int ? Valor Hora: double} ");
            Console.WriteLine("Get {Id: int}");
            Console.WriteLine("");
            
            String command;
            Boolean quitNow = false;
            while (!quitNow)
            {
                Console.WriteLine("Escriba un comando...");
                string[] readline = Console.ReadLine().Split(' ');
                command = readline[0];
                try
                {
                    switch (command.ToLower())
                    {
                        case "insert":
                            if (readline.Length == 5)
                            {
                                string name = readline[1];
                                string date = readline[2];
                                string typeEmp = readline[3];
                                string salaryValue = readline[4];
                                if (typeEmp == "F")
                                {
                                    blHandler.AddEmployee(new FullTimeEmployee()
                                    {
                                        Id = blHandler.GetLastIdEmployee() + 1,
                                        Name = name,
                                        Salary = int.Parse(salaryValue),
                                        StartDate = Convert.ToDateTime(date)
                                    });
                                    Console.WriteLine("Empleado Agregado correctamente");
                                }
                                else if (typeEmp == "P")
                                {
                                    blHandler.AddEmployee(new PartTimeEmployee()
                                    {
                                        Id = blHandler.GetLastIdEmployee() + 1,
                                        Name = name,
                                        HourlyDate = double.Parse(salaryValue),
                                        StartDate = Convert.ToDateTime(date)
                                    });
                                    Console.WriteLine("Empleado Agregado correctamente.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cantidad de parametros incorrectos.");
                            }

                            break;

                        case "delete":
                            if (readline.Length == 2)
                            {
                                string id = readline[1];
                                blHandler.DeleteEmployee(int.Parse(id));
                                Console.WriteLine("Empleado eliminado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Cantidad de parametros incorrectos.");
                            }
                            break;

                        case "update":
                            if (readline.Length == 5)
                            {
                                string id = readline[1];
                                string name = readline[2];
                                string date = readline[3];
                                string salaryValue = readline[4];
                                Employee emp = blHandler.GetEmployee(int.Parse(id));
                                if (emp is PartTimeEmployee)
                                {
                                    PartTimeEmployee pt = (PartTimeEmployee)emp;
                                    pt.Name = name;
                                    pt.StartDate = Convert.ToDateTime(date);
                                    pt.HourlyDate = double.Parse(salaryValue);
                                    blHandler.UpdateEmployee(pt);
                                    Console.WriteLine("Empleado actualizado correctamente.");
                                }
                                else
                                {
                                    FullTimeEmployee ft = (FullTimeEmployee)emp;
                                    ft.Name = name;
                                    ft.StartDate = Convert.ToDateTime(date);
                                    ft.Salary = int.Parse(salaryValue);
                                    blHandler.UpdateEmployee(ft);
                                    Console.WriteLine("Empleado actualizado correctamente.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cantidad de parametros incorrectos.");
                            }
                            break;

                        case "get":
                            if (readline.Length == 2)
                            {
                                string id = readline[1];
                                Employee emp = blHandler.GetEmployee(int.Parse(id));
                                Console.WriteLine(" ");
                                Console.WriteLine("FICHA EMPLEADO");
                                Console.WriteLine("-------------------");
                                Console.WriteLine(" ");
                                Console.WriteLine("NOMBRE:" + emp.Name);
                                Console.WriteLine("FECHA INGRESO:" + emp.StartDate.ToShortDateString());
                                if (emp is PartTimeEmployee)
                                {
                                    Console.WriteLine("TIPO:PART TIME");
                                    Console.WriteLine("VALOR HORA:" + ((PartTimeEmployee)emp).HourlyDate.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("TIPO:FULL TIME");
                                    Console.WriteLine("SALARIO:" + ((FullTimeEmployee)emp).Salary.ToString());
                                }
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.WriteLine("Cantidad de parametros incorrectos.");
                            }
                            break;
                                                    
                        case "exit":
                            quitNow = true;
                            break;
                        default:
                            Console.WriteLine("Comando invalido " + command);
                            break;

                    }
                }
                catch (EmployeeNotExist ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (EmployeeDifferentType ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }

    
}

