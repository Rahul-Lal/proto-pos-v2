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
    /// Interaction logic for GroupTourWindow.xaml
    /// </summary>
    public partial class GroupTourWindow : Window
    {
        private readonly HomePage _home;
        public GroupTourWindow(HomePage home)
        {
            InitializeComponent();
            _home = home;
            loadComboBoxes();
        }

        private void loadComboBoxes()
        {
            string constring = "Server=(localdb)\\MSSQLLocalDB;" + "Database=TestPOSDB;" + "Trusted_Connection=true;" + "TrustServerCertificate=true";

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                // =========================
                // European Burgers
                // =========================

                string europeanQuery = "SELECT Name FROM dbo.MenuItem " + "WHERE CategoryId = @categoryId " + "AND Name LIKE '%Single%'";

                using (SqlCommand euroCMD = new SqlCommand(europeanQuery, con))
                {
                    euroCMD.Parameters.AddWithValue("@categoryId", 1);

                    using (SqlDataReader reader = euroCMD.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();

                            cbxEuropeanOne.Items.Add(name);
                            cbxEuropeanTwo.Items.Add(name);
                        }
                    }
                }

                // =========================
                // Chicken / Other Burgers
                // =========================

                string chickenQuery = "SELECT Name FROM dbo.MenuItem " + "WHERE CategoryId = @categoryId";

                using (SqlCommand chickenCMD = new SqlCommand(chickenQuery, con))
                {
                    chickenCMD.Parameters.AddWithValue("@categoryId", 2);

                    using (SqlDataReader reader = chickenCMD.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();

                            cbxChickOtherOne.Items.Add(name);
                            cbxChickOtherTwo.Items.Add(name);
                        }
                    }
                }
            }
        }

        public void selectComboItems()
        {
            string europeanBurgerOne = cbxEuropeanOne.SelectedItem.ToString();
            string europeanBurgerTwo = cbxEuropeanTwo.SelectedItem.ToString();
            string chickenOtherOne = cbxChickOtherOne.SelectedItem.ToString();
            string chickenOtherTwo = cbxChickOtherTwo.SelectedItem.ToString();

            _home.txtOutput.Text += europeanBurgerOne + "\n";
            _home.txtOutput.Text += europeanBurgerTwo + "\n";
            _home.txtOutput.Text += chickenOtherOne + "\n";
            _home.txtOutput.Text += chickenOtherTwo + "\n";

            _home.txtOutput.Text += "4 Small Fries\n";
            _home.txtOutput.Text += "4 Small Drinks\n";
        }

        public void btnOK_Click(object sender, RoutedEventArgs e)
        {
            selectComboItems();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
