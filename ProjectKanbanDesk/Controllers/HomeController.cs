using Microsoft.AspNetCore.Mvc;
using ProjectKanbanDesk.Models;

namespace ProjectKanbanDesk.Controllers
{
    public class HomeController : Controller
    {
        StoryContext db;
        public HomeController(StoryContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        [HttpGet]
        public IActionResult GetStory(int Id)
        {
            ViewBag.StoryId = Id;
            return View();
        }

        [HttpPost]
        public IActionResult PostStory(Story story)
        {
            db.Stories.AddAsync(story);
            db.SaveChangesAsync();
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteStory(Story story)
        {
            db.Stories.Remove(story);
            db.SaveChangesAsync();
            return View();

        }

        [HttpPut]
        public IActionResult PutStory(Story storyData)
        {
            var story = db.Stories.FirstOrDefault(s => s.Id == storyData.Id);
            story.Name = storyData.Name;
            story.Description = storyData.Description;
            story.Status = storyData.Status;
            db.SaveChangesAsync();
            return View();
        }
    }
}
