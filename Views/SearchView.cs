using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Utils;

namespace ToDoApp.Views
{
    public partial class SearchView : Form
    {
        string fileName = "todos.json";

        private readonly ObservableCollection<ToDo> _todos;
        private IEnumerable<ToDo> searchFilter => _todos.Where(currentSearchFilter);
        public Func<ToDo, bool> currentSearchFilter { get; private set; } = ToDo.NoFilter;

        public static DateTime searchdt = new DateTime();





        public SearchView(ObservableCollection<ToDo> todos)
        {
            InitializeComponent();
            _todos = todos;
            comboBox1.DataSource = Enum.GetValues(typeof(States));
            searchgdv.DataSource = searchFilter.ToList();
            searchgdv.AutoGenerateColumns = false;
            searchdt = searchDTPicker.Value;
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((States)((ComboBox)sender).SelectedValue)
            {
                case States.ToDo: currentSearchFilter = ToDo.SearchToDo; break;
                case States.InProgress: currentSearchFilter = ToDo.InProgress; break;
                case States.Done: currentSearchFilter = ToDo.Done; break;


            }
            RefreshGridView();
        }

        private void RefreshGridView()
        {

            if (searchgdv.InvokeRequired)
            {
                searchgdv.Invoke((MethodInvoker)delegate ()
                {
                    searchgdv.DataSource = null;
                    searchgdv.DataSource = searchFilter.ToList();
                });
            }
            else
            {
                searchgdv.DataSource = null;
                searchgdv.DataSource = searchFilter.ToList();


            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void SearchView_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            //string searched_todo = "test";
            //textBox2.Text = searched_todo;
            searchgdv.DataSource = _todos.Where(todo => todo.State == (States)comboBox1.SelectedItem 
            && todo.DueDate.Year == searchDTPicker.Value.Year 
            && todo.DueDate.DayOfYear == searchDTPicker.Value.DayOfYear).ToList();
       
        }
    }
}
