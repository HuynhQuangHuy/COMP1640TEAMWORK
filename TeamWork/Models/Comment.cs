using System.ComponentModel.DataAnnotations;

namespace TeamWork.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
        public string Description { get; set; }
    }
}