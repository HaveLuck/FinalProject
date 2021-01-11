using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBigBlog.Models;

namespace WebBigBlog.Controllers
{
    public class TopicController : Controller
    {
        TopicDBAccessLayer bus = new TopicDBAccessLayer();

        [HttpGet]
        public IActionResult GetListTopic()
        {
            var res = bus.GetListTopic();
            return Json(res);
        }
        public IActionResult Index()
        {
           
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(string topicName, string description = "")
        {
            TopicModel obj = new TopicModel();
            obj.Name_Topic = topicName;
            obj.Description_Topic = description;
            var res = bus.AddNewTopic(obj);
            if (res == 1)
            {
                return Json(TempData["msg"] = "Add new Topic Successfull");
            }
            else
            {
                return Json(TempData["msg"] = "Add new Topic Failure");
            }
        }
        [HttpGet]
        public IActionResult EditTopic(int id)
        {
            var res = bus.GetTopicByID(id);
            return View(res);
        }
        [HttpPost]
        public IActionResult EditTopic(TopicModel model)
        {
            var res = bus.EditTopic(model);
            if (res == 1)
            {
                TempData["msg"] = "Add new Topic Successfull";
            }
            else
            {
                TempData["msg"] = "Add new Topic Failure";
            }

            return View();
        }
       
        //[HttpGet]
        //public IActionResult DeleteTopic(int id)
        //{
        //    var res = bus.GetTopicByID(id);
        //    return View(res);
        //}
        [HttpPost]
        public IActionResult DeleteTopic(int id, string username = "")
        {
        
            var res = bus.DeleteTopic(id);
           
            if (res == 1)
            {
                return Json(TempData["msg"] = "Delete Topic Successfull");
            }
            else
            {
                return Json(TempData["msg"] = "Delete Topic Failure");
            }
        }
        [HttpGet]
        public IActionResult DetailTopic(int id)
        {
            return View();
        }
    }
}
