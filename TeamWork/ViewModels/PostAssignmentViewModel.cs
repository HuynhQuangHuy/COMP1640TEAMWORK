using TeamWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWork.ViewModels
{
	public class PostAssignmentViewModel
	{
		public Idea Idea { get; set; }
		public Item Item { get; set; }

		public IEnumerable<Item> Items { get; set; }
		public IEnumerable<Idea> Ideas { get; set; }

		public int StatusPost { get; set; }
	}
}