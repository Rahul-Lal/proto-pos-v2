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
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private double amountOwed;
        private readonly HomePage _home;

        public PaymentWindow(HomePage home, double total)
        {
            InitializeComponent();
            _home = home;
            amountOwed = total;
            txtTotalPrice.Text = amountOwed.ToString("0.00");
        }

        private void clearOutput()
        {
            _home.txtOutput.Text = "";
            _home.txtPrices.Text = "";
            _home.total = 0.0;
            _home.txtTotal.Text = _home.total.ToString("C");
        }

        private void ApplyPayment(double amount)
        {
            if (amount <= 0)
            {
                this.Close();
            }

            amountOwed -= amount;

            if (amountOwed > 0)
            {
                // Still money left to pay
                txtTotalPrice.Text = amountOwed.ToString("0.00");
            }
            else
            {
                // Payment complete (or overpaid)
                double change = Math.Abs(amountOwed);

                MessageBox.Show($"Payment Complete. Change: ${change:0.00}");

                amountOwed = 0;
                txtTotalPrice.Text = "0.00";

                clearOutput();
                this.Close();
            }
        }

        private void btnExactAmount_Click(object sender, RoutedEventArgs e)
        {
            ApplyPayment(amountOwed);
        }

        private void btnEftpos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EFTPOS Accepted!");
            ApplyPayment(amountOwed);
        }
    }
}
