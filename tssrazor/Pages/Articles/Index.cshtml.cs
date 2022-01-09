using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities.Contents;
using tssrazor.Repositories;
using tssrazor.UIComponents;

namespace tssrazor.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private ArticleRepository articleRepository;

		public IndexModel()
		{
            articleRepository = new ArticleRepository();
            //PageSize = 2;
            //TotalCount = articleRepository.Count;
            PaginationBar = new Pagination()
            {
                PageSize = 2,
                TotalCount = articleRepository.Count
            };
		}

        public IList<Article> Articles { get; set; }

        //public int PageIndex { get; set; }

        //public int PageSize { get; set; }

        //public int TotalCount { get; set; }

        //public int PageNumber { get; set; }

        public Pagination PaginationBar { get; set; }

        public void OnGet()
        {
            //PageIndex = int.Parse(Request.Query["pageIndex"][0]);
            //PageIndex = Convert.ToInt32(RouteData.Values["pageIndex"]);

            //PageNumber = (int)Math.Ceiling((double)TotalCount / PageSize);

            //Articles = articleRepository.GetList(PageIndex, PageSize);

            PaginationBar.PageIndex = Convert.ToInt32(RouteData.Values["pageIndex"]);
            PaginationBar.PageNumber = (int)Math.Ceiling((double)PaginationBar.TotalCount / PaginationBar.PageSize);
            Articles = articleRepository.GetList(PaginationBar.PageIndex, PaginationBar.PageSize);
        }
    }
}
