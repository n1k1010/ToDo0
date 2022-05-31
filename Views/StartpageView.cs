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
    //gleicher namespace, andere view, aber eine view.
{
    public partial class StartpageView : Form
    {
        readonly DateTimePicker DTPReminderPicker = new DateTimePicker();
        //readonly bedeutet dass man eine membervariable als Konstante setzen kann, diese aber anders als wenn
        //man den modifier const benutzt, zur Laufzeit kompiliert wird. Das heißt, man kann ihren Wert entweder im Konstruktor oder
        //bei der Deklaration setzen. Unterschied zwischen CompileZeit und LaufZeit. (Exceptions sind Laufzeitfehler,
        //das was man in der Error-List sieht sind compile-Fehler, das heißt das Programm kann nicht laufen, bevor diese
        //nicht behoben sind.
        //Ein DateTimePicker ist ein Control was benutzt wird, um ein Datum und eine Zeit zu setzen und sie sich im gewünschten
        //Format anzeigen zu lassen. Man kann ihm Integer als Argumente mitgeben ->() zB. minDate (2,6,1989).
        //DateTime
        Rectangle rectangle;
        //wir definieren ein Rectangle, das hat 3 Parameter (height, width und upperleft corner (location))
        //warum wir das brauchen verstehe ich hoffentlich noch im Verlauf des Codes.
        string fileName = "todos.json";
        //der Filename für unsere Json Datei die wir exportieren können.
        private ObservableCollection<ToDo> _todos;
        //Wieder das gleiche wie in TaskView, nur dass wir die Collection da _toDos genannt haben. Warum frage ich Ivo nachher.
        public StartpageView(ObservableCollection<ToDo> toDos)
            //Wieder Methodendeklaration mit neuer Instanz von Collection der Klasse ToDo, die genauso heißt wie
            //die der TaskView (toDos)
            //Hier beginnt die Methodensignatur
        {
            _todos = toDos;
            //hier wieder Variablenzuweisung der ObservableCollection mit der Variable toDos
            InitializeComponent();
            //wieder das weirde Ding was der Designer braucht(?)
            SetUpUI();
            // Wir rufen die Methode SetupUI in der Methodensignatur von StartpageView  auf

        }
        private void SetUpUI()
        {
            SetupGridView();
            //Methode SetupGridView() wird in der Methodensignatur von SetUpUI() aufgerufen
            _todos.CollectionChanged += TodosChanged;
            //CollectionChanged: Fired when list changes: item added, removed, list cleared.
            // CollectionChanged ist das Event was von INotifyCollectionChanged Interface geraised wird.
            //Hier sagen wir das Event heißt TodosChanged und soll jedes mal wenn sich was ändert wieder aufgerufen werden
            //oder neu gemacht werden? Ivo fragen.
            LblMainTitle.Text = $"DAILY LIST TO DO TODAY {DateTime.Today.ToShortDateString()}";
            //LblMainTitle ist ein hoffentlich weiter unten noch definiertes Label, was uns den Titel der
            //StartpageView anzeigt (.Text) Der nächste Ausdruck ist einfach die Today Property von DateTime und
            //macht das gewünschte Format (dem kann man auch Argumente übergeben() ). Wieder Stringinterpolation.
            GridViewToDos.Controls.Add(DTPReminderPicker);
            //ne Gridview die wir hoffentlich weiter unten noch deklarieren auf der wir Controls aufrufen.
            //Controls gibt eine Sammlung von Kind-controls aus, die sich innerhalb der allgemeinen Control befinden.
            //(ja etwas weird, muss ich nochmal nachlesen)
            DTPReminderPicker.Visible = false;
            //Das Control für den ReminderPicker ist nicht sichtbar
            DTPReminderPicker.Format = DateTimePickerFormat.Custom;
            //Macht, dass man das Format selbst bestimmen kann
            DTPReminderPicker.CustomFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";
            //sagt, wie das Format von DTPReminderPicker aussieht (warum das zwei sind weiß ich noch nicht)
            DTPReminderPicker.Leave += new EventHandler(HandleReminderChange);
            //erzeugt einen neuen Eventhandler auf der Property Leave auf (wir hatten einen Loop gebaut, da zwei Events
            //auf den gleichen Handler gezeigt haben
            GridViewToDos.Scroll += DatagridView_Scroll;
            //muss erstmal wissne was GridViewToDo für ein Objekt ist.
            GridViewToDos.ColumnWidthChanged += DatagridView_ColumnWidthChanged;
            //Hier das gleiche wie bei collectionchanged. Das event heißt DatgridView_ColumnWidthChanged und wird jedes mal neu
            //geraised wenn sich die Spaltenbreite ändert?
            GridViewToDos.CellClick += DatagridView_CellClick;
            //Hier auch ein Event auf GridviewTodos wa DatagridView_CellClick heißt und hochgezählt wird. Was das genau
            //macht muss ich noch nachgucken.

        }
        private Tuple<int, int> _lastCellClicked;
        //ein Tupel als Instanzvariable _lastCellClicked

        private void HandleReminderChange(object sender, EventArgs e)
        //Der HandleReminderChange-EventHandler wird aufgerufen, wenn der GridViewToDos_CellValueChanged-Handler
        //aufgerufen wird, und zwar nur dann, wenn es ein Event in der Gridview gibt,welches in der 5. Spalte
        //passiert. Die Position bezieht er über den angegebenen ZeilenIndex aus der Gridview, welchen er im zweiten
        //Argument des Tupels lastCellClicked hält. Dort befindet sich nämlich der gemeinte ReminderEintrag.
        {
            GridViewToDos_CellValueChanged(sender, new DataGridViewCellEventArgs(4, _lastCellClicked.Item2));
            
        }

        private void DatagridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //Hier ist definiert was passiert, wenn der Reminder in einer Zeile angeklickt wird.
        {
            _lastCellClicked = new Tuple<int, int>(e.ColumnIndex, e.RowIndex);
            //Das Tupel gibt den Zeilenindex der zuletzt geklickten Zelle aus, den wir brauchen um den HandleReminderChange
            //auszulösen.
            switch (e.ColumnIndex)
                // wenn die 5.Spalte angeklickt wurde:
            {
                case 4: // Column index of needed dateTimePicker cell
                    
                    rectangle = GridViewToDos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                    //macht ein rectangle für die erfasste Zelle auf
                    DTPReminderPicker.Size = new Size(rectangle.Width, rectangle.Height); //  
                    //Definiert die size für den Reminderpicker, weil rectangle die Parameter length und width braucht
                    DTPReminderPicker.Location = new Point(rectangle.X, rectangle.Y); //  
                    //Definiert den Point für den Reminderpicker, weil rectangle den Parameter location braucht
                    DTPReminderPicker.Visible = true;
                    // macht den Reminder sichtbar

                    break;
                    //springt wieder aus dem case-switch raus
            }
        }

        private void DatagridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        //sagt einfach nur, dass wenn sich die Breite der Spalte ändert, der ReminderPicker nicht sichtbar ist
        {
            DTPReminderPicker.Visible = false;
            
        }

        private void DatagridView_Scroll(object sender, ScrollEventArgs e)
        //sagt einfach nur, dass wenn in der Gridview gescrollt wird, der ReminderPicker nicht sichtbar ist
        {
            DTPReminderPicker.Visible = false;
        }

        private void TodosChanged(object sender, NotifyCollectionChangedEventArgs e)
            //wenn sich die Todo-Einträge in der Gridview geändert haben, lösche den zuletzt eingetragenen Inhalt
        {
            SetupGridView();
        }

        private void SetupGridView()
        //wenn sich die Todo-Einträge in der Gridview geändert haben, lösche den zuletzt eingetragenen Inhalt
        //in Spalte und Zeile und
        //hänge ein neues Set der definierten Spalten an die Gridview (dieses wird hier definiert).
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
            //wegen Enum-Auswahl (mehrere Values) brauchen wir hier eine ComboBox und keine textbox (nochmal definition nachlesen)
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
            var filtered = _todos.Where(todo => todo.DueDate < DateTime.Today.AddDays(1) && todo.State != States.Done);
            //filtert alle Einträge raus, die nicht < heute sind oder 'done' als state haben:
            // lambda Schreibweise:
            //* für alle todo in todos gilt: zeig nur an wenn DueDate von todo < zu klein für heute+aktuelle Uhrzeit oder bis Rest des Tages
            //und nicht state done

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
            var todo = _todos.First(x => x.Id == (string)GridViewToDos[0, e.RowIndex].Value);
            //für das erste (neueste) Element in _todo: Element = Element.ID und das ist der Wert der an der 0lten Spalte und dem zugehörigen Reihenindex steht.
            for (int i = 0; i < _todos.Count; i++)
            //für alle i = 0 und i kleiner der summe der elemente in todo, zähle hoch
            {
                if (_todos[i].Id == (string)GridViewToDos[0, e.RowIndex].Value)
                    //hier formuliert man bedingung für var todo und wenn dem so ist, dann setze i in _todos an stelle [i].
                {
                    todo = _todos[i];
                    break;
                }
            }
            switch (e.ColumnIndex)
            {
                case 1:
                    todo.Title = (string)GridViewToDos[e.ColumnIndex, e.RowIndex].Value;
                    break;
                case 2:
                    todo.DueDate = DateTime.Now; //TODO: Parse Date / use DateTimePicker
                    break;

                case 3:
                    todo.State = (States)GridViewToDos[e.ColumnIndex, e.RowIndex].Value;
                    break;
                case 4:
                    if (DateTime.TryParse($"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}", out DateTime dt))
                    {
                        todo.Reminder = dt; //(DateTime)GridViewToDos[e.ColumnIndex, e.RowIndex].Value;
                    }
                    // todo : Addreminder 
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
    }
}
