using TeamWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWork.ViewModels
{
	public class CommentPostViewModel
	{
		public Idea Idea { get; set; }
		public Comment Comment { get; set; }
	}
}