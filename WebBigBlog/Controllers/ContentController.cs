using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBigBlog.Models;

namespace WebBigBlog.Controllers
{
    public class ContentController : Controller
    {
        ContentDBAccessLayer bus = new ContentDBAccessLayer();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewContent(string content)
        {
            string Author = "1";
            string Tittle = "name tittle";
            int topicID = 1;
            ContentModel obj = new ContentModel();
            obj.AuthorID = Author;
            obj.Content = content;
            obj.Tittle = Tittle;
            obj.Topic_ID = topicID;
            var res = bus.AddNewContent(obj);
            if (res == 1)
            {
                return Json(TempData["msg"] = "Add Content Successfull");
            }
            else
            {
                return Json(TempData["msg"] = "Add Content Failure");
            }
        }
        [HttpGet]
        public IActionResult GetPost(int id = 13)
        {
            var res = bus.GetAnPost(id);
            return Json(res);
        }
        public IActionResult ViewContent()
        {
            return View();
        }
    }
}
