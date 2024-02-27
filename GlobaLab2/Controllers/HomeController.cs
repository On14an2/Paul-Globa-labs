using GlobaLab2.Models;
using GlobaLab2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobaLab2.Controllers
{

    public class HomeController : Controller
    {
        GlobaLab2Context dbContext;
        private IndexViewModel model;

        public HomeController(GlobaLab2Context context)
        {
            dbContext = context;
            //IndexViewModel model = new IndexViewModel(context);
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel(dbContext);

            return View(model);
        }
    }
}
