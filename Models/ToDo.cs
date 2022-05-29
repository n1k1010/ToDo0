using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using ToDoApp.Utils;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        // suchen nach c# DataGridView Enum to Combobox ( table cell converter wahrscheinlich )

        [JsonConverter(typeof(StringEnumConverter))]
        public States State { get; set; } = States.ToDo;

        public DateTime? Reminder { get; set; }

        public ToDo(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"Title: {Title}, DueDate: {DueDate.ToLongDateString()}, State: {Enum.GetName(typeof(States), State)}";
        }
    }
}

