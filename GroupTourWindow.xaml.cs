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

        private void loadComboBoxes()
        {

            foreach (string burger in europeanBurgers)
            {
                cbxEuropeanOne.Items.Add(burger);
                cbxEuropeanTwo.Items.Add(burger);
            }
            foreach (string burger in chickenOthers)
            {
                cbxChickOtherOne.Items.Add(burger);
                cbxChickOtherTwo.Items.Add(burger);

            }

            cbxEuropeanOne.Text = cbxEuropeanOne.Items[0].ToString();
            cbxEuropeanTwo.Text = cbxEuropeanTwo.Items[0].ToString();

            cbxChickOtherOne.Text = cbxChickOtherOne.Items[4].ToString();
            cbxChickOtherTwo.Text = cbxChickOtherTwo.Items[4].ToString();
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
    }
}
