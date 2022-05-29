﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;
using ToDoApp.Models;

namespace ToDoApp.Views
{
    public partial class AddTaskView : Form
    {
        private ObservableCollection<ToDo> _toDos;




        public AddTaskView(ObservableCollection<ToDo> toDos)
        {
            _toDos = toDos;

            InitializeComponent();
            dtDueDate.CustomFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newTodo = new ToDo(tbTitle.Text, dtDueDate.Value);
            _toDos.Add(newTodo);
            this.Close();
        }
    }
}