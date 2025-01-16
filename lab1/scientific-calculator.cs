using System;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string operation = cmbOperation.SelectedItem.ToString();
            if (double.TryParse(txtNumber.Text, out double number))
            {
                double result = 0;
                string operationName = "";

                switch (operation)
                {
                    case "Sine":
                        result = Math.Sin(number);
                        operationName = "Sine";
                        break;
                    case "Cosine":
                        result = Math.Cos(number);
                        operationName = "Cosine";
                        break;
                    case "Tangent":
                        result = Math.Tan(number);
                        operationName = "Tangent";
                        break;
                    case "Logarithm (Base 10)":
                        if (number > 0)
                        {
                            result = Math.Log10(number);
                            operationName = "Log10";
                        }
                        else
                        {
                            MessageBox.Show("Logarithm is undefined for non-positive numbers.");
                            return;
                        }
                        break;
                    case "Natural Logarithm (Base e)":
                        if (number > 0)
                        {
                            result = Math.Log(number);
                            operationName = "Natural Log";
                        }
                        else
                        {
                            MessageBox.Show("Natural logarithm is undefined for non-positive numbers.");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid operation selected.");
                        return;
                }

                // Add the result to the DataGridView
                dataGridViewResults.Rows.Add(operationName, number, result);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
    }
}
