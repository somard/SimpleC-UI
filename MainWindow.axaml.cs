using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;

namespace SimpleUIApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Attach event handlers programmatically
            TextBox1.GotFocus += TextBox_GotFocus;
            TextBox1.LostFocus += TextBox_LostFocus;
            TextBox2.GotFocus += TextBox_GotFocus;
            TextBox2.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_GotFocus(object sender, GotFocusEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Enter first value" || textBox.Text == "Enter second value")
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name == "TextBox1" ? "Enter first value" : "Enter second value";
            }
        }

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBox1.Text, out double value1) && double.TryParse(TextBox2.Text, out double value2))
            {
                double result = value1 + value2;
                ResultLabel.Text = $"Result: {result}";
            }
            else
            {
                ResultLabel.Text = "Please enter valid numbers.";
            }
        }
    }
}
