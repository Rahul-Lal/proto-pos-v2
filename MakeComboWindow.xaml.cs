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
    /// Interaction logic for MakeComboWindow.xaml
    /// </summary>
    public partial class MakeComboWindow : Window
    {
        public MakeComboWindow()
        {
            InitializeComponent();
        }

        public bool makeLarge = false;
        public bool makeMedium = false;
        public bool makeJustBurger = false;

        private void btnLargeCombo_Click(object sender, RoutedEventArgs e)
        {
            makeLarge = true;
            this.Close();
        }

        private void btnMediumCombo_Click(object sender, RoutedEventArgs e)
        {
            makeMedium = true;
            this.Close();
        }

        private void btnJustTheBurger_Click(object sender, RoutedEventArgs e)
        {
            makeJustBurger = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
