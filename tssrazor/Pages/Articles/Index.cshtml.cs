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
    public class IndexModel : PageModel
    {
        private ArticleRepository articleRepository;

		public IndexModel()
		{
            articleRepository = new ArticleRepository();
            PageSize = 2;
            TotalCount = articleRepository.Count;
		}

        public IList<Article> Articles { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public void OnGet()
        {
            //PageIndex = int.Parse(Request.Query["pageIndex"][0]);
            PageIndex = Convert.ToInt32(RouteData.Values["pageIndex"]);

            PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

            Articles = articleRepository.GetList(PageIndex, PageSize);
        }
    }
}
