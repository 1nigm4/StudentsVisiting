﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentsVisiting.Views.Windows
{
    public partial class AddAction : Window
    {
        public AddAction(bool isAddGroup)
        {
            InitializeComponent();
            Group.Visibility = isAddGroup ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
