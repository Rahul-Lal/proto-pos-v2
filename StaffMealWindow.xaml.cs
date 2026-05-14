using Microsoft.Data.SqlClient;
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

        private void selectMenuItemFromDB(string menuitem)
        {
            string constring = "Server=(localdb)\\MSSQLLocalDB;Database=TestPOSDB;Trusted_Connection=true;TrustServerCertificate=true";

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                string query = $"SELECT Name, BasePrice FROM MenuItem WHERE Name = @name";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", menuitem);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string chosenCombo;

                            chosenCombo = name.ToUpper() + " STAFF COMBO\n" +
                                    name + " Burger \n" +
                                    "Medium Fries \n" +
                                    "Medium Drink \n";

                            _home.txtOutput.Text += chosenCombo;
                            _home.txtPrices.Text += "$0.00";
                            _home.total += 0.00;
                            _home.isStaffMealSelected = true;
                        }
                    }
                }
            }
            this.Close();
        }

        private void btnSingleOlympian_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Olympian");
        }

        private void btnSingleParisan_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Parisian");
        }

        private void btnSingleRoma_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Roma");
        }

        private void btnNashvilleHot_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Nashville Hot");
        }

        private void btnKyotoKatsu_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Kyoto Katsu");
        }

        private void btnMarrakesh_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Marrakesh Chicken");
        }

        private void btnOaxaca_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Oaxaca Veggie");
        }

        private void btnBombay_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Bombay Veggie");
        }

        private void btnNordic_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Nordic Fish");
        }

        private void btnHavana_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Havana Fish");
        }
    }
}
