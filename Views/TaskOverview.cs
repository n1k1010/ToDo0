using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Models;
using System.Linq;
using ToDoApp.Utils;
using System.Collections.ObjectModel;

namespace ToDoApp.Views
{

    public partial class TaskOverview : Form
    {
        private readonly ObservableCollection<ToDo> _todos;


        private IEnumerable<ToDo> FilteredTasks { get; set; }
        

        public TaskOverview(ObservableCollection<ToDo> todos)
        {

            _todos = todos;
            FilteredTasks = _todos.Where(ToDo.NoFilter).ToList();
            InitializeComponent();
            dgvTodos.DataSource = FilteredTasks.ToList();
            dgvTodos.AutoGenerateColumns = false;
            dgvTodos.Columns[0].Visible = false;

            comboBox1.DataSource = Enum.GetValues(typeof(Filters));
            comboBox1.SelectedItem = Filters.NONE;

            dateTimePicker1.Visible = (Filters) comboBox1.SelectedItem == Filters.BEFORE;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;

            //TODO Custom cells für DueDate und Dropdown mittels cell paint event:
            //https://stackoverflow.com/questions/54518259/how-to-render-a-data-bound-winforms-datagridview-column-with-an-icon

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(comboBox1, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch ((Filters)((ComboBox)sender).SelectedValue)
            {
                case Filters.NONE: FilteredTasks = _todos.Where(ToDo.NoFilter).ToList(); break;
                case Filters.TODAY: FilteredTasks = _todos.Where(ToDo.DueItems).ToList(); break;
                case Filters.MONTH: FilteredTasks = _todos.Where(ToDo.ThisMonth).ToList(); break;
                case Filters.YEAR: FilteredTasks = _todos.Where(ToDo.ThisYear).ToList(); break;
                case Filters.BEFORE: FilteredTasks = _todos.Where((todo)=>ToDo.Before(todo, dateTimePicker1.Value)).ToList(); break;
            }
            dateTimePicker1.Visible = (Filters)comboBox1.SelectedItem == Filters.BEFORE;
            RefreshGridView();

        }
        private void RefreshGridView()
        {
            if (dgvTodos.InvokeRequired)
            {
                dgvTodos.Invoke((MethodInvoker)delegate ()
                {
                    dgvTodos.DataSource = null;
                    dgvTodos.DataSource = FilteredTasks.ToList();
                });
            }
            else
            {
                dgvTodos.DataSource = null;
                dgvTodos.DataSource = FilteredTasks.ToList();

            }
        }
    }
}