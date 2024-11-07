using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Personal_Software
{
    internal class Booking
    {
        public Student BookedStudent {  get; set; }
        public PersonalSupervisor BookedPs {  get; set; }
        public string BookingTime { get; set; }

        public Booking(Student aStudent, PersonalSupervisor aPs, string aTime)
        {
            this.BookedStudent = aStudent;
            this.BookedPs = aPs;
            this.BookingTime = aTime;
        }
    }
}
