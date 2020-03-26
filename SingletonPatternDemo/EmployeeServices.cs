using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternDemo
{
    public class EmployeeServices // Dit is de Singleton class,niet static

    {
        private static EmployeeServices instance; // private field of employeeservices type

        private List<Employee> employeeList = null; // Dit moet op null staan!


        private static readonly object _lock = new object(); // _lock is GMP
        // Dit is voor de threading. we willen dat methodes maar door max 1 persoon wordt uitgevoerd ipv simultaan

        private EmployeeServices() // private ctor (normaal public)
        {
            if (employeeList == null) // controle of er maar 1 instantie is! Max 1!
            {
                employeeList = new List<Employee>();
            }
        }
        // Dus bij singleton maar max 1 instantie

        // non-thread safe
        //public static EmployeeServices Instance()// Dit noemt altijd Instance!
        //{
        //    
        //        instance = new EmployeeServices();
        //    
        //    return instance; // Dus als je instance oproept (via Instance methode) dan maak je de list.
        //}

        // thread safe --> dit moet bij de critical session, dit is de critical session
        public static EmployeeServices Instance()// Dit noemt altijd Instance!
        {
            if (instance == null) // nu 100% zeker dat dit thread safe is. 100% goed. Dit is GMP maar moet niet van Kenan
            {
                lock (_lock) // Dit maakt het redelijk thread safe (99% goed)
                {
                    if (instance == null) // controle hier ook
                    {
                        instance = new EmployeeServices();
                    }
                }
            }
            return instance; // Dus als je instance oproept (via Instance methode) dan maak je de list.
        }

        public void AddEmployees(Employee employee)
        {
            employeeList.Add(employee);
        }
        public List<Employee> GetEmployeesByFirstName(string firstName)
        {
            return employeeList.FindAll(x => x.FirstName.Contains(firstName));
        }



    }
}
