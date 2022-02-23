using ClassWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassWebApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        private string _firstName;
        private string _lastName;
        private string _grade;
        private List<Assignment> _assignments;

        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public List<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }

        public static Student GetStudent(int id)
        {
            Student s;
            using (ClassContext context = new ClassContext())
            {
                s = context.Students.First(s => s.Id == id);
            }
            return s;
        }
        public static List<Student> GetAllStudentsList()
        {
            List<Student> list;
            using (ClassContext context = new ClassContext())
            {
                list = context.Students.ToList();
            }                
            return list;
        }

        internal void SaveStudent()
        {
            using (ClassContext context = new ClassContext())
            {
                if (this.Id.Equals(0))
                {
                    context.Students.Add(this);
                }
                else { context.Students.Update(this); }
                context.SaveChanges();
            }
        }

        internal static void DeleteStudent(int id)
        {
            using (ClassContext context = new ClassContext())
            {
                Student s = GetStudent(id);
                context.Students.Remove(s);
                context.SaveChanges();
            }
        }
    }
}
