﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_FullyWorkingCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        protected bool haveCalculated = false;

        /*
         *  The following buttons are for performing the operations
         */

        private static string additionOperation(string eq1, string eq2)
        {
            // Addition
            double result = Convert.ToDouble(eq1) + Convert.ToDouble(eq2);
            return result.ToString();
        }

        private static string subtractionOperation(string eq1, string eq2)
        {
            // Subtraction
            double result = Convert.ToDouble(eq1) - Convert.ToDouble(eq2);
            return result.ToString();
        }

        private static string multiplicationOperation(string eq1, string eq2)
        {
            // Multiplication
            double result = Convert.ToDouble(eq1) * Convert.ToDouble(eq2);
            return result.ToString();
        }

        private static string divisionOperation(string eq1, string eq2)
        {
            // Division
            double result = Convert.ToDouble(eq1) / Convert.ToDouble(eq2);
            return result.ToString();
        }

        private static string modulusOperation(string eq1, string eq2)
        {
            // Modulus
            double result = Convert.ToDouble(eq1) % Convert.ToDouble(eq2);
            return result.ToString();
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {
            if (resultBox.Text.Length == 0) return;

            if (haveCalculated)
            {
                resultBox.Text = "";
                haveCalculated = false;
                return;
            }

            char lastChar = resultBox.Text[resultBox.Text.Length - 1];

            if (IsOperator(lastChar))
            {
                if (resultBoxTemp.Text.Length == 0)
                {
                    resultBoxTemp.Text += resultBox.Text.Remove(resultBox.Text.Length - 1, 1) + lastChar;
                    resultBox.Text = "";
                }
                else if (IsOperator(resultBoxTemp.Text[resultBoxTemp.Text.Length - 1]) && resultBox.Text.Length < 2)
                {
                    resultBoxTemp.Text = resultBoxTemp.Text.Remove(resultBoxTemp.Text.Length - 1, 1) + lastChar;
                    resultBox.Text = "";
                }
                else
                {
                    resultBoxTemp.Text += resultBox.Text.Remove(resultBox.Text.Length - 1, 1) + lastChar;
                    resultBox.Text = "";
                }
            }
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '×' || c == '÷' || c == '%';
        }

        private string PerformOperation(string equation)
        {
            // Do an operation
            // Sample equation: 1+2+3+4+5
            if (resultBoxTemp.Text.Length == 0) return equation;

            string[] operands = { "+", "-", "×", "÷", "%" };
            string[] numbers = equation.Split(operands, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = equation.Split(numbers, StringSplitOptions.RemoveEmptyEntries);

            string result = numbers[0];

            if (operators.Length >= numbers.Length)
            {
                operators = operators.Take(operators.Count() - 1).ToArray();
            }

            for (int i = 0; i < operators.Length; i++)
            {
                switch (operators[i])
                {
                    case "+":
                        result = additionOperation(result, numbers[i + 1]);
                        break;
                    case "-":
                        result = subtractionOperation(result, numbers[i + 1]);
                        break;
                    case "×":
                        result = multiplicationOperation(result, numbers[i + 1]);
                        break;
                    case "÷":
                        result = divisionOperation(result, numbers[i + 1]);
                        break;
                    case "%":
                        result = modulusOperation(result, numbers[i + 1]);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }


        /*
         * The following buttons are for the Operand
         */

        private void button20_Click(object sender, EventArgs e)
        {
            resultBox.Text += "+";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            resultBox.Text += "×";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            resultBox.Text += "-";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            resultBox.Text += "÷";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            resultBox.Text += "%";
        }


        /*
         * The following buttons are for the numbers
         */

        private void button22_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0 || resultBoxTemp.Text.Length != 0)
            {
                resultBox.Text += "0";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            resultBox.Text += "1";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            resultBox.Text += "2";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            resultBox.Text += "3";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            resultBox.Text += "4";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            resultBox.Text += "5";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            resultBox.Text += "6";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            resultBox.Text += "7";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resultBox.Text += "8";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            resultBox.Text += "9";
        }


        /*
         * The following buttons are for Clear, Clear Entry, Backspace, and Decimal
         */

        private void button1_Click(object sender, EventArgs e)
        {
            resultBoxTemp.Text = "";
            resultBox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0)
            {
                resultBox.Text = resultBox.Text.Remove(resultBox.Text.Length - 1, 1);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0 && !resultBox.Text.Contains("."))
            {
                resultBox.Text += ".";
            }
        }


        /*
         *  The following buttons are for performing keyboard Press
         */
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    button22_Click(sender, e);
                    break;
                case '1':
                    button17_Click(sender, e);
                    break;
                case '2':
                    button18_Click(sender, e);
                    break;
                case '3':
                    button19_Click(sender, e);
                    break;
                case '4':
                    button13_Click(sender, e);
                    break;
                case '5':
                    button14_Click(sender, e);
                    break;
                case '6':
                    button15_Click(sender, e);
                    break;
                case '7':
                    button9_Click(sender, e);
                    break;
                case '8':
                    button10_Click(sender, e);
                    break;
                case '9':
                    button11_Click(sender, e);
                    break;
                case '.':
                    button23_Click(sender, e);
                    break;
                case '\b':
                    button4_Click(sender, e);
                    break;
                case '+':
                    button20_Click(sender, e);
                    break;
                case '*':
                    button12_Click(sender, e);
                    break;
                case '-':
                    button16_Click(sender, e);
                    break;
                case '/':
                    button8_Click(sender, e);
                    break;
                case '%':
                    button3_Click_1(sender, e);
                    break;
                case '=':
                    button24_Click(sender, e);
                    break;
                case '\r':
                    button24_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            // When the app load dont focus on any button
            this.ActiveControl = null;
            this.ActiveControl = button24;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0)
            {
                resultBoxTemp.Text += resultBox.Text;
                resultBox.Text = "";
            }

            string equation = resultBoxTemp.Text;
            equation = PerformOperation(equation);

            resultBoxTemp.Text = "";
            resultBox.Text = equation;

            haveCalculated = true;
        }
    }
}
