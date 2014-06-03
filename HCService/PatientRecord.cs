using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCService
{
    /// <summary>
    ///     PatientRecord class keep patient's record every time they go to the hospital
    ///     PatientRecord contains: patient (Patient), doctor (Doctor), hospital (Hospital),
    ///     diagnosis (string), outcome (Outcome enum type)
    /// </summary>
    class PatientRecord
    {
        private static int count = 1;
        private int id;
        private Patient patient;
        private Doctor doctor;
        private Hospital hospital;
        private string diagnosis;
        private Outcome outcome;
        /// <summary>
        ///     parameter constructor
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="doctor"></param>
        /// <param name="hospital"></param>
        /// <param name="diagnosis"></param>
        /// <param name="outcome"></param>
        public PatientRecord(Patient patient, Doctor doctor, Hospital hospital, string diagnosis, Outcome outcome)
        {
            this.id = count;
            count++;
            this.patient = patient;
            this.doctor = doctor;
            this.hospital = hospital;
            this.diagnosis = diagnosis;
            this.outcome = outcome;
        }
        /// <summary>
        ///     return a formatted string which contains patient record details
        /// </summary>
        /// <returns></returns>
        override public String ToString()
        {
            string format = "MMM dd yyyy";
            return string.Format("Record Number {0, -3}-----------------------------------------------------------"
                + "\n{1, -12}{2,-15}{3,-10}{4,-12}Date of Birth {5,-12}"
                + "\n{6, -12}{7, -15}{8,-10}{9,-11} {10,-1} Hospital"
                + "\n{11, -12}{12,-15}{13,-10}{14,0}\n",
                id.ToString("000"), "Patient", patient.Name, "Gender", patient.Gender.ToUpper(), patient.DOB.ToString(format),
                "Doctor", doctor.Name, "License", doctor.LicenseNmb, hospital.Name,
                "Diagnosis", diagnosis, "Outcome", outcome.ToString());
        }
        /// <summary>
        ///     properties
        /// </summary>
        public int ID
        {
            get { return id; }
        }
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }
        public Hospital Hospital
        {
            get { return hospital; }
            set { hospital = value; }
        }
        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }
        public Outcome Outcome
        {
            get { return outcome; }
            set { outcome = value; }
        }
    }
}
