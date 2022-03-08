using System;
namespace TeamWork.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Decription { get; set; }



    }
}