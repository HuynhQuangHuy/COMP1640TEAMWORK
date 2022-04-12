using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TeamWork.Models
{
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public bool SecretPoll { get; set; }

    }
}