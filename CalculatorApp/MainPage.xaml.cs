using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
// complies and runs well in both Windows and Android. No errors. No issues

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        // declare variables
        private string currentInput = "";
        private string operation = "";
        private List<string> calculateHistory = new List<string>(); //array
        public MainPage()
        {
            InitializeComponent();
            this.LayoutChanged += OnWindowChange;
            RetrieveScreenDimensions();
            AdjustLayoutBasedOnSize(this.Width, this.Height);
            Result.Text = "Output";
        } // MainPage()

        // methods for conversion
        private async void Units_Clicked(object sender, EventArgs e)
        {
            // calling the UnitConversionPage
            await Navigation.PushAsync(new UnitConversionPage());
        }

        private async void Currency_Clicked(object sender, EventArgs e)
        {
            // calling the CurrencyConversionPage
            await Navigation.PushAsync(new CurrencyConversionPage());
        }

        // methods for buttons
        private void clear_Clicked(object sender, EventArgs e)
        {
            // clearing
            currentInput = "";
            Input.Text = "";
            Result.Text = "Output";
        } //Clear_Clicked()

        private void delete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (currentInput.Length > 1)
                {
                    // deleting last digit character
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                } //if

                else
                {
                    // the input becomes empty
                    currentInput = "";
                } //else

                Display(); // calling the display method
            } //if
        } //delete_Clicked()

        private void modulus_Clicked(object sender, EventArgs e)
        {
            // making sure the user's first input isn't % && % isn't inputted multiple times
            if (!string.IsNullOrEmpty(currentInput) && !currentInput.EndsWith(" "))
            {
                // adding the modulus symbol to the input
                currentInput += " % ";
            } //if

            Display();
        } //modulus_Clicked

        private void operation_Clicked(object sender, EventArgs e)
        {
            var button_clicked = (Button)sender;
            operation = button_clicked.Text;

            if (!string.IsNullOrEmpty(currentInput) && !currentInput.EndsWith(" "))
            {
                currentInput += " " + operation + " ";
            } //if

            // if the string is empty before typing in an operator
            else if (string.IsNullOrEmpty(currentInput)) 
            {
                DisplayAlert("Error", "Enter a number first", "Ok");
            } //else if
            Display();
        } //operation_Clicked()

        private void num_Clicked(object sender, EventArgs e)
        {
            // casting sender to a button 
            var btn_clicked = (Button)sender;

            currentInput += btn_clicked.Text;

            Display();
        } //num_Clicked()

        private void decimal_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput) || currentInput.EndsWith(" "))
            {
                currentInput += "0.";
            } //if
            
            // ensuring that there is no whitespace left
            else if (!currentInput.TrimEnd().EndsWith("."))
            {
                currentInput += ".";
            } //else if

            Display();
        } //decimal_Clicked()

        private void sqroot_Clicked(object sender, EventArgs e)
        {
            // adding the square root symbol to the input
            currentInput += "√";
            Display();
        } //sqroot_Clicked()

        private void equal_Clicked(object sender, EventArgs e)
        {
            // make sure the input involves the symbol
            if (currentInput.Contains("√"))
            {
                // initializing an array
                string[] root = currentInput.Split('√');
                if (root.Length > 1 && double.TryParse(root[1].Trim(), out double num)) // casting root[1] to double and removing whitespaces. Storing root[1] as num
                {
                    double answerRoot = Math.Sqrt(num); // calling the square root method/function
                    Result.Text = FormatResult(answerRoot); // calling the format result method
                    Display();
                } //if

                else
                {
                    // displaying an alert to enter a valid number
                    DisplayAlert("Error", "Enter a valid number", "Ok");
                } //else
            } //if

            else
            {
                // splitting the string into substrings. using spaces as a place to split. No empty spaces are shown/ every thing is a string
                string[] rootNum = currentInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (rootNum.Length == 0)
                       return;

                double answer = 0;
                if (double.TryParse(rootNum[0], out double firstNum))
                {
                    answer = firstNum;
                } //if

                else
                {
                    // displaying an alert about invalid input
                    DisplayAlert("Error", "Invalid input", "Ok");
                    return;
                } //else

                string currentOper = "+";

                for (int i = 1; i < rootNum.Length; i++)
                {
                    if (double.TryParse(rootNum[i], out double currentNum))
                    {
                        switch (currentOper)
                        {
                            // calculating the answer
                            case "+":
                                answer += currentNum;
                                break;

                            case "-":
                                answer -= currentNum;
                                break;

                            case "x":
                                answer *= currentNum;
                                break;

                            case "÷":

                                if (currentNum != 0) // if the answer is not 0
                                {
                                    answer /= currentNum;
                                } //if

                                else // if the answer is 0
                                {
                                    DisplayAlert("Error", "Cannot divide by zero", "Ok");
                                    return;
                                } // else

                                break;

                            case "%":
                                answer %= currentNum;
                                break;
                        } //switch
                    } //if

                    else
                    {
                        // the currentOper is equal to the default set value of "+"
                        currentOper = rootNum[i];
                    } //else
                } //for

                Result.Text = FormatResult(answer);
                Display();

                if (Result.Text != "Output")
                {
                    // adding the result to history
                    calculateHistory.Add($"{currentInput} = {Result.Text}");
                } // if
            } // else
        } //equal_Clicked()

        //  methods
        private async void History_Clicked(object sender, EventArgs e)
        {
            if (calculateHistory.Count > 0) // there is history
            {
                string content = string.Join("\n", calculateHistory); // adding/joining the content into the array
                await DisplayAlert("History", content, "Ok");
            } //if

            else // there is no history
            {
                await DisplayAlert("History", "No history to be shown", "Ok");
            } //else
        } //History_Clicked()

        private string FormatResult(double result)
        {
            if (result % 1 == 0) // if the result decimal places are all 0
            {
                return result.ToString("F0"); // formatting the result to no decimal places

            } //if

            else
            {
                return result.ToString("F2"); // formatting the result to 2 decimal places
            } //else
        } //FormatResult()

        private void Display()
        {
            Input.Text = currentInput;
        } //Display()

        private void RetrieveScreenDimensions()
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo; // getting info (height & width) about the current device 
            double displayHeight = displayInfo.Height;
            double displayWidth = displayInfo.Width;
            widthDisplay.Text = displayWidth.ToString();
            heightDisplay.Text = displayHeight.ToString();
        } //RetrieveScreenDimensions()

        private void OnWindowChange(object? sender, EventArgs e)
        {
            widthDisplay.Text = this.Width.ToString();
            heightDisplay.Text = this.Height.ToString();
            AdjustLayoutBasedOnSize(this.Width, this.Height); // calling the method
        } //OnWindowChange()

        private void AdjustLayoutBasedOnSize(double width, double height)
        {
            // ensuring the layout is not messed
            double scale = Math.Min(width / 400, height / 800); // calling the minimum method/function
            // adjusting the input and result font size to match the scale
            Input.FontSize = 30 * scale;
            Result.FontSize = 35 * scale;

            foreach (var button in GridPageContent.Children.OfType<Button>())
            {
                // adjusting the buttons to match the scale
                button.FontSize = 25 * scale;
                button.HeightRequest = 82 * scale;
                button.WidthRequest = 82 * scale;
            }
            // adjusting the main layout and the spacing in the grid to match the scale
            MainLayout.Padding = new Thickness(8 * scale);
            GridPageContent.RowSpacing = 10 * scale;
            GridPageContent.ColumnSpacing = 10 * scale;

            //TopGrid.HeightRequest = 200 * scaleFactor; // couldn't get the height adjustment to work
        } //AdjustLayoutBasedOnSize() 
    } // class
} // namespace
