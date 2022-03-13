using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TeamWork.Models
{
    public class FileClass
    {
        [Key]
        public int FileClassId { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
    }
}