using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities.Contents;
using tssrazor.Repositories;

namespace tssrazor.Pages.Articles
{
    public class ArticleModel : PageModel
    {
        private ArticleRepository articleRepository;

		public ArticleModel()
		{
            articleRepository = new ArticleRepository();
        }

        public Article Article { get; set; }

        public void OnGet()
        {
            //int id = int.Parse(Request.Query["id"][0]);
            //int id = int.Parse((string)RouteData.Values["id"]);
            int id = Convert.ToInt32(RouteData.Values["id"]);
            Article = articleRepository.Find(id);
        }
    }
}
