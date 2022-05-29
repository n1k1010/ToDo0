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
          
            _toDos.Add(new ToDo("foo", DateTime.Now));
            _toDos.Add(new ToDo("bar", DateTime.Now));
            _toDos.Add(new ToDo("batz", DateTime.Now));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartpageView(_toDos));
        }
    }
}
