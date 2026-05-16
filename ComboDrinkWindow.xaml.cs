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

        private void btnCoke_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Coke";
            this.Close();
        }

        private void btnCokeNS_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Coke No Sugar";
            this.Close();
        }

        private void btnJarritos_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Jarritos Grapefruit";
            this.Close();
        }

        private void btnIrnBru_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Irn Bru";
            this.Close();
        }

        private void btnLnP_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "LnP";
            this.Close();
        }

        private void btnSparletta_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Sparletta Cream Soda";
            this.Close();
        }

        private void btnTing_Click(object sender, RoutedEventArgs e)
        {
            isSoda = true;
            chosenDrink = "Ting";
            this.Close();
        }

        private void btnMatchaShake_Click(object sender, RoutedEventArgs e)
        {
            isShake = true;
            chosenDrink = "Matcha Green Tea Shake";
            this.Close();
        }

        private void btnChurroShake_Click(object sender, RoutedEventArgs e)
        {
            isShake = true;
            chosenDrink = "Churro Cinnamon Shake";
            this.Close();
        }

        private void btnMangoLassiShake_Click(object sender, RoutedEventArgs e)
        {
            isShake = true;
            chosenDrink = "Mango Lassi Shake";
            this.Close();
        }

        private void btnPandanCoconutShake_Click(object sender, RoutedEventArgs e)
        {
            isShake = true;
            chosenDrink = "Pandan Coconut Shake";
            this.Close();
        }

        private void btnTiramisuShake_Click(object sender, RoutedEventArgs e)
        {
            isShake = true;
            chosenDrink = "Tiramisu Shake";
            this.Close();
        }
    }
}
