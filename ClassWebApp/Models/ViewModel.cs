using ClassWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Areas.Admin.Models;
namespace ClassWebApp.Models
{
    public class ViewModel
    {
        //private int _studentId;
        private Student _student;
        private List<Student> _students;        
        private User _user;
        //private List<User> _users;
        private int _accessLevel;

        public ViewModel()
        {
            _student = new Student();
            _user = new User();
            GetStudents();
        }
        public ViewModel(Student student)
        {
            _student = student;
            GetStudents();     
        }


        //public int StudentId { get; set; }
        public List<Student> Students { get; set; }
        public Student Student
        {
            get { return _student; }
            set { _student = value; }
        }
        public int StudentId
        {
            get { return _student.Id; }
            set { _student.Id = value; }
        }
        public string StudentFirstName
        {
            get { return _student.FirstName; }
            set { _student.FirstName = value; }
        }
        public string StudentLastName
        {
            get { return _student.LastName; }
            set { _student.LastName = value; }
        }
        public string StudentGrade
        {
            get { return _student.Grade; }
            set { _student.Grade = value; }
        }
        
        public List<Assignment> StudentAssignments
        {
            get { return _student.Assignments; }
            set { _student.Assignments = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string UserName
        {
            get { return _user.UserName; }
            set { _user.UserName = value; }
        }
        public string UserPassword
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }
        public int UserAccessLevel 
        { 
            get { return _user.AccessLevel; }
            set { _user.AccessLevel = value; }
        }

        public void GetStudents()
        {
            Students = Student.GetAllStudentsList();
        }
        private Student GetStudentById(int studentId)
        {
            return Students.First(s => s.Id == studentId);
        }
    }
}
