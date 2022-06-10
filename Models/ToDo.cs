using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using ToDoApp.Utils;
using System.Collections.ObjectModel;
using ToDoApp.Views;
using System.Globalization;
using System.Windows.Forms;

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

        public static bool NoFilter(ToDo toDo) => true;

        public static bool DueItems (ToDo toDo)
        {
            return toDo.DueDate < DateTime.Today.AddDays(1) && toDo.State != States.Done;
        }
        
        public static bool Tomorrow(ToDo toDo)
        {
            return toDo.DueDate >= DateTime.Today.AddDays(1) && toDo.DueDate < DateTime.Today.AddDays(2);
        }

        public static bool Done(ToDo toDo)
        {
            return toDo.State == States.Done;
        }

        public static bool InProgress (ToDo toDo)
        {
            return toDo.State == States.InProgress;
        }

       public static bool ThisMonth (ToDo toDo)
        {
            return toDo.DueDate.Year == DateTime.Now.Year && toDo.DueDate.Month == DateTime.Now.Month;         
        }

        public static bool ThisYear(ToDo toDo)
        {
            return toDo.DueDate.Year == DateTime.Now.Year;
        }
        
        public static bool SearchToDo(ToDo toDo)
        {
            //SearchView searchView = new SearchView();
            return toDo.State == States.ToDo && SearchView.searchdt == toDo.DueDate;
        }
       /* public static bool SearchDueDate(ToDo toDo)
        {
            
            return toDo.DueDate == DateTime.Now;
        }*/
    }


}

