using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;
using ToDoApp.Models;
//was die ganzen nicht individuellen usings hier alles benutzen muss ich nochmal nachgucken.

namespace ToDoApp.Views
//wichtig, wir machen ja hier den Unterschied zwischen models, views und utils. Neuer Namespace ToDoApp.Views

{
    public partial class AddTaskView : Form
        //view klassen erben von der klasse Form
    {
        private ObservableCollection<ToDo> _toDos;
        //Hier deklarieren wir die ObservableCollection mit der von uns vorher geschriebenen Klasse ToDo und nennen sie _toDos
        //eine ObservableCollection implementiert das INotifyCollection-Interface, welches die UI automatisch updatet. Das INotifyCollection-Interface
        //generiert automatisch ein CollectionChanged-Event, welches immer dann geraised wird, wenn sich die Collection ändert.
        //Collection ist einfach eine Sammlung von Objekten jedweden DatenTyps.




        public AddTaskView(ObservableCollection<ToDo> toDos)
            //WARUM NEHMEN WIR HIER NICHT _toDo?
        //Hier deklarieren wir die Methode "AddTaskView" der wir die ObservableCollection mit Namen "toDos" der Klasse ToDo übergeben.
        {
          //Hier beginnt die Methodensignatur. Sie enthält nur eine optionalen Zugriffsmodifizierer, den Methodennamen und ihre Parameterliste, aber keinen Rückgabewert.
          _toDos = toDos;
            //Hier übergeben wir die vorher definierte ObservableCollection _toDos in die Variable "toDos", die wir der Methode addTaskView mitgegeben haben.
            InitializeComponent();
            // Die Methode InitializeComponent() ist eine notwendige Komponente für den Designer-Support in WinForms und WPF."Da geht alles rein"...
            dtDueDate.CustomFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";
            //Das hier betrifft die Darstellungsweise der Variable dtDuDate, die in (muss ich noch rausfinden) definiert ist.
            //Stringinterpolation, warum das jetzt zwei Mengen sind weiß ich noch nicht.
            // Die CurrentCulture ist eine Proptery von CultureInfo und ShortDatePattern eine von DateTime.ToString (machen wir ja wegen StrinInterpolation)
        }


        private void BtnClose_Click(object sender, EventArgs e)
            //Das hier ist jetzt ein generierter Eventhandler von AddTaskView (passiert wenn man einen Button auf die Form zieht)
            //und bezieht sich hier auf den Close-Button. Hier kommt nur rein, was unmittelbar das Verhalten des Buttons betrifft.
        {
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Hier wird eine neue Instanz der Klasse ToDo erzeugt und verschiedene Dinge übergeben, die sich hoffentlich noch klären.
            var newTodo = new ToDo(tbTitle.Text, dtDueDate.Value);
            //Adde ein neues Objekt der Klasse ToDo (newToDo) in die ObservableCollection _toDos.
            _toDos.Add(newTodo);
            //this ist ein Stichwort und bezieht sich immer auf die member der Instanz in der man sich gerade befindet. (Hier der Add-Button)
            this.Close();
        }
    }
}
