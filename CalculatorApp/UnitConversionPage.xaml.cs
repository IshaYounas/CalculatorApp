using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
// complies and runs well in both Windows and Android. No errors. No issues

namespace CalculatorApp
{
    public partial class UnitConversionPage : ContentPage
    {
       /* static void main(string[] args)
        {
            //Debugger.Break();
        } // main */

        //declare variables
        private string fromUnit = "Meter";
        private string toUnit = "Kilometer";
        private string currentInput = "";		

        // Constructor
        public UnitConversionPage()
        {
            InitializeComponent();
            FromUnitBtn.Text = fromUnit;
            ToUnitBtn.Text = toUnit;
            this.LayoutChanged += OnWindowChange;
            RetrieveScreenDimensions();
            AdjustLayoutBasedOnSize(this.Width, this.Height);
        } //UnitConversionPage

        // methods
        private async void FromUnitBtn_Clicked(object sender, EventArgs e)
        {
            // DisplayActionSheet is a drop down list (HTML)
            string unitF = await DisplayActionSheet("Select From Unit", "Cancel", null, "Meter", "Kilometer", "Centimeter", "Millimeter", "Mile", "Yard", "Foot", "Inch");
            if (unitF != "Cancel" && unitF != null) 
            {
                fromUnit = unitF; 
                FromUnitBtn.Text = fromUnit;
                ConvertValue();
            } //if
        } //FromUnitBtn_Clicked()
        private async void ToUnitBtn_Clicked(object sender, EventArgs e)
        {
            //drop down list
            string unitT = await DisplayActionSheet("Select From Unit", "Cancel", null, "Meter", "Kilometer", "Centimeter", "Millimeter", "Mile", "Yard", "Foot", "Inch");
            if (unitT != "Cancel" && unitT != null)
            {
                toUnit = unitT;
                ToUnitBtn.Text = toUnit;
                ConvertValue();
            } //if
        } //ToUnitBtn_Clicked()

        // methods - buttons
        private void number_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                UserInput.Text += btn.Text;
            } //if
        } //number_Clicked()

        private void decimal_Clicked(object sender, EventArgs e)
        {
            if (!UserInput.Text.Contains(".")) // does not contain the decimal
            {
                UserInput.Text += ".";
            }
        } //DecimalBtn_Clicked()

        // methods
        private void UserInput_TextChanged(object sender, TextChangedEventArgs e) // when the user types in a number in the input box
        {
            ConvertValue(); // calling the ConvertValue method
        } //UserInput_TextChanged()

        private void ConvertValue()
        {
            if (double.TryParse(UserInput.Text, out double value))
            {
                double result = 0.0;

                // calling appropriate methods
                if (fromUnit == "Meter")
                {
                    result = ConvertFromMeter(value);
                } //if

                else if (fromUnit == "Kilometer")
                {
                    result = ConvertFromKilometer(value);
                } //else if

                else if (fromUnit == "Centimeter")
                {
                    result = ConvertFromCentimeter(value);
                } //else if

                else if (fromUnit == "Millimeter")
                {
                    result = ConvertFromMillimeter(value);
                } //else if

                else if (fromUnit == "Mile")
                {
                    result = ConvertFromMile(value);
                } //else if

                else if (fromUnit == "Yard")
                {
                    result = ConvertFromYard(value);
                } //else if

                else if (fromUnit == "Foot")
                {
                    result = ConvertFromFoot(value);
                } //else if

                else if (fromUnit == "Inch")
                {
                    result = ConvertFromInch(value);
                } //else if

                ConversionResult.Text = result.ToString("F3");
            } //if
            else
            {
                ConversionResult.Text = "Output";
            } //else
        } //ConvertValue()

        // convert from methods - calculating each unit
        private double ConvertFromMeter(double value)
        {
            switch (toUnit)
            {
                case "Kilometer":
                    return value / 1000;

                case "Centimeter":
                    return value * 100; 

                case "Millimeter":
                    return value * 1000;

                case "Mile":
                    return value * 0.000621371;

                case "Yard":
                    return value * 1.09361;

                case "Foot":
                    return value * 3.28084;

                case "Inch":
                    return value * 39.3701;

                default:
                    return value; 
            }; //switch
        } //ConvertFromMeter()

        private double ConvertFromKilometer(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value * 1000;

                case "Centimeter":
                    return value * 100000;

                case "Millimeter":
                    return value * 1000000;

                case "Mile":
                    return value * 0.621371;

                case "Yard":
                    return value * 1094;

                case "Foot":
                    return value * 3280.84;

                case "Inch":
                    return value * 39370.1;

                default:
                    return value;
            }; //switch
        } //ConvertFromKilometer()

        private double ConvertFromCentimeter(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value / 100;

                case "Kilometer":
                    return value / 100000;

                case "Millimeter":
                    return value * 10;

                case "Mile":
                    return value * 0.00000621371;

                case "Yard":
                    return value * 0.0109361;

                case "Foot":
                    return value * 0.0328084;

                case "Inch":
                    return value * 0.393701;

                default:
                    return value;
            }; //switch
        } //ConvertFromCentimeter()

        private double ConvertFromMillimeter(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value / 1000;

                case "Kilometer":
                    return value / 1000000;

                case "Centimeter":
                    return value / 10;

                case "Mile":
                    return value * 0.000000621371;

                case "Yard":
                    return value * 0.00109361;

                case "Foot":
                    return value * 0.00328084;

                case "Inch":
                    return value * 0.0393701;

                default:
                    return value;
            }; //switch
        } //ConvertFromMillimeter()

        private double ConvertFromMile(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value * 1609.34;

                case "Kilometer":
                    return value * 1.60934;

                case "Centimeter":
                    return value * 160934;

                case "Millimeter":
                    return value * 1609340;

                case "Yard":
                    return value * 1760;

                case "Foot":
                    return value * 5280;

                case "Inch":
                    return value * 63360;

                default:
                    return value;
            }; //switch
        } //ConvertFromMile()

        private double ConvertFromYard(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value * 0.9144;

                case "Kilometer":
                    return value * 0.0009144;

                case "Centimeter":
                    return value * 91.44;

                case "Millimeter":
                    return value * 914.4;

                case "Mile":
                    return value * 0.000568182;

                case "Foot":
                    return value * 3;

                case "Inch":
                    return value * 36;

                default:
                    return value;
            }; //switch
        } //ConvertFromYard()

        private double ConvertFromFoot(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value * 0.3048;

                case "Kilometer":
                    return value * 0.0003048;

                case "Centimeter":
                    return value * 30.48;

                case "Millimeter":
                    return value * 304.8;

                case "Mile":
                    return value * 0.000189394;

                case "Yard":
                    return value * 0.333333;

                case "Inch":
                    return value * 12;

                default:
                    return value;
            }; //switch
        } //ConvertFromFoot()

        private double ConvertFromInch(double value)
        {
            switch (toUnit)
            {
                case "Meter":
                    return value * 0.0254;

                case "Kilometer":
                    return value * 0.0000254;

                case "Centimeter":
                    return value * 2.54;

                case "Millimeter":
                    return value * 25.4;

                case "Mile":
                    return value * 0.0000157828;

                case "Yard":
                    return value * 0.0277778;

                case "Foot":
                    return value * 0.0833333;

                default:
                    return value;
            }; //switch
        } //ConvertFromMile()

        // methods - button
        private void clear_Clicked(object sender, EventArgs e)
        {
            // clearing
            currentInput = "";
            UserInput.Text = "";
            ConversionResult.Text = "";
        } //Clear_Clicked()

        // method is different to the MainPage.xaml.cs because it was not working if the same
        private void delete_Clicked(object sender, EventArgs e)
        {
            // Check if there is any text in UserInput
            if (!string.IsNullOrEmpty(UserInput.Text))
            {
                // deleting the last character
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

        private void Convert_Clicked(object sender, EventArgs e)
        {

        }
    } //class
} //namespace
