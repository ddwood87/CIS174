using ClassWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassWebApp.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        private string _name;
        private int _module;
        private string _appLink;
        private string _gitLink;

        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required]
        public int Module
        {
            get { return _module; }
            set { _module = value; }
        }
        public string AppLink
        {
            get { return _appLink; }
            set { _appLink = value; }
        }

        public string GitLink
        {
            get { return _gitLink; }
            set { _gitLink = value; }
        }

        internal static List<Assignment> GetAllAssignmentsList(Student student)
        {
            List<Assignment> list;
            list = student.Assignments;
            return list;
        }
    }
}
