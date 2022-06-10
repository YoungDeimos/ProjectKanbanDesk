using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectKanbanDesk.Models;

namespace ProjectKanbanDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        ApplicationContext db;
        public StoryController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<Story>> GetStory(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var stories = db.Stories.Include(s => s.User).ToList();
            return Ok(stories);
        }
        [HttpPost]
        public async Task<ActionResult<Story>> PostStory(Story story)
        {
            if (story == null)
            {
                return BadRequest();
            }

            db.Stories.Add(story);
            await db.SaveChangesAsync();
            return Ok(story);
        }
        [HttpPut]
        public async Task<ActionResult<Story>> PutStory(Story story)
        {
            if (story == null)
            {
                return BadRequest();
            }

            if (!db.Stories.Any(u => u.Id == story.Id))
            {
                return NotFound();
            }
            
            db.Update(story);
            await db.SaveChangesAsync();
            return Ok(story);
        }
        [HttpDelete]
        public async Task<ActionResult<Story>> DeleteStory(int id)
        {
            Story story = db.Stories.FirstOrDefault(s => s.Id == id);
            if (story == null)
            {
                return NotFound();
            }
            db.Stories.Remove(story);
            await db.SaveChangesAsync();
            return Ok(story);
        }

    }
}
