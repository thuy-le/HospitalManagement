using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCService
{
    class Test
    {
        Controller controller;
        public Test(Controller c)
        {
            this.controller = c;
        }
        public void TestDeleteFunction()
        {
            string breaker = "\n------------------------------------------"+
            "-----------------------------------------------------------"+
            "-----------------------------------------------------------";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Attemp to delete a Hospital with ID: 005");            
            controller.Delete(Category.HOSPITAL, 5);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.ViewHospital();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to delete a Patient with ID: 013");            
            controller.Delete(Category.PATIENT, 13);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.ViewPatient();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(breaker);
            
            Console.WriteLine("Attemp to view all patients");
            Console.ForegroundColor = ConsoleColor.Cyan;
            controller.View(Category.PATIENT);
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to view a \"none\" category");
            controller.View(Category.NONE);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(breaker);
            
            Console.WriteLine("Attemp to create a hospital with values:\n"
                + "Name: Saint Mary; License: A78GHBN89; Address: 10 Brooklyn");
            controller.CreateHospital("Saint Mary", "A78GHBN89", "10 Brooklyn");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.ViewHospital();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(breaker);
            
            Console.WriteLine("Attemp to create a doctor with values:\n"
                + "Name: Gabrielle Jackson; Gender: Man; DOB: 09/27/1990; License: D78GHBN89; Address: 10 Brooklyn");
            controller.CreateDoctor("Gabrielle Jackson", "Man", "09/27/1990", "D78GHBN89", "10 Brooklyn");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.ViewDoctor();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to create a patient with values:\n"
                + "Name: Annie Johnsons; Gender: Female; DOB: 06/31/1990; Address: 10 Brooklyn");
            controller.CreatePatient("Annie Johnsons", "Female", "06/31/1990", "10 Brooklyn");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.ViewPatient();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to edit a patient's DOB whose id is 001 to 06/30/2010");
            controller.UpdateDOB(Category.PATIENT, 1, "06/30/1990");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.findPatient(1).ToString();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to edit a doctor's DOB whose id is 007 to 06/31/2010");
            controller.UpdateDOB(Category.DOCTOR, 7, "06/31/1990");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.findDoctor(7).ToString();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(breaker);

            Console.WriteLine("Attemp to edit a hospital's name with id is 004 to \"Fox Community\"");
            controller.UpdateName(Category.HOSPITAL, 4, "Fox Community");            
            Hospital h = controller.findHospital(4);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (h == null) { controller.ErrorMsg("Hospital cannot be found"); }
            else Console.WriteLine(h.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(100);
        }
    }
}
