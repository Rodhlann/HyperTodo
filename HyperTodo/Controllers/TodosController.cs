using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HyperTodo.Models;
using static HyperTodo.Models.Todo;
using System.Web.Http.Cors;

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

        // GET: api/Todo/GetAllByUserId/5
        [HttpGet("GetAllByUserId/{userId}")]
        public Todo[] GetAllByUserId()
        {
            return todos;
        }

        // GET: api/Todo/getTodoById/5
        [HttpGet("GetTodoById/{id}")]
        public Todo GetTodoById(int id)
        {
            return todos.Where(todo => todo.Id == id).FirstOrDefault();
        }

        // PUT: api/Todo/todo
        [HttpPut("{todo}")]
        public void Create([FromBody]Todo todo)
        {
            // Save new todo to DB
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
