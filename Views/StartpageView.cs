using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Utils;

namespace ToDoApp.Views

{
    public partial class StartpageView : Form
    {
        readonly string _dateFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";
        readonly DateTimePicker DTPReminderPicker = new DateTimePicker();
        readonly CheckBox reminderOff = new CheckBox();

        Rectangle rectangle;


        string fileName = "todos.json";

        private ObservableCollection<ToDo> _todos;

        public StartpageView(ObservableCollection<ToDo> toDos)

        {
            _todos = toDos;

            InitializeComponent();

            SetUpUI();


        }
        private void SetUpUI()
        {
            SetupGridView();

            _todos.CollectionChanged += TodosChanged;


            //CollectionChanged: Fired when list changes: item added, removed, list cleared.

            LblMainTitle.Text = $"DAILY LIST TO DO TODAY {DateTime.Today.ToShortDateString()}";

            GridViewToDos.Controls.Add(DTPReminderPicker);
            GridViewToDos.Controls.Add(reminderOff);

            DTPReminderPicker.Visible = false;
            reminderOff.Visible = false;

            DTPReminderPicker.Format = DateTimePickerFormat.Custom;

            DTPReminderPicker.CustomFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";

            DTPReminderPicker.Leave += new EventHandler(HandleReminderChange);

            GridViewToDos.Scroll += DatagridView_Scroll;
            GridViewToDos.ColumnWidthChanged += DatagridView_ColumnWidthChanged;

            GridViewToDos.CellClick += DatagridView_CellClick;


        }

        private void CBDeleteReminder_CheckedChanged(object sender, EventArgs e)
        {
            DTPReminderPicker.Value = DateTime.MinValue;
        }

        private Tuple<int, int> _lastCellClicked;
        //Instancevariable 

        private void HandleReminderChange(object sender, EventArgs e)

        {
            GridViewToDos_CellValueChanged(sender, new DataGridViewCellEventArgs(4, _lastCellClicked.Item2));

        }

        private void DatagridView_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            _lastCellClicked = new Tuple<int, int>(e.ColumnIndex, e.RowIndex);

            switch (e.ColumnIndex)

            {
                case 4: // Column index of needed dateTimePicker cell
                    rectangle = GridViewToDos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  

                    //DTPReminderPicker.Size = new Size(rectangle.Width+rectangle.Height, rectangle.Height);
                    //DTPReminderPicker.Location = new Point(rectangle.X - rectangle.Y, rectangle.Y);
                    //foreach (e.RowIndex >1)
                    //nimm size of row1 

                    DTPReminderPicker.Size = new Size(rectangle.Width - rectangle.Height, rectangle.Height); //  

                    DTPReminderPicker.Location = new Point(rectangle.X + rectangle.Y, rectangle.Y); //  



                    DTPReminderPicker.Visible = true;






                    reminderOff.Size = new Size(rectangle.Width, rectangle.Height); //  

                    reminderOff.Location = new Point(rectangle.X, rectangle.Y); //  

                    reminderOff.Visible = true;

                    break;

            }
        }

        private void DatagridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)

        {
            DTPReminderPicker.Visible = false;
            reminderOff.Visible = false;
        }

        private void DatagridView_Scroll(object sender, ScrollEventArgs e)

        {
            DTPReminderPicker.Visible = false;
            reminderOff.Visible = false;
        }

        private void TodosChanged(object sender, NotifyCollectionChangedEventArgs e)

        {
            SetupGridView();
        }

        private void SetupGridView()

        {
            GridViewToDos.Columns.Clear();
            GridViewToDos.Rows.Clear();

            var id = new DataGridViewTextBoxColumn();
            id.Visible = false;

            var title = new DataGridViewTextBoxColumn();
            title.HeaderText = "Titel";

            var date = new DataGridViewTextBoxColumn();
            date.HeaderText = "Fälligkeitsdatum";

            var state = new DataGridViewComboBoxColumn();

            state.Name = nameof(ToDo.State);
            state.DataSource = Enum.GetValues(typeof(States));
            state.ValueType = typeof(States);

            var reminder = new DataGridViewTextBoxColumn();
            reminder.HeaderText = "Erinnerung";
            reminder.ValueType = typeof(string);

            GridViewToDos.Columns.Add(id);
            GridViewToDos.Columns.Add(title);
            GridViewToDos.Columns.Add(date);
            GridViewToDos.Columns.Add(state);
            GridViewToDos.Columns.Add(reminder);
            var filtered = _todos.Where(ToDo.DueItems);

            //_todos.Where(todo => todo.DueDate < DateTime.Today.AddDays(1) && todo.State != States.Done);


            foreach (var todo in filtered)
            {
                string reminderDate = null;
                if (todo.Reminder != null)
                {
                    reminderDate = $"{todo.Reminder?.ToShortDateString()} {todo.Reminder?.ToShortTimeString()}";
                }
                GridViewToDos.Rows.Add(todo.Id, todo.Title, todo.DueDate, todo.State, reminderDate ?? "Aus");
                if (todo.DueDate < DateTime.Now)
                {
                    GridViewToDos.Rows[GridViewToDos.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            GridViewToDos.CellValueChanged += GridViewToDos_CellValueChanged;
        }

        private void GridViewToDos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= GridViewToDos.Rows.Count)
            { return; }
            var todo = _todos.FirstOrDefault(x => x.Id == (string)GridViewToDos[0, e.RowIndex].Value);
            if (todo == null)
            {
                return;
            }

            for (int i = 0; i < _todos.Count; i++)

            {
                if (_todos[i].Id == (string)GridViewToDos[0, e.RowIndex].Value)

                {
                    todo = _todos[i];
                    break;
                }
            }
            var value = GridViewToDos[e.ColumnIndex, e.RowIndex].Value;
            switch (e.ColumnIndex)
            {
                case 1:
                    todo.Title = (string)value;
                    break;
                case 2:

                    todo.DueDate = (DateTime)value;

                    //DateTime.Now;  //TODO: Parse Date / use DateTimePicker 

                    break;
                case 3:
                    todo.State = (States)value;
                    break;
                case 4:
                    var dt = ((DateTimePicker)sender).Value;
                    if (dt == DateTime.MinValue)
                    {
                        todo.Reminder = null;
                    }
                    else
                    {
                        todo.Reminder = dt;
                    }
                    //DTPReminderPicker.Size = new Size(rectangle.Width, rectangle.Height);
                    //DTPReminderPicker.Location = new Point(rectangle.X, rectangle.Y);
                    //Todo Add Reminder in windows
                    break;
            }
            SetupGridView();
        }



        private void BtnOpenAddTask_Click(object sender, EventArgs e)
        {
            var addView = new AddTaskView(_todos);
            addView.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = string.Join(Environment.NewLine, _todos.Select(x => x.ToString()));
            new ToastContentBuilder()
    .AddArgument("action", "viewConversation")
    .AddArgument("conversationId", 9813)
    .AddText("Andrew sent you a picture")
    .AddText("Check this out, The Enchantments in Washington!")
    .Schedule(DateTimeOffset.Now.AddMinutes(3));


        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(_todos));
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _todos.Clear();
            JsonConvert.DeserializeObject<List<ToDo>>(File.ReadAllText(fileName), new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>() { new StringEnumConverter() }
            }).ForEach(x => _todos.Add(x));

        }

        private void GridViewToDos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filtered = _todos.Where(ToDo.Tomorrow);
            SetupGridView();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var taskOverView = new TaskOverview(_todos);
            taskOverView.ShowDialog();
        }
    }
}
