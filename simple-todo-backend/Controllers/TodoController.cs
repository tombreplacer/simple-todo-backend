using Microsoft.AspNetCore.Mvc;

namespace simple_todo_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoContext _db;

        public TodoController(ILogger<TodoController> logger, TodoContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("")]
        public IEnumerable<Todo> Get()
        {
            return _db.Todos.ToArray();
        }

        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return _db.Todos.Where(e=>e.Id == id).First();
        }

        [HttpPost()]
        public void Add(Todo todo)
        {
            _db.Todos.Add(todo);
            _db.SaveChanges();
        }

        [HttpPut()]
        public void Update(Todo todo)
        {
            _db.Todos.Update(todo);
            _db.SaveChanges();
        }

        [HttpDelete()]
        public void Delete(int id)
        {
            var todo = _db.Todos.Where(e => e.Id == id).First();
            _db.Todos.Remove(todo);
            _db.SaveChanges();
        }
    }
}