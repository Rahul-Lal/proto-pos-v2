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
    /// Interaction logic for ComboDrinkWindow.xaml
    /// </summary>
    public partial class ComboDrinkWindow : Window
    {
        public ComboDrinkWindow()
        {
            InitializeComponent();
        }

        public bool isSoda = false;
        public bool isShake = false;

        public string chosenDrink = "";
    }
}
