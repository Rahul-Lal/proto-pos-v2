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
    /// Interaction logic for ComboSideWindow.xaml
    /// </summary>
    public partial class ComboSideWindow : Window
    {
        private readonly HomePage _home;

        public ComboSideWindow(HomePage home)
        {
            InitializeComponent();
            _home = home;
        }

        public bool makeFries = false;
        public bool makeGarlicBread = false;
        public bool makeMozzarellaStick = false;
        public bool makeSpringRoll = false;
        public bool makeLoadedNachos = false;
        public bool makePoutine = false;

        public string chosenSide = "";

        private void btnFries_Click(object sender, RoutedEventArgs e)
        {
            makeFries = true;
            chosenSide = "Fries";
            this.Close();
        }

        private void btnGarlicBread_Click(object sender, RoutedEventArgs e)
        {
            makeGarlicBread = true;
            chosenSide = "Garlic Bread";
            this.Close();

        }

        private void btnMozzarellaStick_Click(object sender, RoutedEventArgs e)
        {
            makeMozzarellaStick = true;
            chosenSide = "Mozzarella Sticks";
            this.Close();
        }
    }
}
