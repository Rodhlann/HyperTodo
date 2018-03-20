using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperTodo.Models
{
    [Table(name: "Todos")]
    public class Todo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public String Note { get; set; }
        public enum Priority {
            NONE,
            LOW,
            MEDIUM,
            HIGH
        };
    }
}
