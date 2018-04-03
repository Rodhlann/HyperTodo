using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HyperTodo.Models;
using static HyperTodo.Models.Todo;
using System.Web.Http.Cors;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using HyperTodo.Entities;

namespace HyperTodo.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodosController : Controller
    {
        // GET: api/Todo/GetAllByUserId/5
        [HttpGet("GetAllByUserId/{userId}")]
        public List<Todo> GetAllByUserId(long userId)
        {
            return TodoRepo.GetAllTodosByUserId(userId);
        }

        // PUT: api/Todo/CreateTodo/{todo}
        [HttpPut("CreateTodo/{todo}")]
        public List<Todo> CreateTodo([FromBody]Todo todo)
        {
            return TodoRepo.CreateTodo(todo);
        }

        // PUT: api/Todo/UpdateTodo/5
        [HttpPut("UpdateTodo/{id}")]
        public List<Todo> UpdateTodo(long todoId, [FromBody]Todo todo)
        {
            return TodoRepo.UpdateTodo(todoId, todo);
        }

        // DELETE: api/Todo/DeleteTodo/5
        [HttpDelete("DeleteTodo/{id}")]
        public List<Todo> DeleteTodoById(int todoId)
        {
            return TodoRepo.DeleteTodoById(todoId);
        }
    }
}
