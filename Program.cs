using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp
{
    internal static class Program
    {
        private static ObservableCollection<ToDo> _toDos = new ObservableCollection<ToDo>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _toDos.Add(new ToDo("Three ago", DateTime.Now.AddDays(-3)));
            _toDos.Add(new ToDo("Three months ago", DateTime.Now.AddMonths(-3)));
            _toDos.Add(new ToDo("Three years ago", DateTime.Now.AddYears(-3)));
            _toDos.Add(new ToDo("foo", DateTime.Now));
            _toDos.Add(new ToDo("bar", DateTime.Now));
            _toDos.Add(new ToDo("batz", DateTime.Now));
            _toDos.Add(new ToDo("In three days", DateTime.Now.AddDays(3)));
            _toDos.Add(new ToDo("In three months", DateTime.Now.AddMonths(3)));
            _toDos.Add(new ToDo("In three years", DateTime.Now.AddYears(3)));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartpageView(_toDos));
        }
    }
}
