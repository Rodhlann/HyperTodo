using HyperTodo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTodo.Entities
{
    public class TodoRepo
    {
        private static string connectionString = "Data Source=STORMTROOPER;Initial Catalog=TodoAppDB;Integrated Security=True;Pooling=False";

        public static List<Todo> GetAllTodosByUserId(long userId)
        {
            List<Todo> sqlReturn = new List<Todo>();
            string query = "select * from tbl_todos where UserId=" + userId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            int IdOrdinal = reader.GetOrdinal("Id");
                            int UserIdOrdinal = reader.GetOrdinal("UserId");
                            int NoteOrdinal = reader.GetOrdinal("Note");
                            sqlReturn.Add(new Todo {
                                Id = reader.GetInt32(IdOrdinal),
                                UserId = reader.GetInt32(UserIdOrdinal),
                                Note = reader.GetString(NoteOrdinal)
                            });
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }
                conn.Close();
            }
            return sqlReturn;
        }

        public static Todo GetTodoById(long todoId)
        {
            Todo todo = new Todo();
            string query = "select * from tbl_todos where Id=" + todoId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            int IdOrdinal = reader.GetOrdinal("Id");
                            int UserIdOrdinal = reader.GetOrdinal("UserId");
                            int NoteOrdinal = reader.GetOrdinal("Note");
                            todo = new Todo
                            {
                                Id = reader.GetInt32(IdOrdinal),
                                UserId = reader.GetInt32(UserIdOrdinal),
                                Note = reader.GetString(NoteOrdinal)
                            };
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }
                conn.Close();
            }
            return todo;
        }

        public static List<Todo> CreateTodo(Todo todo)
        {
            string query = // TODO: Update query to support null current null entries (Category/DueDate)
                "insert into tbl_todos (UserId, DueDate, Note, Category, Finished, Priority, Urgency) " +
                "values (" + todo.UserId + ", null, '" + todo.Note + "', null, " + Convert.ToInt32(todo.Finished) + ", " + todo.Priority + ", " + Convert.ToInt32(todo.Urgency) + ")";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                conn.Close();
            }
            return GetAllTodosByUserId(todo.UserId);
        }

        public static List<Todo> UpdateTodo(long todoId, Todo todo)
        {
            long UserId = todo.UserId;
            string query = // TODO: Update query to support null current null entries (Category/DueDate)
                "update tbl_todos set Note = '" + todo.Note + "', Finished = " + Convert.ToInt32(todo.Finished) + ", Priority = " + todo.Priority + ", Urgency = " + Convert.ToInt32(todo.Urgency) +
                " where Id=" + todoId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                conn.Close();
            }
            return GetAllTodosByUserId(UserId);
        }

        public static List<Todo> DeleteTodoById(long todoId)
        {
            long UserId = GetTodoById(todoId).UserId;
            string query = "delete from tbl_todos where Id=" + todoId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                conn.Close();
            }
            return GetAllTodosByUserId(UserId);
        }
    }
}
