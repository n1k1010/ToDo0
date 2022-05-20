using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public enum States { ToDo, InProgess, Done }


    public class ToDo
    {

        public string Title { get; private set; }
        public DateTime DueDate { get; private set; }
        // suchen nach c# DataGridView Enum to Combobox ( table cell converter wahrscheinlich )
        public States State { get; private set; } = States.ToDo;
    }


    public void ToDo(string title, DateTime dueDate)

    {
        Title = title;
        DueDate = dueDate;
        


    }
}

