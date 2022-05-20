using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    public partial class StartpageView : Form
    {
        public StartpageView()
        {
            ToDos.Add(new Models.ToDo("foo", DateTime.Now));
            ToDos.Add(new Models.ToDo("bar", DateTime.Now));
            ToDos.Add(new Models.ToDo("batz", DateTime.Now));
            InitializeComponent();
            SetUpUI();

        }

        public List<Models.ToDo> ToDos { get; set; } = new List<Models.ToDo>();

        private void BtnOpenAddTask_Click(object sender, EventArgs e)
        {
            var addView = new AddTaskView();
            addView.ShowDialog();
        }


    }
}
