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


        private IEnumerable<ToDo> FilteredTasks => _todos.Where(CurrentFilter);

        public Func<ToDo, bool> CurrentFilter { get; private set; } = ToDo.NoFilter;

        public TaskOverview(ObservableCollection<ToDo> todos)
        {

            _todos = todos;
            InitializeComponent();
            dgvTodos.DataSource = FilteredTasks.ToList();
            dgvTodos.AutoGenerateColumns = false;


            comboBox1.DataSource = Enum.GetValues(typeof(Filters));
            comboBox1.SelectedItem = Filters.NONE;

            //TODO Custom cells für DueDate und Dropdown mittels cell paint event:
            //https://stackoverflow.com/questions/54518259/how-to-render-a-data-bound-winforms-datagridview-column-with-an-icon

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Filters)((ComboBox)sender).SelectedValue)
            {
                case Filters.NONE: CurrentFilter = ToDo.NoFilter; break;
                case Filters.TODAY: CurrentFilter = ToDo.DueItems; break;
                case Filters.MONTH: CurrentFilter = ToDo.ThisYear; break;
                case Filters.YEAR: CurrentFilter = ToDo.ThisYear; break;

            }
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