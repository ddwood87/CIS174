using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;

namespace ToDoApp.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        private string _name;
        public string Name { 
            get { 
                if (SprintId < 0){ return _name; }
                else{ return "Sprint " + SprintId; }
            } 
            set { _name = value; }
        }

        public DateTime? DueDate { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public bool Overdue => DueDate < DateTime.Today;
            
    } 
    public class Status
    {
        public string StatusId { get; set; }
        public string Name { get; set; }
    }
    public class Ticket
    {
        public static readonly int[] PossPoints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a ticket name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        [ValidatePoints]
        //[Required(ErrorMessage = "Please enter a point value.")]        
        public int? Points { get; set; }
        [ValidateSprintId]
        //[Required(ErrorMessage = "Required")]
        public int? SprintId { get; set; }
        [ForeignKey("SprintId")]
        public Sprint Sprint { get; set; }
        [Required(ErrorMessage = "Please enter a status.")]
        public string StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        [NotMapped]
        public bool Overdue =>  Status?.Name.ToLower() != "done" && Sprint?.Overdue == true; 
    }
}
