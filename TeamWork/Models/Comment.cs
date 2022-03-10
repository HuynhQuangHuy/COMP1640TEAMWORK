using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamWork.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int IdeaId { get; set; }
        [ForeignKey("IdeaId")]
        public Idea Idea { get; set; }

        

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}