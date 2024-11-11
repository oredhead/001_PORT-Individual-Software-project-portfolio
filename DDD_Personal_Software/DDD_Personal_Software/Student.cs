using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Personal_Software
{
  

    internal class PersonalSupervisor
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }

        public List<Student> Students;
        public List<Booking> Bookings;

        public PersonalSupervisor(string aForename, string aSurname, string aPassword, int iD)
        {
            this.Forename = aForename;
            this.Surname = aSurname;
            this.Password = aPassword;
            this.ID = iD;
            Students = new List<Student>();
            Bookings = new List<Booking>();
        }
    }
    internal class Student
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int StudentID { get; set; }
        public PersonalSupervisor Supervisor { get; set; }

        public Student(string aForename, string aSurname, string aPassword, PersonalSupervisor aSupervisor, int aStudentID)
        {
            this.Forename = aForename;
            this.Surname = aSurname;
            this.Password = aPassword;
            this.Supervisor = aSupervisor;
            this.StudentID = aStudentID;
        }
    }

    internal class SeniorTutor
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int ID { get; set; }
        public List<Student> Students { get; set; }
        public SeniorTutor(string aForename,string aSurname,int aID)
        {
            this.Forename = aForename;
            this.Surname = aSurname;
            this.ID = aID;
            this.Students = new List<Student>();
        }
    }
}
