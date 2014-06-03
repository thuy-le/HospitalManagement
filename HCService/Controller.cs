using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCService
{
    /// <summary>
    ///     Constains functions which create, update, remove and show data
    /// </summary>
    class Controller
    {
        List<Hospital> hospitals;
        List<Doctor> doctors;
        List<Patient> patients;
        List<PatientRecord> records;

        /// <summary>
        ///     Takes list of data to manipulate them
        /// </summary>
        /// <param name="hospitals"></param>
        /// <param name="doctors"></param>
        /// <param name="patients"></param>
        /// <param name="records"></param>
        public Controller(List<Hospital> hospitals, List<Doctor> doctors, List<Patient> patients,
            List<PatientRecord> records)
        {
            this.hospitals = hospitals;
            this.doctors = doctors;
            this.patients = patients;
            this.records = records;
        }

        /// <summary>
        ///     show all items regard to category
        /// </summary>
        /// <param name="category"></param>
        public void View(Category category)
        {
            switch (category)
            {
                case Category.HOSPITAL: 
                    ViewHospital();
                    break;
                case Category.DOCTOR: 
                    ViewDoctor();
                    break;
                case Category.PATIENT: 
                    ViewPatient();
                    break;
                case Category.RECORD: 
                    ViewRecord();
                    break;
                default:
                    ErrorMsg("Category cannot be found");
                    break;
            }
        }

        /// <summary>
        ///     Takes data from the view and delete it from list
        /// </summary>
        /// <param name="category"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public bool Delete(Category category, int choice)
        {
            switch (category)
            {
                case Category.HOSPITAL:
                    try
                    {
                        Hospital h = findHospital(choice);
                        SuccessMsg("Hospital " + h.Name + " Deleted");
                        hospitals.Remove(h);
                    }
                    catch (Exception)
                    {
                        ErrorMsg("Wrong ID. Hospital cannot be deleted");
                    }
                    break;
                case Category.DOCTOR:
                    try
                    {
                        Doctor d = findDoctor(choice);
                        SuccessMsg("Doctor " + d.Name + " Deleted");
                        doctors.Remove(d);
                    }
                    catch (Exception)
                    {
                        ErrorMsg("Wrong ID. Doctor cannot be deleted");
                    }
                    break;
                case Category.PATIENT:
                    try
                    {
                        Patient p = findPatient(choice);
                        SuccessMsg("Patient " + p.Name + " Deleted");
                        patients.Remove(p);
                    }
                    catch (Exception)
                    {
                        ErrorMsg("Wrong ID. Patient cannot be deleted");
                    }
                    break;
                case Category.RECORD:
                    try
                    {
                        PatientRecord r = findRecord(choice);
                        SuccessMsg("Record " + r.ID + " Deleted");
                        records.Remove(r);
                    }
                    catch (Exception)
                    {
                        ErrorMsg("Wrong ID. Record cannot be deleted");
                    }
                    break;
                default:
                    ErrorMsg("Wrong Category");
                    return false;
            }
            return true;
        }
        /// <summary>
        ///     Takes data from the view to create a new hospital and add it to the list of hospitals
        /// </summary>
        /// <param name="name"></param>
        /// <param name="license"></param>
        /// <param name="address"></param>
        public bool CreateHospital(string name, string license, string address)
        {
            if (!NameChecker(name) || !LicenseChecker(license, 'A') || !AddressChecker(address))
                return false;
            try
            {
                Hospital newHospital = new Hospital(name, license, address);
                hospitals.Add(newHospital);
                SuccessMsg("New Hospital Added:");
                SuccessMsg(newHospital.ToString());
                return true;
            }
            catch (Exception)
            {
                ErrorMsg("Hospital cannot be added due to some unknown exception, sorry");
                return false;
            }
        }
        /// <summary>
        ///     Takes data from the view to add a new doctor and add it to the list of doctors
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="license"></param>
        /// <param name="address"></param>
        public bool CreateDoctor(string name, string gender, string dob, string license, string address)
        {
            if (!NameChecker(name) || !GenderChecker(gender) || (DatetimeChecker(dob) == null)
                || (DatetimeChecker(dob).ToArray().Length != 3) || !LicenseChecker(license, 'D')
                || !AddressChecker(address)
                ) return false;
            try
            {
                DateTime date = new DateTime(DatetimeChecker(dob).ElementAt(0), DatetimeChecker(dob).ElementAt(1),
                    DatetimeChecker(dob).ElementAt(2));
                Doctor newDoctor = new Doctor(name, gender, date, license, address);
                doctors.Add(newDoctor);
                SuccessMsg("Doctor " + newDoctor.Name + " Added");
                return true;
            }
            catch (Exception)
            {
                ErrorMsg("Doctor cannot be added due to some unknown exception, sorry");
                return false;
            }
        }
        /// <summary>
        ///     Takes data from the view to add a new patient and add it to the list of patients
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="address"></param>
        public bool CreatePatient(string name, string gender, string dob, string address)
        {
            if (!NameChecker(name) || !GenderChecker(gender) || (DatetimeChecker(dob) == null)
                || (DatetimeChecker(dob).ToArray().Length != 3) || !AddressChecker(address)
                ) return false;
            try
            {
                DateTime date = new DateTime(DatetimeChecker(dob).ElementAt(0), 
                    DatetimeChecker(dob).ElementAt(1),
                    DatetimeChecker(dob).ElementAt(2));
                Patient newPatient = new Patient(name, gender, date, address);
                patients.Add(newPatient);
                SuccessMsg("Patient " + newPatient.Name + " Added");
                return true;
            }
            catch (Exception)
            {
                ErrorMsg("Patient cannot be added due to some unknown exception, sorry");
                return false;
            }            
        }
        /// <summary>
        ///     Takes data from the view to create a new reccord and add it to the list of records
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="doctor"></param>
        /// <param name="hospital"></param>
        /// <param name="diagnosis"></param>
        /// <param name="outcome"></param>
        public void CreateRecord(Patient patient, Doctor doctor, Hospital hospital, string diagnosis, Outcome outcome)
        {
            try
            {
                PatientRecord newRecord = new PatientRecord(patient, doctor, hospital, diagnosis, outcome);
                records.Add(newRecord);
            }
            catch (Exception)
            {
                ErrorMsg("Record cannot be added due to some exception, sorry");
            }
        }
        /// <summary>
        ///     show all the hospital
        /// </summary>
        public void ViewHospital()
        {
            foreach (Hospital h in hospitals)
            {
                Console.WriteLine(h.ToString());
            }
        }
        /// <summary>
        ///     show all doctors
        /// </summary>
        public void ViewDoctor()
        {
            foreach (Doctor d in doctors)
            {
                Console.WriteLine(d.ToString());
            }
        }
        /// <summary>
        ///     show all patients
        /// </summary>
        public void ViewPatient()
        {
            foreach (Patient p in patients)
            {
                Console.WriteLine(p.ToString());
            }
        }
        /// <summary>
        ///     show all patient records
        /// </summary>
        public void ViewRecord()
        {
            foreach (PatientRecord r in records)
            {
                Console.WriteLine(r.ToString());
            }
        }
        public bool UpdateName(Category category, int id, string newName)
        {
            if (!IsExist(category, id))
            {
                ErrorMsg("This ID does not belong to " + category.ToString());
                return false;
            }
            if (!NameChecker(newName)) return false;
            switch (category)
            {
                case Category.HOSPITAL:
                    Hospital h = findHospital(id);
                    h.Name = newName;
                    break;
                case Category.DOCTOR:
                    Doctor d = findDoctor(id);
                    d.Name = newName;
                    break;
                case Category.PATIENT:
                    Patient p = findPatient(id);
                    p.Name = newName;
                    break;           
                default:
                    ErrorMsg("This " + category.ToString() + "'s name cannot be modified or it doesn't have a name");
                    return false;
            }
            SuccessMsg("Name edited to " + newName);
            return true;
        }
        public bool UpdateAddress(Category category, int id, string newAddress)
        {
            if (!IsExist(category, id))
            {
                ErrorMsg("This ID does not belong to " + category.ToString());
                return false;
            }
            if (!AddressChecker(newAddress)) return false;
            switch (category)
            {
                case Category.HOSPITAL:
                    Hospital h = findHospital(id);
                    h.Address = newAddress;
                    break;
                case Category.DOCTOR:
                    Doctor d = findDoctor(id);
                    d.Address = newAddress;
                    break;
                case Category.PATIENT:
                    Patient p = findPatient(id);
                    p.Address = newAddress;                    
                    break;
                default:
                    ErrorMsg("This " + category.ToString() + "'s address cannot be modified or it doesn't have an address");
                    return false;
            }
            SuccessMsg("Address edited to " + newAddress);
            return true;
        }
        public bool UpdateLicense(Category category, int id, string newLicense)
        {
            if (!IsExist(category, id))
            {
                ErrorMsg("This ID does not belong to " + category.ToString());
                return false;
            }
            switch (category)
            {
                case Category.HOSPITAL:
                    if (!LicenseChecker(newLicense, 'A')) return false;
                    Hospital h = findHospital(id);
                    h.LicenseNmb = newLicense;
                    break;
                case Category.DOCTOR:
                    if (!LicenseChecker(newLicense, 'B')) return false;
                    Doctor d = findDoctor(id);
                    d.LicenseNmb = newLicense;
                    break;
                default:
                    ErrorMsg("This " + category.ToString() + "'s license cannot be modified or it doesn't have a license");
                    return false;
            }
            SuccessMsg("License edited to " + newLicense);
            return true;
        }        
        public bool UpdateGender(Category category, int id, string newGender)
        {
            if (!IsExist(category, id))
            {
                ErrorMsg("This ID does not belong to " + category.ToString());
                return false;
            }       
            if (!GenderChecker(newGender)) return false;
            switch (category)
            {
                case Category.DOCTOR:
                    Doctor d = findDoctor(id);
                    d.Gender = newGender;
                    break;
                case Category.PATIENT:
                    Patient p = findPatient(id);
                    p.Gender = newGender;
                    break;
                default:
                    ErrorMsg("This " + category.ToString() + "'s gender cannot be modified");
                    return false;
            }
            SuccessMsg("Gender edited to " + newGender);
            return true;
        }
        public bool UpdateDOB(Category category, int id, string newDOB)
        {
            if (!IsExist(category, id))
            {
                ErrorMsg("This ID does not belong to " + category.ToString());
                return false;
            }       
            if ( (DatetimeChecker(newDOB) == null) || DatetimeChecker(newDOB).ToArray().Length != 3 ) 
                return false;
            DateTime date = new DateTime(DatetimeChecker(newDOB).ElementAt(0),
                DatetimeChecker(newDOB).ElementAt(1), DatetimeChecker(newDOB).ElementAt(2));
            switch (category)
            {
                case Category.DOCTOR:
                    Doctor d = findDoctor(id);
                    d.DOB = date;
                    break;
                case Category.PATIENT:
                    Patient p = findPatient(id);
                    p.DOB = date;
                    break;
                default:
                    ErrorMsg("This " + category.ToString() + "'s doesn't have date of birth");
                    return false;
            }
            SuccessMsg("Date of birth edited to " + date.ToString("MMM dd yyyy"));
            return true;
        }
        /// <summary>
        ///     Take a category and an ID then check if the ID belong to the category or not
        /// </summary>
        /// <param name="category"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsExist(Category category, int ID)
        {
            switch (category)
            {
                case Category.HOSPITAL: foreach (Hospital h in hospitals)
                        if (h.ID == ID) return true;
                    return false;
                case Category.DOCTOR: foreach (Doctor d in doctors)
                        if (d.ID == ID) return true;
                    return false;
                case Category.PATIENT: foreach (Patient p in patients)
                        if (p.ID == ID) return true;
                    return false;
                case Category.RECORD: foreach (PatientRecord r in records)
                        if (r.ID == ID) return true;
                    return false;
                default: return false;
            }
        }
        /// <summary>
        ///     Takes patient ID and return the corresponding patient
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public Patient findPatient(int PatientID)
        {
            foreach (Patient p in patients)
            {
                if (p.ID == PatientID) return p;
            }
            return null;
        }
        /// <summary>
        ///     Takes doctor ID and return the corresponding doctor
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public Doctor findDoctor(int DoctorID)
        {
            try
            {
                foreach (Doctor d in doctors)
                {
                    if (d.ID == DoctorID) return d;
                }
            }
            catch (Exception) { }
            return null;
        }
        /// <summary>
        ///     Takes record ID and return the corresponding record
        /// </summary>
        /// <param name="RecordID"></param>
        /// <returns></returns>
        public PatientRecord findRecord(int RecordID)
        {
            foreach (PatientRecord r in records)
            {
                if (r.ID == RecordID) return r;
            }
            return null;
        }
        /// <summary>
        ///     Takes hospital ID and return the corresponding hospital
        /// </summary>
        /// <param name="HospitalID"></param>
        /// <returns></returns>
        public Hospital findHospital(int HospitalID)
        {
            try
            {
                foreach (Hospital h in hospitals)
                {
                    if (h.ID == HospitalID) return h;
                }
            }
            catch (Exception) { }
            return null;
        }

        public List<int> DatetimeChecker(string date)
        {
            int month = 0;
            int day = 0;
            int year = 0;
            List<int> mydate = new List<int>();
            string msg = "Invalid date format";
            string[] d = date.Split('/');
            if (d.Length != 3)
            {
                ErrorMsg(msg);
                return null;
            }
            try
            {
                month = Convert.ToInt32(d[0]);
                day = Convert.ToInt32(d[1]);
                year = Convert.ToInt32(d[2]);
            }
            catch (Exception)
            {
                ErrorMsg(msg);
                return null;
            }
            if (year > 2013 || year < 1900)
            {
                ErrorMsg(msg);
                return null;
            }
            try
            {
                new DateTime(year, month, day);
                mydate.Add(year);
                mydate.Add(month);
                mydate.Add(day);
            }
            catch (Exception)
            {
                ErrorMsg(msg);
                return null;
            }
            return mydate;
        }
        public bool GenderChecker(string gender)
        {
            if (!gender.ToLower().Equals("female") && !gender.ToLower().Equals("male") &&
                !gender.ToLower().Equals("unknown"))
            {
                ErrorMsg("Invalid Gender");
                return false;
            }
            return true;
        }
        public bool LicenseChecker(string license, char a)
        {
            if (license.Length != 9 || license.ElementAt(0) != a)
            {
                ErrorMsg("Invalid License");
                return false;
            }
            return true;
        }
        public bool NameChecker(string name)
        {
            if (name.Length < 5)
            {
                ErrorMsg("Invalid Name");
                return false;
            }
            return true;
        }
        public bool AddressChecker(string address)
        {
            if (address.Length < 5)
            {
                ErrorMsg("Invalid Address");
                return false;
            }
            return true;
        }
        public bool DiagnosisChecker(string diagnosis)
        {
            if (diagnosis.Length < 5)
            {
                ErrorMsg("Invalid Diagnosis");
                return false;
            }
            return true;
        }
        public void ErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.Write("Continue in 2s ");
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
            System.Threading.Thread.Sleep(1000);            
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void SuccessMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
