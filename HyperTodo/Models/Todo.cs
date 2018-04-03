using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperTodo.Models
{
    public enum Urgency
    {
        NONE,
        LOW,
        MEDIUM,
        HIGH
    };

    public class Todo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Priority { get; set; }
        public DateTime DueDate { get; set; }
        public String Note { get; set; }
        public bool Finished { get; set; }
        public Urgency Urgency { get; set; }
        public string Category { get; set; }
    }
}
