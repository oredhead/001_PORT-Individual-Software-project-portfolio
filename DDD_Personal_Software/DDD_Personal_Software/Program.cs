using DDD_Personal_Software;
using System.Globalization;
UserManager ReadUserInfo()
{
    string studentPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\Students.txt"));
    string psPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\PersonalSupervisors.txt"));
    string bookingPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\Bookings.txt"));

    string[] sLines = File.ReadAllLines(studentPath);
    string[] psLines = File.ReadAllLines(psPath);
    string[] bookingLines = File.ReadAllLines(bookingPath);

    List<PersonalSupervisor> supervisors = new List<PersonalSupervisor>();
    List<Student> students = new List<Student>();
    //Read the file and add each personal supervisor to the manager
    foreach (string line in psLines)
    {
        string[] ps = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        PersonalSupervisor personalSupervisor = new PersonalSupervisor(ps[0], ps[1], ps[2], int.Parse(ps[3]));
        supervisors.Add(personalSupervisor);

    }
    //Read the file and add every student to the manager
    foreach (string line in sLines)
    {
        string[] s = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        int psID = int.Parse(s[3]);
        PersonalSupervisor ps = supervisors.Find(x => x.ID == psID);
        Student student = new Student(s[0], s[1], s[2], ps, int.Parse(s[4]));
        students.Add(student);
    }
    //Check and add each student with the personal supervisor's ID to the personal suoervisor's list of students
    foreach (PersonalSupervisor supervisor in supervisors)
    {
        foreach (Student student in students)
        {
            if (student.Supervisor.ID == supervisor.ID)
            {
                supervisor.Students.Add(student);
            }
            
        }
    }

    foreach (string line in bookingLines)
    {
        string[] b = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
        int sID = int.Parse(b[0]);
        Student student = students.Find(x => x.StudentID == sID);
        int psID = int.Parse(b[1]);
        PersonalSupervisor supervisor = supervisors.Find(x => x.ID == psID);
        string time = b[2];
        Booking booking = new Booking(student, supervisor,time);
        supervisor.Bookings.Add(booking);
    }

    UserManager manager = new UserManager(students,supervisors);
    return manager;
}
UserManager manager = ReadUserInfo();
#region //All Program Methods
void SelectUserType(UserManager manager)
{
    bool pass = false;
    while (!pass)
    {
        Console.Clear();
        Console.WriteLine("Please select an option between 1 and 5 (inclusive)");
        Console.WriteLine("1:Login as a student");
        Console.WriteLine("2:Login as a personal supervisor");
        Console.WriteLine("3:Login as a senior tutor");
        Console.WriteLine("4:Register new user");
        Console.WriteLine("5:Exit");
        string selection = Console.ReadLine();
        if (selection == "1")
        {
            pass = true;
            StudentLogin(manager);
        }
        else if (selection == "2")
        {
            pass = true;
            PersonalSupervisorLogin(manager);
        }
        else if (selection == "3")
        {
            pass = true;
            SeniorTutorLogin(manager);
        }
        else if (selection == "4")
        {
            pass = true;
            RegisterNewUser(manager);
        }
        else if (selection == "5")
        {
            pass = true;
            Environment.Exit(0);
        }
    }
    
}

#region // All student based interaction
void StudentLogin(UserManager manager)
{
    Console.Clear();
    Console.WriteLine("Please enter your first name, followed by your password (case sensitive)");
    string user = Console.ReadLine();
    string password = Console.ReadLine();
    foreach (Student student in manager.Students)
    {
        if (student.Forename == user && student.Password == password)
        {
            StudentMainMenu(manager, student);
        }
    }
    Console.WriteLine("Invalid username or password,press anything to continue"); 
    Console.ReadLine(); 
    StudentLogin(manager);


}
void StudentMainMenu(UserManager manager, Student student)
{
    
        Console.Clear();
        Console.WriteLine($"Hello, {student.Forename}! What would you like to do? (Please select an option between 1 and 4 inclusive)");
        Console.WriteLine("1:Check your information");
        Console.WriteLine("2:Write a report");
        Console.WriteLine("3:Book an oppointment with personal supervisor");
        Console.WriteLine("4:Logout");
        string selection = (Console.ReadLine());
        if (selection == "1")
        {
            DisplayStudentInfo(manager, student);
        }
        else if (selection == "2")
        {
            WriteReport(manager, student);
        }
        else if (selection == "3")
        {
            BookAppointmentStudent(manager, student);
        }
        else if (selection == "4")
        {
            SelectUserType(manager);
        }
        else { Console.WriteLine("Invalid name or password"); StudentMainMenu(manager, student); }
    
    
}
void DisplayStudentInfo(UserManager manager, Student student)
{
    Console.Clear();
    Console.WriteLine($"Student ID:{student.StudentID}");
    Console.WriteLine($"Forename:{student.Forename}");
    Console.WriteLine($"Surname:{student.Surname}");
    Console.WriteLine($"Personal Supervisor:{student.Supervisor.Forename} {student.Supervisor.Surname}");
    Console.WriteLine("Press anything to go back...");
    Console.ReadLine();
    StudentMainMenu(manager, student);
}
void WriteReport(UserManager manager, Student student)
{
    Console.Clear();
    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info"));
    string[] scores = { "1", "2", "3", "4", "5" };
    Console.WriteLine("How satisfied are you with your course so far? (1-5 inclusive)");
    var courseScore = Console.ReadLine();

    
}
void BookAppointmentStudent(UserManager manager, Student student)
{
    Console.Clear();
    string currentTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\Bookings.txt"));
    String logPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\ActivityLog.txt"));
    string selectTime = "08:00";
    Console.WriteLine("Please select an appointment time (1 to 10 inclusive)");
    Console.WriteLine("1:08:00");
    Console.WriteLine("2:09:00");
    Console.WriteLine("3:10:00");
    Console.WriteLine("4:11:00");
    Console.WriteLine("5:12:00");
    Console.WriteLine("6:13:00");
    Console.WriteLine("7:14:00");
    Console.WriteLine("8:15:00");
    Console.WriteLine("9:16:00");
    Console.WriteLine("10:17:00");
    var select = Console.ReadLine();
    if (select == "1")
    {
        selectTime = "08:00";
    }
    else if (select == "2")
    {
        selectTime = "09:00";
    }
    else if (select == "3")
    {
        selectTime = "10:00";
    }
    else if (select == "4")
    {
        selectTime = "11:00";
    }
    else if (select == "5")
    {
        selectTime = "12:00";
    }
    else if (select == "6")
    {
        selectTime = "13:00";
    }
    else if (select == "7")
    {
        selectTime = "14:00";
    }
    else if (select == "8")
    {
        selectTime = "15:00";
    }
    else if (select == "9")
    {
        selectTime = "16:00";
    }
    else if (select == "10")
    {
        selectTime = "17:00";
    }
    else { Console.WriteLine("Invalid selection, press anything to continue..."); Console.ReadLine(); BookAppointmentStudent(manager,student); }

    foreach (PersonalSupervisor supervisor in manager.PersonalSupervisors)
    {
        if (student.Supervisor == supervisor)
        {
            foreach (Booking booking in supervisor.Bookings)
            {
                if (booking.BookingTime == selectTime)
                {
                    Console.WriteLine("Sorry, this time is unavailable, please try another");
                    Console.ReadLine();
                    BookAppointmentStudent(manager, student);
                }
                else { break; }
            }
        }
    }

    Booking newBooking = new Booking(student, student.Supervisor, selectTime);
    StreamWriter sw = File.AppendText(path);
    StreamWriter logsw = File.AppendText(logPath);
    sw.WriteLine($"{student.StudentID},{student.Supervisor.ID},{newBooking.BookingTime}");
    logsw.WriteLine($"{student.Forename} {student.Surname} ID:{student.StudentID} has booked an appointment with supervisor {student.Supervisor.Forename} {student.Supervisor.Surname} ID:{student.Supervisor.ID} for {selectTime} at {currentTime}");
    Console.WriteLine($"Successfully booked a meeting with {student.Supervisor.Forename} at {newBooking.BookingTime}");
    sw.Close();
    logsw.Close();
}
#endregion
#region // All personal supervisor based interaction
void PersonalSupervisorLogin(UserManager manager)
{
    PersonalSupervisor currentPs = null;
    Console.WriteLine("Please enter your first name, followed by your password (case sensitive)");
    string user = Console.ReadLine();
    string password = Console.ReadLine();
    foreach (PersonalSupervisor ps in manager.PersonalSupervisors)
    {
        if (ps.Forename == user && ps.Password == password)
        {
            currentPs = ps;
        }
    }
}
#endregion
#region// All senior tutor based interaction
void SeniorTutorLogin(UserManager manager)
{

}
#endregion
#region //Register new users
void RegisterNewUser(UserManager manager)
{
    Console.WriteLine("Please select an option between 1 and 4 (inclusive)");
    Console.WriteLine("1:Register a student");
    Console.WriteLine("2:Register a new personal supervisor");
    Console.WriteLine("3:Register a new senior tutor");
    Console.WriteLine("4:Go back");
    int selection = int.Parse(Console.ReadLine());
    if (selection == 1)
    {
        RegisterNewStudent(manager);
    }
    else if (selection == 2)
    {
        RegisterNewPs(manager);
    }
    else if (selection == 3)
    {
        RegisterNewSt(manager);
    }
    else if (selection == 4)
    {
        SelectUserType(manager);
    }
}
void RegisterNewStudent(UserManager manager)
{
    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Users Info\Students.txt"));
    StreamWriter sw = File.AppendText(path);
    Console.WriteLine("Please enter the new student's first name(s)");
    string forename = Console.ReadLine();
    Console.WriteLine("Please enter the new student's last name");
    string surname = Console.ReadLine();
    Console.WriteLine("Please enter a password for the new student");
    string password = Console.ReadLine();
    Console.WriteLine("Please enter the id of the new student's personal supervisor");
    string id = Console.ReadLine();

    string userReg = ($"{forename},{surname},{password},{id},{manager.Students.Count+1}");
    sw.WriteLine(userReg);
    sw.Close();

    Console.WriteLine($"The new student {forename} has been registered. Please restart the application to view changes");
    Console.ReadLine();
    Environment.Exit(0);
}
void RegisterNewPs(UserManager manager)
{

}
void RegisterNewSt(UserManager manager)
{

}
#endregion
#endregion

//Start the program
SelectUserType(manager);