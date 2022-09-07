using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace simple_todo_backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ToolController: ControllerBase
    {
        private readonly TodoContext _db;
        public ToolController(TodoContext db)
        {
            _db = db;
        }

        [HttpGet("Init")]
        public void Init()
        {
            _db.Database.Migrate();
        }
    }
}
