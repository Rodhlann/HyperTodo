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

        // PUT: api/Todo/CreateTodo (body -> raw -> {"UserId": "0", "Note": "New Todo 5" })
        [HttpPut("CreateTodo")]
        public List<Todo> CreateTodo([FromBody]Todo todo)
        {
            return TodoRepo.CreateTodo(todo);
        }

        // PUT: api/Todo/UpdateTodo (body -> raw -> {"Id": "5", "UserId": "0", "Note": "New Todo 5" })
        [HttpPut("UpdateTodo")]
        public Todo UpdateTodo([FromBody]Todo todo)
        {
            return TodoRepo.UpdateTodo(todo.Id, todo);
        }

        // DELETE: api/Todo/DeleteTodoById (body -> x-www-form-urlencoded -> todo: 1)
        [HttpDelete("DeleteTodoById/{todoId}")]
        public List<Todo> DeleteTodoById(long todoId)
        {
            return TodoRepo.DeleteTodoById(todoId);
        }
    }
}
