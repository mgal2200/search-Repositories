using GitHubExcersize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchGitHubMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("search",new List<RepoResult >());
        }

        public ActionResult Search(string term)
        {
            if (string.IsNullOrEmpty(term))
                return View(new List<RepoResult>());
            var ret =  SearchGitHubClient.SearchRepositories(term);
            return View(ret);
        }
        [HttpPost]
        public JsonResult Bookmark(RepoResult bookmarkRepo)
        {
            var repos = (List<RepoResult>)Session["repos"];
            if (repos == null)
            {
                repos = new List<RepoResult>();
            }
            repos.Add(bookmarkRepo);
            Session["repos"] = repos;
            return Json(repos);
        }
    }
}