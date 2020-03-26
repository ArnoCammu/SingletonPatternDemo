using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Static class heeft geen instanties. Maar static class is lastig. Voor opslaan van gegevens is dit slecht
            // Deze static class wordt opgemaakt en blijft in het geheugen tot zolang de app loopt.
            // Daarin heeft singleton een voordeel. Je hebt hier maar 1 instantie nodig ipv meerdere. Minder lastig voor het geheugen
            // Dit is ook beter voor unit testing en wordt erg veel gebruikt bij loggers

            // Dit is puur voor GIt, nedeer dit maar
            Employee emp1 = new Employee();
            emp1.FirstName = "Kenan";
            emp1.LastName = "Kurda";
            Employee emp2 = new Employee();
            emp2.FirstName = "Jan";
            emp2.LastName = "Martens";
            Employee emp3 = new Employee();
            emp3.FirstName = "Kevin";
            emp3.LastName = "Burghaus";
            Employee emp4 = new Employee();
            emp4.FirstName = "Arek";
            emp4.LastName = "IetsPools";
            Employee emp5 = new Employee();
            emp5.FirstName = "Bol";
            emp5.LastName = "Bauwens";

            EmployeeServices empServices = EmployeeServices.Instance(); // Een nieuwe class gemaakt
            // Deze kun je meerdere keren aanroepen maar hij maakt toch maar eentje aan!

            empServices.AddEmployees(emp1);
            empServices.AddEmployees(emp2);
            empServices.AddEmployees(emp3);
            empServices.AddEmployees(emp4);
            empServices.AddEmployees(emp5);

            List<Employee> LijstMetNaam = empServices.GetEmployeesByFirstName("Ke"); // ik kan ook var gebruiken ipv de lijst

            foreach (var item in LijstMetNaam)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}"); // 2 namen met "Ke" erin!
            }

            Console.ReadLine();


        }
    }
}
