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
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Single Olympian", 12.50);
        }

        private void btnDoubleOlympian_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Double Olympian", 14.50);
        }

        private void btnSingleParisian_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Single Parisian", 12.50);
        }

        private void btnDoubleParisian_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Double Parisian", 14.50);
        }

        private void btnSingleRoma_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Single Roma", 12.50);
        }

        private void btnDoubleRoma_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Double Roma", 14.50);
        }

        private void btnSingleMatador_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Single Matador", 12.50);
        }

        private void btnDoubleMatador_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Double Matador", 14.50);
        }

        private void btnSingleKaiser_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Single Kaiser", 12.50);
        }

        private void btnDoubleKaiser_Click(object sender, RoutedEventArgs e)
        {
            // MakeComboWindow makeCombo = new MakeComboWindow();
            comboOption("Double Kaiser", 14.50);
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
            printMenuItem("Small Fries", 3.0);
        }

        private void btnMediumFries_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Medium Fries", 4.5);
        }

        private void btnLargeFries_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Large Fries", 5.0);
        }

        private void btnGarlicBread_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Garlic Bread", 4.5);
        }

        private void btnMozzarellaStick_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Mozzarella Sticks", 5.0);
        }

        private void btnSpringRoll_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Spring Rolls", 5.0);
        }

        private void btnLoadedNachos_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Loaded Nachos", 6.5);
        }

        private void btnPoutine_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Poutine", 6.5);
        }

        private void btnApplePie_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Apple Pie", 4.5);
        }

        private void btnChurros_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Churros", 4.5);
        }

        private void btnTiramisuCup_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Tiramisu Cup", 5.0);
        }

        private void btnMochiIceCream_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Mochi Ice Cream", 5.0);
        }

        private void btnCremeBrulee_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Creme Brulee", 6.5);
        }

        private void btnBaklavaBites_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Baklava Bites", 6.5);
        }

        private void btnMatchaGreenTeaShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Matcha Green Tea Shake", 6.0);
        }

        private void btnChurroCinnamonShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Churro Cinnamon Shake", 6.0);
        }

        private void btnMangoLassiShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Mango Lassi Shake", 6.0);
        }

        private void btnDulceDeLecheShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Dulce De Leche Shake", 6.0);
        }

        private void btnDubaiChocolateShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Dubai Chocolate Shake", 6.0);
        }

        private void btnPandanCoconutShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Pandan Coconut Shake", 6.0);
        }

        private void btnTiramisuShake_Click(object sender, RoutedEventArgs e)
        {
            printMenuItem("Tiramisu Shake", 6.0);
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

        private void comboOption(string burger, double price)
        {
            //string chosenCombo;

            //// // MakeComboWindow makeCombo = new MakeComboWindow();
            //makeCombo.ShowDialog();

            //if (makeCombo.makeLarge == true)
            //{
            //    chosenCombo = burger.ToUpper() + " LARGE COMBO\n" +
            //        burger + " Burger \n" +
            //        "Large Fries \n" +
            //        "Large Drink \n";

            //    txtOutput.Text += chosenCombo;
            //    orderLines.Add(chosenCombo);

            //    txtPrices.Text += "$" + (price + 7.5).ToString() + ".00\n\n\n\n";
            //    total += price + 7.5;
            //    prices.Add(price + 7.5);
            //    totalAmount(total);

            //    makeCombo.makeLarge = false;
            //    makeCombo.Close();
            //}
            //else if (makeCombo.makeMedium == true)
            //{
            //    chosenCombo = burger.ToUpper() + " MEDIUM COMBO\n" +
            //        burger + " Burger \n" +
            //        "Medium Fries \n" +
            //        "Medium Drink \n";

            //    txtOutput.Text += chosenCombo;
            //    orderLines.Add(chosenCombo);

            //    txtPrices.Text += "$" + (price + 5).ToString() + "0\n\n\n\n";
            //    total += price + 5;
            //    prices.Add(price + 5);
            //    totalAmount(total);

            //    makeCombo.makeMedium = false;
            //    makeCombo.Close();
            //}
            //else if (makeCombo.makeJustBurger == true)
            //{
            //    chosenCombo = burger + " Burger \n";
            //    txtOutput.Text += chosenCombo;
            //    orderLines.Add(chosenCombo);

            //    txtPrices.Text += "$" + price + "0\n";
            //    total += price;
            //    prices.Add(price);
            //    totalAmount(total);

            //    makeCombo.makeJustBurger = false;
            //    makeCombo.Close();
            //}
            //else
            //{
            //    makeCombo.Close();
            //}
            //Console.WriteLine("Combo:");
            //orderLinesViaConsole();
        }

        private void printMenuItem(string menuItem, double price)
        {
            txtOutput.Text += menuItem + "\n";
            orderLines.Add(menuItem);
            prices.Add(price); // <- ensure parallel list kept in sync
            Console.WriteLine(orderLines);

            if (price % 1 != 0)
                txtPrices.Text += "$" + price.ToString() + "0\n";
            else
                txtPrices.Text += "$" + price.ToString() + ".00\n";

            total += price;
            totalAmount(total);
            Console.WriteLine("printMenuItem:");
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
            var groupTourWindow = new GroupTourWindow(this);
            groupTourWindow.ShowDialog();


            total += 40.00;

            txtPrices.Text += "$" + total.ToString() + ".00\n\n\n\n\n\n";
            totalAmount(total);
            orderLinesViaConsole();
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
            string finalBurgerChoice = "";

            BurgerChoiceWindow burgerChoice = new BurgerChoiceWindow();
            burgerChoice.btnOptionOne.Content = burger1;
            burgerChoice.btnOptionTwo.Content = burger2;
            burgerChoice.ShowDialog();

            if (burgerChoice.isOptionOne == true)
            {
                finalBurgerChoice = burger1;
                burgerChoice.isOptionOne = false;
            }
            else if (burgerChoice.isOptionTwo == true)
            {
                finalBurgerChoice = burger2;
                burgerChoice.isOptionTwo = false;
            }
            else
            {
                finalBurgerChoice = burger1;
            }

            txtOutput.Text += title + "\n";
            txtOutput.Text += finalBurgerChoice + "\n";
            txtOutput.Text += side + "\n";
            txtOutput.Text += dessert + "\n";
            txtOutput.Text += "Small Drink\n";
            total += price;

            txtPrices.Text += "$" + price.ToString() + "0\n\n\n\n\n";

            Console.WriteLine("multiChoiceComboDeal: ");
            orderLinesViaConsole();
            totalAmount(total);
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            var paymentWindow = new PaymentWindow(this, total);
            paymentWindow.ShowDialog();
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
                printMenuItem(menuItem, 3.00);
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
            if (isStaffMealSelected == false)
            {
                var staffMealWindow = new StaffMealWindow(this);
                staffMealWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have already selected a staff meal for this order.");
            }
        }
    }
}
