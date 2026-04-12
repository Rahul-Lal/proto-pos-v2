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
    /// Interaction logic for StaffMealWindow.xaml
    /// </summary>
    public partial class StaffMealWindow : Window
    {
        private readonly HomePage _home;

        public StaffMealWindow(HomePage home)
        {
            InitializeComponent();
            _home = home;
        }

        private void printStaffMeal(string burger)
        {
            string chosenCombo;

            chosenCombo = burger.ToUpper() + " STAFF COMBO\n" +
                    burger + " Burger \n" +
                    "Medium Fries \n" +
                    "Medium Drink \n";

            _home.txtOutput.Text += chosenCombo;
            _home.txtPrices.Text += "$0.00";
            _home.total += 0.00;
            _home.isStaffMealSelected = true;
            this.Close();
        }

        private void btnSingleOlympian_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Single Olympian");
        }

        private void btnSingleParisan_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Single Parisian");
        }

        private void btnSingleRoma_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Single Roma");
        }

        private void btnNashvilleHot_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Nashville Hot");
        }

        private void btnKyotoKatsu_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Kyoto Katsu");
        }

        private void btnMarrakesh_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Marrakesh Chicken");
        }

        private void btnOaxaca_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Oaxaca Veggie");
        }

        private void btnBombay_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Bombay Veggie");
        }

        private void btnNordic_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Nordic Fish");
        }

        private void btnHavana_Click(object sender, RoutedEventArgs e)
        {
            printStaffMeal("Havana Fish");
        }
    }
}
