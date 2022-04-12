using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamWork.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CreateBy { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoordinatorId { get; set; }
        public ApplicationUser Coordinator { get; set; }
        public string Limitation
        {
            get { return StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString(); }

        }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}