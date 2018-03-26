using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HyperTodo.Models;
using static HyperTodo.Models.Todo;

namespace HyperTodo.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodosController : Controller
    {
        public static Todo todo1 = new Todo
        {
            Id = 0,
            Note = "Note 1",
            UserId = 1,
            Urgency = Urgency.NONE,
            Priority = 0,
            DueDate = new DateTime(),
            Category = "",
            Finished = false
        };

        public static Todo todo2 = new Todo
        {
            Id = 1,
            Note = "Note 2",
            UserId = 1,
            Urgency = Urgency.NONE,
            Priority = 1,
            DueDate = new DateTime(),
            Category = "",
            Finished = false
        };

        public Todo[] todos = { todo1, todo2 };

        // GET: api/Todo/5
        [HttpGet("getAll/{userId}", Name = "Get")]
        public IEnumerable<string> GetAllByUserId()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Todo/5
        [HttpGet("get/{id}", Name = "Get")]
        public string GetById(int id)
        {
            return "value";
        }

        // PUT: api/Todo/todo
        [HttpPut("{todo}")]
        public void Create([FromBody]Todo todo)
        {
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
