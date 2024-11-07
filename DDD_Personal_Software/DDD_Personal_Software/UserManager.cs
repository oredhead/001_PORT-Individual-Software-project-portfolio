using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Personal_Software
{
    internal class UserManager
    {
        public List<Student> Students { get; set; }
        public List<PersonalSupervisor> PersonalSupervisors { get; set; }
        public UserManager(List<Student> aStudents, List<PersonalSupervisor> aPersonalSupervisors)
        {
            this.Students = aStudents;
            this.PersonalSupervisors = aPersonalSupervisors;
        }
    }
}
