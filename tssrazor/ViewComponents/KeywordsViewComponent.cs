using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tssrazor.Entities;
using tssrazor.Repositories;

namespace tssrazor.ViewComponents
{
	public class KeywordsViewComponent : ViewComponent
	{
		private KeywordRepository keywordRepository;

		public KeywordsViewComponent()
		{
			keywordRepository = new KeywordRepository();
		}

		public IList<Keyword> Keywords { get; set; }

		public IViewComponentResult Invoke(int skipCount, int takeCount)
		{
			Keywords = keywordRepository.GetList(skipCount, takeCount);
			return View("_Keywords", Keywords);
		}
	}
}
