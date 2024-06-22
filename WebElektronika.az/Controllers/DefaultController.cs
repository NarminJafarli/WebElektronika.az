using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using WebElektronika.az.Business.Abstract;
using WebElektronika.az.DTO;

namespace WebElektronika.az.Controllers
{
    public class DefaultController : Controller
    {
		private readonly ITechnologyServices _technologyServices;

		public DefaultController(ITechnologyServices technologyServices)
		{
			_technologyServices = technologyServices;
		}

		public IActionResult Index()
        {
			var values=_technologyServices.GetAll();
            return View(values);
        }
        
        [HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(TechnologyDTO p)
		{
			_technologyServices.Insert(p);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(int id)
		{
			var values= _technologyServices.GetByID(id);
			return View(values);	
		}

		[HttpPost]

		public IActionResult Update(TechnologyDTO p) 
		{ 
			_technologyServices.Update(p);
			return RedirectToAction("Index");			
		}

		public IActionResult Delete(int id)
		{
			_technologyServices.Delete(id);
			return RedirectToAction("Index");
		}


	}

}
