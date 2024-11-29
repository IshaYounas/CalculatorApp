using System;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
// complies and runs well in both Windows and Android. No errors. No issues

namespace CalculatorApp
{
    public partial class CurrencyConversionPage : ContentPage
    {
        //declare variables
        private string fromCurrency = "Euro";
        private string toCurrency = "Pound";
        private string currentInput = "";

        // Constructor
        public CurrencyConversionPage()
        {
            InitializeComponent();
            this.LayoutChanged += OnWindowChange;
            RetrieveScreenDimensions();
            AdjustLayoutBasedOnSize(this.Width, this.Height);
        } //UnitConversionPage

        // methods
        private async void FromCurrencyBtn_Clicked(object sender, EventArgs e)
        {
            string UnitF = await DisplayActionSheet("Select From Unit", "Cancel", null, "Euro", "Pound", "United States Dollar", "Canadian Dollar", "Pakistani Rupee", "Indian Rupee", "United Arab Emirates Dirham", "Swiss Franc");
            if (UnitF != "Cancel" && UnitF != null)
            {
                fromCurrency = UnitF;
                FromCurrencyBtn.Text = fromCurrency;
                ConvertValue();
            } //if
        } //FromCurrencyBtn_Clicked()
        private async void ToCurrencyBtn_Clicked(object sender, EventArgs e)
        {
            string unitT = await DisplayActionSheet("Select From Unit", "Cancel", null, "Euro", "Pound", "United States Dollar", "Canadian Dollar", "Pakistani Rupee", "Indian Rupee", "United Arab Emirates Dirham", "Swiss Franc");
            if (unitT != "Cancel" && unitT != null)
            {
                toCurrency = unitT;
                ToCurrencyBtn.Text = toCurrency;
                ConvertValue();
            } //if
        } //ToCurrencyBtn_Clicked()

        // methods - buttons
        private void number_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                UserInput.Text += button.Text;
            } //if
        } //number_Clicked()

        private void decimal_Clicked(object sender, EventArgs e)
        {
            if (!UserInput.Text.Contains("."))
            {
                UserInput.Text += ".";
            }
        } //DecimalBtn_Clicked()

        // methods
        private void UserInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConvertValue();
        } //UserInput_TextChanged()

        private void ConvertValue()
        {
            if (double.TryParse(UserInput.Text, out double value))
            {
                double result = 0.0;

                // Unit conversion logic
                if (fromCurrency == "Euro")
                {
                    result = ConvertFromEuro(value);
                } //if

                else if (fromCurrency == "Pound")
                {
                    result = ConvertFromPound(value);
                } //else if

                else if (fromCurrency == "United States Dollar")
                {
                    result = ConvertFromUSD(value);
                } //else if

                else if (fromCurrency == "Canadian Dollar")
                {
                    result = ConvertFromCAD(value);
                } //else if

                else if (fromCurrency == "Pakistani Rupee")
                {
                    result = ConvertFromPKR(value);
                } //else if

                else if (fromCurrency == "Indian Rupee")
                {
                    result = ConvertFromINR(value);
                } //else if

                else if (fromCurrency == "United Arab Emirates Dirham")
                {
                    result = ConvertFromUAED(value);
                } //else if

                else if (fromCurrency == "Swiss Franc")
                {
                    result = ConvertFromCHF(value);
                } //else if

                ConversionResult.Text = result.ToString("F3");
            } //if
            else
            {
                ConversionResult.Text = "Invalid Input";
            } //else
        } //ConvertValue()

        private double ConvertFromEuro(double value)
        {
            switch (toCurrency)
            {
                case "Pound":
                    return value * 0.83;

                case "United States Dollar":
                    return value * 1.08;

                case "Canadian Dollar":
                    return value * 1.51;

                case "Pakistani Rupee":
                    return value * 300.07;

                case "Indian Rupee":
                    return value * 90.89;

                case "United Arab Emirates Dirham":
                    return value * 3.97;

                case "Swiss Franc":
                    return value * 0.94;

                default:
                    return value;
            }; //switch
        } //ConvertFromEuro()

        private double ConvertFromPound(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 1.20;

                case "United States Dollar":
                    return value * 1.29;
                
                case "Canadian Dollar":
                    return value * 1.81;
                
                case "Pakistani Rupee":
                    return value * 361.07;
                
                case "Indian Rupee":
                    return value * 109.32;
                
                case "United Arab Emirates Dirham":
                    return value * 4.78;
                
                case "Swiss Franc":
                    return value * 1.13;
                
                default:
                    return value;
            } //switch
        } //ConvertFromPound()

        private double ConvertFromUSD(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 0.92;

                case "Pound":
                    return value * 0.78;
                
                case "Canadian Dollar":
                    return value * 1.39;
                
                case "Pakistani Rupee":
                    return value * 277.7;
                
                case "Indian Rupee":
                    return value * 84.06;
                
                case "United Arab Emirates Dirham":
                    return value * 3.67;
                
                case "Swiss Franc":
                    return value * 0.87;
                
                default:
                    return value;
            } //switch
        } //ConvertFromUSD

        private double ConvertFromCAD(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 0.66;
               
                case "Pound":
                    return value * 0.55;
                
                case "United States Dollar":
                    return value * 0.72;
                
                case "Pakistani Rupee":
                    return value * 199.48;
                
                case "Indian Rupee":
                    return value * 60.38;
                
                case "United Arab Emirates Dirham":
                    return value * 2.64;
                
                case "Swiss Franc":
                    return value * 0.62;
                
                default:
                    return value;
            } //switch
        } //ConvertFromCAD()

        private double ConvertFromPKR(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 0.0033;
                
                case "Pound":
                    return value * 0.0028;
                
                case "United States Dollar":
                    return value * 0.0036;
                
                case "Canadian Dollar":
                    return value * 0.0050;
                
                case "Indian Rupee":
                    return value * 0.30;
                
                case "United Arab Emirates Dirham":
                    return value * 0.013;
                
                case "Swiss Franc":
                    return value * 0.0031;
                
                default:
                    return value;
            } //switch
        } //ConvertFromPKR()

        private double ConvertFromINR(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 0.011;
                
                case "Pound":
                    return value * 0.0091;
                
                case "United States Dollar":
                    return value * 0.012;
                
                case "Canadian Dollar":
                    return value * 0.017;
                
                case "Pakistani Rupee":
                    return value * 3.30;
                
                case "United Arab Emirates Dirham":
                    return value * 0.044;
                
                case "Swiss Franc":
                    return value * 0.01;
                
                default:
                    return value;
            } //switch 
        } //ConvertFromINR()

        private double ConvertFromUAED(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 0.25;
                
                case "Pound":
                    return value * 0.21;
                
                case "United States Dollar":
                    return value * 0.27;
                
                case "Canadian Dollar":
                    return value * 0.38;
                
                case "Pakistani Rupee":
                    return value * 75.61;
                
                case "Indian Rupee":
                    return value * 22.89;
                
                case "Swiss Franc":
                    return value * 0.24;
                
                default:
                    return value;
            } //switch
        } //ConvertFromUAED()

        private double ConvertFromCHF(double value)
        {
            switch (toCurrency)
            {
                case "Euro":
                    return value * 1.07;

                case "Pound":
                    return value * 0.89;

                case "United States Dollar":
                    return value * 1.15;

                case "Canadian Dollar":
                    return value * 1.6;

                case "Pakistani Rupee":
                    return value * 319.82;

                case "Indian Rupee":
                    return value * 96.88;

                case "United Arab Emirates Dirham":
                    return value * 4.23;

                default:
                    return value;
            } //switch
        } //ConvertFromCHF()

        // methods - button
        private void clear_Clicked(object sender, EventArgs e)
        {
            // clearing
            currentInput = "";
            UserInput.Text = "";
            ConversionResult.Text = "";
        } //Clear_Clicked()

        private void delete_Clicked(object sender, EventArgs e)
        {
            // Check if there is any text in UserInput
            if (!string.IsNullOrEmpty(UserInput.Text))
            {
                UserInput.Text = UserInput.Text.Remove(UserInput.Text.Length - 1);
                currentInput = UserInput.Text;
            } //if
        } //delete_Clicked()


        //  methods
        private void Display()
        {
            UserInput.Text = currentInput;
        } //Display()

        private void RetrieveScreenDimensions()
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            double displayHeight = displayInfo.Height;
            double displayWidth = displayInfo.Width;
            widthDisplay.Text = displayWidth.ToString();
            heightDisplay.Text = displayHeight.ToString();
        } //RetrieveScreenDimensions()

        private void OnWindowChange(object? sender, EventArgs e)
        {
            widthDisplay.Text = this.Width.ToString();
            heightDisplay.Text = this.Height.ToString();
            AdjustLayoutBasedOnSize(this.Width, this.Height);
        } //OnWindowChange()

        private void AdjustLayoutBasedOnSize(double width, double height)
        {
            double scaleFactor = Math.Min(width / 400, height / 800);
            UserInput.FontSize = 20 * scaleFactor;
            ConversionResult.FontSize = 20 * scaleFactor;

            foreach (var button in GridPageContent.Children.OfType<Button>())
            {
                button.FontSize = 25 * scaleFactor;
                button.HeightRequest = 82 * scaleFactor;
                button.WidthRequest = 82 * scaleFactor;
            }

            MainLayout.Padding = new Thickness(8 * scaleFactor);
            GridPageContent.RowSpacing = 10 * scaleFactor;
            GridPageContent.ColumnSpacing = 10 * scaleFactor;
        } //AdjustLayoutBasedOnSize() 
    } //class
} //namespace

