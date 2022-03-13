using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class FileUpload
    {
        [Key]
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<FileUpload> FileList { get; set; }
    }
}