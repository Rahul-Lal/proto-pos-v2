using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proto_pos_v2
{
    /// <summary>
    /// Interaction logic for GroupTourWindow.xaml
    /// </summary>
    public partial class GroupTourWindow : Window
    {
        private readonly HomePage _home;
        public GroupTourWindow(HomePage home)
        {
            InitializeComponent();
            _home = home;
        }
    }
}
