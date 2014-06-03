using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCService
{
    enum Outcome
    {
        CURED,
        DECREASED,
        INCREASED,
        UNCHANGED,
        DIED
    };
    enum Category
    {
        HOSPITAL,
        DOCTOR,
        PATIENT,
        RECORD,
        NONE
    };
    class Program
    {
        static void Main(string[] args)
        {
            List<Hospital> hospitals = new List<Hospital>(){
            new Hospital("Ancora Psychiatric", "A32CB9ONN", "416 Water St."),
            new Hospital("Bayshore Community", "A98HN89PK", "45 Park Avenue"),
            new Hospital("Essex County", "A78YU99OP", "213 Baker St."),
            new Hospital("Jersey Shore", "A00CB96HK", "16 Madison Avenue"),
            new Hospital("Bayonne", "A12BN45CK", "77 Malcolm X Boulevard"),
            new Hospital("Chilton Memorial", "A44OU89IL", "666 Rivington St."),
            new Hospital("Columbus", "A00CB96HK", "71 Monroe St."),
            new Hospital("Children Specialized", "A52BF43LB", "450 Saint Nicholas Avenue"),
            new Hospital("East Orange", "A47OG80IM", "28 Varick St."),
            new Hospital("Greenville", "A70CN94MM", "21 Nassau Avenue")
            };
            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor("Kate Le", "Female", new DateTime(1980, 09, 27), "D9000CA88", "152 Smith St."),
            new Doctor("Edward Smith", "Male", new DateTime(1978, 04, 15), "D8970GB70", "4 New York Plaza"),
            new Doctor("Sarah Ken", "Female", new DateTime(1960, 03, 16), "D9100CA88", "15 Monroe St."),
            new Doctor("Amira Jackson", "Male", new DateTime(1988, 07, 22), "D8970GB71", "7 Varick St."),
            new Doctor("Ace Miller", "Female", new DateTime(1980, 07, 14), "D9000CA82", "111 Malcolm St."),
            new Doctor("Alex Baker", "Male", new DateTime(1975, 12, 5), "D8970GB74", "47 Madison St."),
            new Doctor("Kathy Nelson", "Female", new DateTime(1986, 11, 3), "D9000CB88", "33 Brooklyn"),
            new Doctor("Josh Adam", "Male", new DateTime(1974, 02, 5), "D8900HB70", "90 Nassau Boulevard"),
            new Doctor("Makayla Scott", "Female", new DateTime(1978, 07, 6), "D9000CJ88", "23 Rivington St."),
            new Doctor("Taylor King", "Male", new DateTime(1973, 12, 18), "D8970KB70", "75 Baker St.")
            };
            List<Patient> patients = new List<Patient>()
            {
                new Patient("Gabe Brown", "Male", new DateTime(1999, 03, 01), "312 Brooklyn"),
            new Patient("Charlie Wentz", "Female", new DateTime(2002, 07, 24), "120 Lenox Avenue"),
            new Patient("Gary Walker", "Male", new DateTime(1969, 04, 03), "40 Saint Nicholas St."),
            new Patient("Allison Gray", "Female", new DateTime(1995, 06, 24), "31 Brooklyn"),
            new Patient("Riley Lewis", "Male", new DateTime(1970, 12, 8), "20 Madison Avenue"),
            new Patient("Camila Hall", "Female", new DateTime(2005, 07, 29), "15 Newyork Plaza"),
            new Patient("Spencer Cox", "Male", new DateTime(1985, 08, 16), "590 Park Avenue"),
            new Patient("Arianna Morris", "Female", new DateTime(2008, 04, 24), "61 Water St."),
            new Patient("Andrey Evans", "Male", new DateTime(1977, 11, 15), "475 Malcolm St."),
            new Patient("Victoria Perez", "Female", new DateTime(2009, 06, 25), "690 Newyork Avenue")
            };
            List<PatientRecord> records = new List<PatientRecord>()
            {
                new PatientRecord(patients.ElementAt(0), doctors.ElementAt(0), hospitals.ElementAt(0), "D37.201A", Outcome.CURED),
                new PatientRecord(patients.ElementAt(2), doctors.ElementAt(3), hospitals.ElementAt(4), "D35.2", Outcome.DECREASED),
                new PatientRecord(patients.ElementAt(3), doctors.ElementAt(5), hospitals.ElementAt(2), "A40.7", Outcome.DIED),
                new PatientRecord(patients.ElementAt(4), doctors.ElementAt(7), hospitals.ElementAt(3), "B33.4x20", Outcome.INCREASED),
                new PatientRecord(patients.ElementAt(5), doctors.ElementAt(8), hospitals.ElementAt(7), "C45.4", Outcome.UNCHANGED),
                new PatientRecord(patients.ElementAt(6), doctors.ElementAt(1), hospitals.ElementAt(8), "X20.20A", Outcome.DECREASED),
                new PatientRecord(patients.ElementAt(7), doctors.ElementAt(4), hospitals.ElementAt(9), "M30.4", Outcome.CURED),
                new PatientRecord(patients.ElementAt(8), doctors.ElementAt(9), hospitals.ElementAt(6), "S89.987G", Outcome.DIED),
                new PatientRecord(patients.ElementAt(9), doctors.ElementAt(6), hospitals.ElementAt(5), "M12.123", Outcome.INCREASED),
                new PatientRecord(patients.ElementAt(5), doctors.ElementAt(2), hospitals.ElementAt(1), "D15.78", Outcome.UNCHANGED)
            };
            Controller controller = new Controller(hospitals, doctors, patients, records);
            View view = new View(controller);
            Console.Read();
        }
    }
}
