using GlobaLab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GlobaLab2.Controllers
{
    public class GoodsController : Controller
    { 
	    GlobaLab2Context dbContext;

	    public GoodsController(GlobaLab2Context context)
	    {
            dbContext = context;
	    }

		public async Task<IActionResult> Goods()
		{
			var content = await dbContext.Goods.ToListAsync();
			if (content != null)
			{
				return View(content);
			}
			else
			{
				throw new ExecutionEngineException("нет значения из бд");
			}
			return View(await dbContext.Goods.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Good good)
		{
			dbContext.Goods.Add(good);
			await dbContext.SaveChangesAsync();
			return RedirectToAction("Goods");
		}
	}
}
