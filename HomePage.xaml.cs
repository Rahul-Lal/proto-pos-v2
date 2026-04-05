using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proto_pos_v2
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        bool isDrinkSmall = false;
        bool isDrinkMedium = false;
        bool isDrinkLarge = false;

        public bool isStaffMealSelected = false;
        bool isDiscountedTenPercent = false;

        public List<string> orderLines = new List<string>();
        public List<double> prices = new List<double>();

        int AddOnCount = 0;
        public double total = 0.00;

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
                            string price = reader["BasePrice"].ToString();
                            txtOutput.Text += name + "\n";
                            txtPrices.Text += price + "\n";
                            total += double.Parse(price);
                            totalAmount(total);
                        }
                    }
                }
            }
        }

        private void RefreshUI()
        {
            txtOutput.Text = string.Join("\n", orderLines);
            txtPrices.Text = string.Join("\n", prices.Select(p => p.ToString("C")));

            total = prices.Sum();
            txtTotal.Text = total.ToString("C");

            orderLinesViaConsole();
        }

        public void Repeat()
        {
            if (orderLines.Count == 0)
                return;

            string lastItem = orderLines[orderLines.Count - 1];
            double lastPrice = prices[prices.Count - 1];

            orderLines.Add(lastItem);
            prices.Add(lastPrice);

            RefreshUI();
        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            Repeat();
        }

        private void orderLinesViaConsole()
        {
            Console.WriteLine("Orders:");

            int count = Math.Min(orderLines.Count, prices.Count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{orderLines[i]}: {prices[i]}");
            }

            if (orderLines.Count != prices.Count)
            {
                Console.WriteLine($"Warning: orderLines ({orderLines.Count}) and prices ({prices.Count}) counts differ.");
            }

            Console.WriteLine("------ END OF LINE ------");
        }

        private void setDrinkFlavour(string drink)
        {
            if (isDrinkLarge == true || isDrinkMedium == true || isDrinkSmall == true)
            {
                setDrinkSize();
                txtOutput.Text += $"{drink}\n";
                Console.WriteLine(txtOutput.Text);
            }
            else
            {
                MessageBox.Show("Please Select a size first.");
            }
        }

        private void btnSingleOlympian_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Olympian");
        }

        private void btnDoubleOlympian_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Double Olympian");
        }

        private void btnSingleParisian_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Parisian");
        }

        private void btnDoubleParisian_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Double Parisian");
        }

        private void btnSingleRoma_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Roma");
        }

        private void btnDoubleRoma_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Double Roma");
        }

        private void btnSingleMatador_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Matador");
        }

        private void btnDoubleMatador_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Double Matador");
        }

        private void btnSingleKaiser_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Single Kaiser");
        }

        private void btnDoubleKaiser_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Double Kaiser");
        }

        private void btnNashvilleHot_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Nashville Hot", 10.50);
        }

        private void btnKyotoKatsu_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Kyoto Katsu", 12.50);
        }

        private void btnMarrakesh_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Marrakesh Chicken", 14.50);
        }

        private void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Baja Chicken", 14.50);
        }

        private void btnSeoulFire_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Seoul Fire", 14.50);
        }

        private void btnBangkokSatay_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Bangkok Satay Chicken", 12.50);
        }

        private void btnOaxaca_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Oaxaca Veggie", 10.50);
        }

        private void btnBombay_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Bombay Veggie", 12.50);
        }

        private void btnNordic_Click(object sender, RoutedEventArgs e)
        {
            // // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Nordic Salmon", 12.50);
        }

        private void btnHavana_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Havana Fish", 12.50);
        }

        private void btnSmallFries_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Small Fries");
        }

        private void btnMediumFries_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Medium Fries");
        }

        private void btnLargeFries_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Large Fries");
        }

        private void btnGarlicBread_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Garlic Bread");
        }

        private void btnMozzarellaStick_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Mozzarella Sticks");
        }

        private void btnSpringRoll_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Spring Rolls");
        }

        private void btnLoadedNachos_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Loaded Nachos");
        }

        private void btnPoutine_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Poutine");
        }

        private void btnApplePie_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Apple Pie");
        }

        private void btnChurros_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Churros");
        }

        private void btnTiramisuCup_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Tiramisu Cup");
        }

        private void btnMochiIceCream_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Mochi Ice Cream");
        }

        private void btnCremeBrulee_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Creme Brulee");
        }

        private void btnBaklavaBites_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Baklava Bites");
        }

        private void btnMatchaGreenTeaShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Matcha Green Tea Shake");
        }

        private void btnChurroCinnamonShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Churro Cinnamon Shake");
        }

        private void btnMangoLassiShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Mango Lassi Shake");
        }

        private void btnDulceDeLecheShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Dulce De Leche Shake");
        }

        private void btnDubaiChocolateShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Dubai Chocolate Shake");
        }

        private void btnPandanCoconutShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Pandan Coconut Shake");
        }

        private void btnTiramisuShake_Click(object sender, RoutedEventArgs e)
        {
            selectMenuItemFromDB("Tiramisu Shake");
        }

        private void btnCoke_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Coke");
        }

        private void btnCokeNS_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Coke No Sugar");
        }

        private void btnJarritos_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Jarritos Grapefruit");
        }

        private void btnIrnBru_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Irn Bru");
        }

        private void btnLnP_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("LnP");
        }

        private void btnSparletta_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Sparletta Cream Soda");
        }

        private void btnTing_Click(object sender, RoutedEventArgs e)
        {
            setDrinkFlavour("Ting");
        }

        private void btnClearOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
        }

        public void ClearOutput()
        {
            txtOutput.Text = "";
            txtPrices.Text = "";
            total = 0.0;
            totalAmount(total);
            AddOnCount = 0;
            isDiscountedTenPercent = false;
            isStaffMealSelected = false;
            Console.WriteLine($"---------- TXTOUTPUT CLEARED ----------");
        }

        private void totalAmount(double amount)
        {
            txtTotal.Text = total.ToString("C");

        }

        private void comboOption()
        {
            string chosenCombo;

            MakeComboWindow makeCombo = new MakeComboWindow();
            makeCombo.ShowDialog();

            if (makeCombo.makeLarge == true)
            {
                chosenCombo = burger.ToUpper() + " LARGE COMBO\n" +
                    burger + " Burger \n" +
                    "Large Fries \n" +
                    "Large Drink \n";

                txtOutput.Text += chosenCombo;
                orderLines.Add(chosenCombo);

                txtPrices.Text += "$" + (price + 7.5).ToString() + ".00\n\n\n\n";
                total += price + 7.5;
                prices.Add(price + 7.5);
                totalAmount(total);

                makeCombo.makeLarge = false;
                makeCombo.Close();
            }
            else if (makeCombo.makeMedium == true)
            {
                chosenCombo = burger.ToUpper() + " MEDIUM COMBO\n" +
                    burger + " Burger \n" +
                    "Medium Fries \n" +
                    "Medium Drink \n";

                txtOutput.Text += chosenCombo;
                orderLines.Add(chosenCombo);

                txtPrices.Text += "$" + (price + 5).ToString() + "0\n\n\n\n";
                total += price + 5;
                prices.Add(price + 5);
                totalAmount(total);

                makeCombo.makeMedium = false;
                makeCombo.Close();
            }
            else if (makeCombo.makeJustBurger == true)
            {
                selectMenuItemFromDB(burger);
            }
            else
            {
                makeCombo.Close();
            }
            Console.WriteLine("Combo:");
            orderLinesViaConsole();
        }


        private void btnMediumDrink_Click(object sender, RoutedEventArgs e)
        {
            isDrinkMedium = true;
        }

        private void btnSmallDrink_Click(object sender, RoutedEventArgs e)
        {
            isDrinkSmall = true;
        }

        private void btnLargeDrink_Click(object sender, RoutedEventArgs e)
        {
            isDrinkLarge = true;
        }

        private void setDrinkSize()
        {
            if (isDrinkSmall)
            {
                txtOutput.Text += "Small ";
                txtPrices.Text += "$2.50\n";
                total += 2.50;
                totalAmount(total);
                isDrinkSmall = false;
            }
            else if (isDrinkMedium)
            {
                txtOutput.Text += "Medium ";
                txtPrices.Text += "$3.50\n";
                total += 3.50;
                totalAmount(total);
                isDrinkMedium = false;
            }
            else if (isDrinkLarge)
            {
                txtOutput.Text += "Large ";
                txtPrices.Text += "$4.50\n";
                total += 4.50;
                totalAmount(total);
                isDrinkLarge = false;
            }
        }

        private void btnLibertyNights_Click(object sender, RoutedEventArgs e)
        {
            comboDeal("LIBERTY NIGHTS COMBO", "Nashville Hot", "Large Fries", "Apple Pie", 15.50);
        }

        private void btnVenetianBite_Click(object sender, RoutedEventArgs e)
        {
            comboDeal("VENETIAN BITE COMBO", "Single Roma Burger", "Mozzarella Sticks", "Tiramisu Cup", 15.50);
        }

        private void btnFiestaBox_Click(object sender, RoutedEventArgs e)
        {
            multiChoiceComboDeal("FIESTA BOX COMBO", "Baja Chicken", "Oaxaca Veggie", "Loaded Nachos", "Churros", 17.50);
        }

        private void btnKyotoNights_Click(object sender, RoutedEventArgs e)
        {
            comboDeal("KYOTO NIGHTS COMBO", "Kyoto Katsu Burger", "Spring Rolls", "Mochi Ice Cream", 15.50);
        }

        private void btnGroupTour_Click(object sender, RoutedEventArgs e)
        {
            //var groupTourWindow = new GroupTourWindow(this);
            //groupTourWindow.ShowDialog();


            //total += 40.00;

            //txtPrices.Text += "$" + total.ToString() + ".00\n\n\n\n\n\n";
            //totalAmount(total);
            //orderLinesViaConsole();
        }

        private void btnMozzarellaSticksAddOn_Click(object sender, RoutedEventArgs e)
        {
            comboCounter("Mozzarella Sticks");
        }

        private void btnSpringRollsAddOn_Click(object sender, RoutedEventArgs e)
        {
            comboCounter("Spring Rolls");
        }

        private void btnApplePieAddOn_Click(object sender, RoutedEventArgs e)
        {
            comboCounter("Apple Pie");
        }

        private void btnChurrosAddOn_Click(object sender, RoutedEventArgs e)
        {
            comboCounter("Churros");
        }

        private void comboDeal(string title, string burger, string side, string dessert, double price)
        {
            txtOutput.Text += title + "\n";
            txtOutput.Text += burger + "\n";
            txtOutput.Text += side + "\n";
            txtOutput.Text += dessert + "\n";
            txtOutput.Text += "Small Drink\n";
            total += price;

            txtPrices.Text += "$" + price.ToString() + "0\n\n\n\n\n";
            totalAmount(total);
            Console.WriteLine("comboDeal:");
            orderLinesViaConsole();
        }

        private void multiChoiceComboDeal(string title, string burger1, string burger2, string side, string dessert, double price)
        {
            //string finalBurgerChoice = "";

            //BurgerChoiceWindow burgerChoice = new BurgerChoiceWindow();
            //burgerChoice.btnOptionOne.Content = burger1;
            //burgerChoice.btnOptionTwo.Content = burger2;
            //burgerChoice.ShowDialog();

            //if (burgerChoice.isOptionOne == true)
            //{
            //    finalBurgerChoice = burger1;
            //    burgerChoice.isOptionOne = false;
            //}
            //else if (burgerChoice.isOptionTwo == true)
            //{
            //    finalBurgerChoice = burger2;
            //    burgerChoice.isOptionTwo = false;
            //}
            //else
            //{
            //    finalBurgerChoice = burger1;
            //}

            //txtOutput.Text += title + "\n";
            //txtOutput.Text += finalBurgerChoice + "\n";
            //txtOutput.Text += side + "\n";
            //txtOutput.Text += dessert + "\n";
            //txtOutput.Text += "Small Drink\n";
            //total += price;

            //txtPrices.Text += "$" + price.ToString() + "0\n\n\n\n\n";

            Console.WriteLine("multiChoiceComboDeal: ");
            orderLinesViaConsole();
            totalAmount(total);
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            //var paymentWindow = new PaymentWindow(this, total);
            //paymentWindow.ShowDialog();
        }

        private void comboCounter(string menuItem)
        {
            string sourceText = txtOutput.Text;
            string wordToCount = "COMBO";

            int comboCount = sourceText.Split(new string[] { wordToCount }, StringSplitOptions.None).Length - 1;

            if (AddOnCount == comboCount || comboCount == 0)
            {
                MessageBox.Show("You have added the maximum amount of add-ons for your combos.");
            }
            else
            {
                // selectMenuItemFromDB(menuItem, 3.00);
                AddOnCount++;
            }
            orderLinesViaConsole();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            orderLines.RemoveAt(orderLines.Count - 1);
            prices.RemoveAt(prices.Count - 1);
            txtOutput.Text = string.Join("\n", orderLines);
            txtPrices.Text = string.Join("\n", prices.Select(p => p.ToString("C")));
            total = prices.Sum();
            txtTotal.Text = total.ToString("C");
            orderLinesViaConsole();
        }

        private void discount(double percentage)
        {
            if (isDiscountedTenPercent == true)
            {
                MessageBox.Show("You have already applied a 10% discount to this order.");
                return;
            }
            else
            {
                double percent = percentage / 100;
                double discountedAmount = total * percent;
                double discountedTotal = total - discountedAmount;

                txtOutput.Text = $"{percentage}% discount Applied.\n\n" + txtOutput.Text;
                txtPrices.Text = "\n\n" + txtPrices.Text;

                total = discountedTotal;
                txtTotal.Text = discountedTotal.ToString("C");

                isDiscountedTenPercent = true;
            }
        }

        private void btnTenPercentDiscount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Is this order completed?", "Discount", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                discount(10.00);
            }
            else
            {
                MessageBox.Show("Discount not applied, please finish the order before applying the discount");
            }
        }

        private void btnStaffMeal_Click(object sender, RoutedEventArgs e)
        {
            //if (isStaffMealSelected == false)
            //{
            //    var staffMealWindow = new StaffMealWindow(this);
            //    staffMealWindow.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You have already selected a staff meal for this order.");
            //}
        }
    }
}
