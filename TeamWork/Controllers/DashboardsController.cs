using TeamWork.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TeamWork.Controllers
{
	public class DashboardsController : Controller
	{
		private ApplicationDbContext _context;

		public DashboardsController()
		{
			_context = new ApplicationDbContext();
		}

		
		// GET: Dashboards
		[HttpGet]
		public ActionResult Index()
		{
			//Get all idea
			var listIdea = _context.Ideas.ToList();
		
			
			//Create new list
			List<int> dataIdeaInFac = new List<int>();
			
			

			//data
			var getItem = _context.Items.ToList();
			var getDepartment = _context.Departments.ToList();
			var departmenttype = listIdea.Select(p => p.Item.Department.Name).Distinct();
			

			//count Idea of each department
			foreach (var item in departmenttype)
			{
				dataIdeaInFac.Add(listIdea.Count(x => x.Item.Department.Name == item));
				
			}

			var analysisData = dataIdeaInFac;
			
			//X
			ViewBag.DEPARTMENTTYPE = departmenttype;
			//Y
			ViewBag.ANALYSISDATA = analysisData.ToList();
			//Y1
			

			return View();
		}

	
		public ActionResult PieChart()
		{
			//Get all Idea
			var listIdea = _context.Ideas.ToList();

			//Create new list
			List<int> dataIdeaInFac = new List<int>();

			/////////////fill faculty
			//data
			var getItem = _context.Items.ToList();
			var getDepartment = _context.Departments.ToList();
			var departmenttype = listIdea.Select(p => p.Item.Department.Name).Distinct();

			//count idea of each department
			foreach (var item in departmenttype)
			{
				dataIdeaInFac.Add(listIdea.Count(x => x.Item.Department.Name == item));

			}

			var analysisData = dataIdeaInFac;

			//X
			ViewBag.DEPARTMENTTYPE = departmenttype;
			//Y
			ViewBag.ANALYSISDATA = analysisData.ToList();
			//Y1
			return View();
		}

	}
}