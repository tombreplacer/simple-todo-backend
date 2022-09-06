using Microsoft.AspNetCore.Mvc;

namespace simple_todo_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoContext _db;

        private readonly Random _rng = new Random();

        public TodoController(ILogger<TodoController> logger, TodoContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("")]
        public IEnumerable<Todo> Get()
        {
            Thread.Sleep(_rng.Next(1,3000));
            return _db.Todos.ToArray();
        }

        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            Thread.Sleep(_rng.Next(1,3000));
            return _db.Todos.Where(e=>e.Id == id).First();
        }

        [HttpPost()]
        public void Add(Todo todo)
        {
            Thread.Sleep(_rng.Next(1000,5000));
            if(todo.Title == "error") {
                throw new NotImplementedException();
            }
            _db.Todos.Add(todo);
            _db.SaveChanges();
        }

        [HttpPut()]
        public void Update(Todo todo)
        {
            Thread.Sleep(_rng.Next(1000,5000));
            _db.Todos.Update(todo);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Thread.Sleep(_rng.Next(1000,5000));
            var todo = _db.Todos.Where(e => e.Id == id).First();
            if(todo.Title == "error") {
                throw new NotImplementedException();
            }
            _db.Todos.Remove(todo);
            _db.SaveChanges();
        }
    }
}