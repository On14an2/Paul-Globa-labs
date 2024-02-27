using GlobaLab2.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobaLab2.ViewModels
{
    public class IndexViewModel
    {
        GlobaLab2Context dbContext;
        
        public List<Good> Goods;

        public IndexViewModel(GlobaLab2Context context)
        {
            dbContext = context;

            
        }

        public Task<List<Good>> getGoot()
        {
            Goods = dbContext.Goods.ToList();
        }
    }
}
