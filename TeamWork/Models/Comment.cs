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

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsLike { get; set; }

        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }

    }
}