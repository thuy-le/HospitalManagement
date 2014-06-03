using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCService
{
    class View
    {
        private string menu1 = "1. Run HCService\n" +
                               "2. Test Harness\n" +
                               "3. Exit\n" +
                               "Press 0 to exit the program immediately";
        private string menu2 = "1. Manage Hospitals\n" +
                               "2. Manage Doctors\n" +
                               "3. Manage Patients\n" +
                               "4. Manage Records\n" +
                               "5. Back...\n" +
                               "Press 0 to exit the program immediately";
        private string menu3 = "1. Create\n" +
                               "2. View All\n" +
                               "3. Edit\n" +
                               "4. Delete\n" +
                               "5. Back....\n" +
                               "Press 0 to exit the program immediately";
        private string editHospital = "1. Edit Name\n2. Edit Address\n3. Edit License";
        private string editDoctor = "1. Edit Name\n2. Edit Gender\n3. Edit Birthday\n4. Edit Address\n5. Edit License";
        private string editPatient = "1. Edit Name\n2. Edit Gender\n3. Edit Birthday4. Edit Address\n";
        private string editRecord = "1. Edit Diagnosis";
        private string warning1 = "Name should be more than 5 characters\n" + 
                                  "Address should be more than 5 characters";
        private string warning2 = "Date of birth should be in the correct format (MM/DD/YYYY)\n" +
                                  "Gender should be Female/Male/Unknown";
        private string hLicenseWarning = "License should be a 9-character string start with 'A'";
        private string dLicenseWarning = "License should be a 9-character string start with 'D'";
        private string msg1 = "Your choice: ";
        private string breaker = "------------------------------------------------------------------------------";
        public Controller controller;
        public View(Controller c)
        {
            this.controller = c;
            MainMenu();
        }
        /// <summary>
        ///     show Main Menu
        /// </summary>
        private void MainMenu()
        {
            int choice = -1;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("MAIN MENU");
                Console.WriteLine(breaker);
                Console.WriteLine(menu1);
                Console.Write(msg1);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
                if (choice == 1 || choice == 2 || choice == 3) break;
                if (choice == 0) { Environment.Exit(0); }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input");
                Console.Write("Press enter to continue... ");
                Console.ReadLine();
            }
            switch (choice)
            {
                case 1: ManageMenu();
                    break;
                case 2: TestHarness();
                    break;
                case 3: Console.Write("Program is exiting");
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        ///     show Management Menu
        /// </summary>
        private void ManageMenu()
        {
            int choice = -1;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("MANAGEMENT");
                Console.WriteLine(breaker);
                Console.WriteLine(menu2);
                Console.Write(msg1);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5) break;
                if (choice == 0) { Environment.Exit(0); }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input");
                Console.Write("Press enter to continue... ");
                Console.ReadLine();
            }
            switch (choice)
            {
                case 1: OperationMenu(Category.HOSPITAL);
                    break;
                case 2: OperationMenu(Category.DOCTOR);
                    break;
                case 3: OperationMenu(Category.PATIENT);
                    break;
                case 4: OperationMenu(Category.RECORD);
                    break;
                case 5: MainMenu();
                    break;
                default:
                    break;
            }
        }
        /// <summary>Show Operation Menu. Allow users to Create, View, Delete or Edit
        ///    <param name="category">
        ///        Indicates the category to be operated on.
        ///        Category is an enum type defined in Program.cs
        ///        This program has 4 categories corresponding to 4 entities which can 
        ///        be managed by user: Hospital, Doctor, Patient and Patient Record.
        ///    </param>
        ///    <see cref="View.ManageMenu"/>
        /// </summary>
        private void OperationMenu(Category category)
        {
            int choice = -1;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(category.ToString() + " MANAGEMENT");
                Console.WriteLine(breaker);
                Console.WriteLine(menu3);
                Console.Write(msg1);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5) break;
                if (choice == 0) { Environment.Exit(0); }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input");
                Console.Write("Press enter to continue... ");
                Console.ReadLine();
            }
            Console.Clear();
            switch (choice)
            {
                case 1: Create(category);
                    break;
                case 2: ViewList(category);
                    break;
                case 3: Update(category);
                    break;
                case 4: Delete(category);
                    break;
                case 5: ManageMenu();
                    break;
                default:
                    break;
            }
            Console.Write("Press enter to go back to management menu... ");
            Console.ReadLine();
            Console.Clear();
            OperationMenu(category);
        }
        /// <summary>
        ///     show all items regard to category
        /// </summary>
        /// <param name="category"></param>
        public void ViewList(Category category)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ALL " + category.ToString() + "S");
            Console.WriteLine(breaker);
            controller.View(category);
        }
        /// <summary>
        ///     create new item regard to category
        /// </summary>
        /// <param name="category"></param>
        public void Create(Category category)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (category)
            {
                case Category.HOSPITAL: CreateHospital();
                    break;
                case Category.DOCTOR: CreateDoctor();
                    break;
                case Category.PATIENT: CreatePatient();
                    break;
                case Category.RECORD: CreateRecord();
                    break;
                default: break;
            }
        }
        public void Update(Category category)
        {
            switch (category)
            {
                case Category.HOSPITAL: UpdateHospital();
                    break;
                case Category.DOCTOR: UpdateDoctor();
                    break;
                case Category.PATIENT: UpdatePatient();
                    break;
                case Category.RECORD: UpdateRecord();
                    break;
            }
        }
        private void UpdateHospital()
        {
            string header = "UPDATING HOSPITAL\n" + breaker;
            int id;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                controller.ViewHospital();
                Console.Write("Please choose a hospital by entering it's ID: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) 
                {
                    controller.ErrorMsg("Invalid ID. ID should be integer only");
                    continue;
                }
                
                break;
            }            
            int choice = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine(editHospital);
                Console.Write("Please enter choose an option: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                if (choice < 1 || choice > 4)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                bool result = false;
                switch (choice)
                {
                    case 1: Console.Write("Enter new name:");
                        string name = Console.ReadLine();
                        result = controller.UpdateName(Category.HOSPITAL, id, name);
                        break;
                    case 2: Console.Write("Enter new address:");
                        string address = Console.ReadLine();
                        result = controller.UpdateAddress(Category.HOSPITAL, id, address);
                        break;
                    case 3: Console.Write("Enter new license:");
                        string license = Console.ReadLine();
                        result = controller.UpdateLicense(Category.HOSPITAL, id, license);
                        break;
                    case 4: return;
                }
                if (!result) continue;
                break;
            }            
        }

        private void UpdateDoctor()
        {
            string header = "UPDATING DOCTOR\n" + breaker;
            int id;
            Doctor d = null;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                controller.ViewDoctor();
                Console.Write("Please choose a doctor by entering his/her ID: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid ID. ID should be integer only");
                    continue;
                }
                if ((d = controller.findDoctor(id)) == null)
                {
                    controller.ErrorMsg("This doctor id does not exist");
                    continue;
                }
                break;
            }
            if (d == null) return;
            header += "\n" + d.ToString();
            int choice = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine(editDoctor);
                Console.Write("Please enter choose an option: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                if (choice < 1 || choice > 6)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                bool result = false;
                switch (choice)
                {
                    case 1: Console.Write("Enter new name:");
                        string name = Console.ReadLine();
                        result = controller.UpdateName(Category.DOCTOR, id, name);
                        break;
                    case 3: Console.Write("Enter new birthday:");
                        string dob = Console.ReadLine();
                        result = controller.UpdateDOB(Category.DOCTOR, id, dob);
                        break;
                    case 2: Console.Write("Enter new gender:");
                        string gender = Console.ReadLine();
                        result = controller.UpdateGender(Category.DOCTOR, id, gender);
                        break;
                    case 4: Console.Write("Enter new address:");
                        string address = Console.ReadLine();
                        result = controller.UpdateAddress(Category.DOCTOR, id, address);
                        break;
                    case 5: Console.Write("Enter new license:");
                        string license = Console.ReadLine();
                        result = controller.UpdateLicense(Category.DOCTOR, id, license);
                        break;
                    case 6: return;
                }
                if (!result) continue;
                break;
            }            
        }
        private void UpdatePatient()
        {
            string header = "UPDATING PATIENT\n" + breaker;
            int id;
            Patient d = null;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                controller.ViewPatient();
                Console.Write("Please choose a patient by entering his/her ID: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid ID. ID should be integer only");
                    continue;
                }
                if ((d = controller.findPatient(id)) == null)
                {
                    controller.ErrorMsg("This patient id does not exist");
                    continue;
                }
                break;
            }
            if (d == null) return;
            header += "\n" + d.ToString();
            int choice = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine(editPatient); ;
                Console.Write("Please enter choose an option: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                if (choice < 1 || choice > 4)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                bool result = false;
                switch (choice)
                {
                    case 1: Console.Write("Enter new name:");
                        string name = Console.ReadLine();
                        result = controller.UpdateName(Category.PATIENT, id, name);
                        break;
                    case 3: Console.Write("Enter new birthday:");
                        string dob = Console.ReadLine();
                        result = controller.UpdateDOB(Category.PATIENT, id, dob);
                        break;
                    case 2: Console.Write("Enter new gender:");
                        string gender = Console.ReadLine();
                        result = controller.UpdateGender(Category.PATIENT, id, gender);
                        break;
                    case 4: Console.Write("Enter new address:");
                        string address = Console.ReadLine();
                        result = controller.UpdateAddress(Category.PATIENT, id, address);
                        break;
                    case 5: return;
                }
                if (!result) continue;
                break;
            }            
        }
        private void UpdateRecord()
        {
            string header = "UPDATING RECORD\n" + breaker;
            int id;
            PatientRecord h = null;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                controller.ViewRecord();
                Console.Write("Please choose a record by entering it's ID: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid ID. ID should be integer only");
                    continue;
                }
                if ((h = controller.findRecord(id)) == null)
                {
                    controller.ErrorMsg("This record id does not exist");
                    continue;
                }
                break;
            }
            if (h == null) return;
            header += "\n" + h.ToString();
            int choice = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine(editHospital);
                Console.Write("Please choose an option: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                if (choice != 1)
                {
                    controller.ErrorMsg("Invalid Input");
                    continue;
                }
                break;
            }
            switch (choice)
            {
                case 1: Console.Write("Enter new diagnosis:");
                    string diagnosis = Console.ReadLine();
                    if (controller.DiagnosisChecker(diagnosis))
                    {
                        h.Diagnosis = diagnosis;
                        Console.WriteLine("Diagnosis edited to " + h.Diagnosis);
                    }
                    break;                
            }
        }
        /// <summary>
        ///     Delete item regard to cetegory
        /// </summary>
        /// <param name="category"></param>
        public void Delete(Category category)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DELETE " + category.ToString());
            Console.WriteLine(breaker);
            switch (category)
            {
                case Category.HOSPITAL: controller.ViewHospital();
                    break;
                case Category.DOCTOR: controller.ViewDoctor();
                    break;
                case Category.PATIENT: controller.ViewPatient();
                    break;
                case Category.RECORD: controller.ViewRecord();
                    break;
            }
            int choice = -1;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter " + category.ToString() + " ID");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (choice < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input");
                    continue;
                }                
                break;
            }
            if (controller.Delete(category, choice))
                Console.WriteLine(category + " Deleted!");
            else
                Console.WriteLine("Nothing Deleted!");
        }
        /// <summary>
        ///    Takes and validates user input for creating a new hospital
        ///    <see cref="Controller.CreateHospital"/>
        /// </summary>
        public void CreateHospital()
        {
            string name = "";
            string license = "";
            string address = "";
            string confirm = "";
            string header = "CREATING NEW HOSPITAL\n" + breaker;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(warning1);
                Console.WriteLine(hLicenseWarning);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hospital Name: ");
                name = Console.ReadLine();
                Console.Write("Address: ");
                address = Console.ReadLine();
                Console.Write("License: ");
                license = Console.ReadLine();
                if (controller.CreateHospital(name,license,address)) break;
                Console.Write("Continue? (y/n) ");
                confirm = Console.ReadLine();
                if (confirm != "y") return;
            }            
        }
        /// <summary>
        ///    Takes and validates user input for adding a new doctor 
        ///    <see cref="Controller.CreateDoctor"/>
        /// </summary>
        private void CreateDoctor()
        {
            string name = "";
            string gender = "";
            string dob = "";
            string license = "";
            string address = "";
            string confirm = "";
            string header = "CREATING NEW DOCTOR\n" + breaker;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(warning1);
                Console.WriteLine(warning2);
                Console.WriteLine(dLicenseWarning);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Doctor Name: ");
                name = Console.ReadLine();
                Console.Write("Gender: ");
                gender = Console.ReadLine();
                Console.Write("Date of birth (MM/DD/YYYY): ");
                dob = Console.ReadLine();
                Console.Write("Address: ");
                address = Console.ReadLine();
                Console.Write("Doctor License: ");
                license = Console.ReadLine();
                if (controller.CreateDoctor(name, gender, dob, license, address)) break;
                Console.Write("Continue? (y/n) ");
                confirm = Console.ReadLine();
                if (confirm != "y") return;
            }
            Console.WriteLine("New Doctor Added");
        }
        /// <summary>
        ///    Takes and validates user input for adding a new patient 
        ///    <see cref="Controller.CreatePatient"/>
        /// </summary>
        private void CreatePatient()
        {
            string name = "";
            string gender = "";
            string dob = "";
            string address = "";
            string confirm = "";
            string header = "CREATING NEW PATIENT\n" + breaker;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(warning1);
                Console.WriteLine(warning2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Patient Name: ");
                name = Console.ReadLine();
                Console.Write("Gender: ");
                gender = Console.ReadLine();
                Console.Write("Date of birth (MM/DD/YYYY): ");
                dob = Console.ReadLine();
                Console.Write("Address: ");
                address = Console.ReadLine();
                if (controller.CreatePatient(name, gender,dob,address)) break;
                Console.Write("Continue? (y/n) ");
                confirm = Console.ReadLine();
                if (confirm != "y") return;
            }                        
            Console.WriteLine("New Patient Added");
        }
        /// <summary>
        ///     Takes and validates user input for creating a new record
        ///    <see cref="Controller.CreateRecord"/>
        /// </summary>
        public void CreateRecord()
        {
            int patientID;
            int hospitalID;
            int doctorID;
            Patient patient = null;
            Hospital hospital = null;
            Doctor doctor = null;
            string diagnosis = "";
            Outcome outcome = Outcome.CURED;
            Console.Clear();
            string header = "CREATING NEW RECORD" + "\n" + breaker;
            while (true)
            {                
                Console.Clear();
                Console.WriteLine(header);
                Console.Write("Please enter PatientID: ");
                try
                {
                    patientID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { controller.ErrorMsg("Invalid ID"); continue; }
                if ((patient = controller.findPatient(patientID)) != null) break;
                controller.ErrorMsg("This patient does not exist in database");
            }
            header += "\nPatient: " + patient.Name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.Write("Please enter DoctorID: ");
                try
                {
                    doctorID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { controller.ErrorMsg("Invalid ID"); continue; }
                if ((doctor = controller.findDoctor(doctorID)) != null) break;
                controller.ErrorMsg("This doctor does not exist in database");
            }
            header += "\nDoctor: " + doctor.Name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.Write("Please enter HospitalID: ");
                try
                {
                    hospitalID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { controller.ErrorMsg("Invalid ID"); continue; }
                if ((hospital = controller.findHospital(hospitalID)) != null) break;
                controller.ErrorMsg("This hospital does not exist in database");
            }
            header += "\nHospital: " + hospital.Name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.Write("Diagnosis: ");
                diagnosis = Console.ReadLine();
                if (diagnosis.Length > 5) break;
                controller.ErrorMsg("Diagnosis should be more than 5 characters");
            }
            header += "\nDiagnosis " + diagnosis;
            int choice = -1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);                
                Console.WriteLine("Please choose an outcome");
                Console.WriteLine("1. CURED\t2. INCREASED\t3. DECREASED\t4. UNCHANGED\t5. DIED");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5) break;
                controller.ErrorMsg("Wrong Input");
            }
            switch (choice)
            {
                case 1: outcome = Outcome.CURED;
                    break;
                case 2: outcome = Outcome.INCREASED;
                    break;
                case 3: outcome = Outcome.DECREASED;
                    break;
                case 4: outcome = Outcome.UNCHANGED;
                    break;
                case 5: outcome = Outcome.DIED;
                    break;
                default: break;
            }
            header += "\nOutcome: " + outcome.ToString();
            Console.Clear();
            Console.WriteLine(header);
            controller.CreateRecord(patient, doctor, hospital, diagnosis, outcome);
            Console.WriteLine("New Record Addded");
        }
        /// <summary>
        ///     putting sample inputs for program testing
        /// </summary>
        private void TestHarness()
        {
            Console.Clear();
            Test test = new Test(controller);
            test.TestDeleteFunction();
            Console.Write("Press enter to continue... ");
            Console.ReadLine();
            MainMenu();
        }        
    }
}
