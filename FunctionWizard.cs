using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgebraicExpressionsTranslation
{
    public partial class FunctionWizard : Form
    {
        public string inputString = String.Empty;

        public FunctionWizard()
        {
            InitializeComponent();
        }

        private bool CheckSyntaxError(string inputString) // Метод для проверки правильности введенной пользователем функции
        {
            bool syntaxError = false;

            string[] prohibitedSymbolsCombination = {"+-", "++", "+*", "+/",
                                        "-+", "--", "-*", "-/",
                                        "*+", "*-", "**", "*/",
                                        "/+", "/-", "/*", "//",

                                        "(+", "(-", "(*", "(/",
                                        "+)", "-)", "*)", "/)",
            
                                        "sinsin", "sincos", "sinsqrt", "sinln", "sin+", "sin-", "sin*", "sin/", "sin)",
                                        "cossin", "coscos", "cossqrt", "cosln", "cos+", "cos-", "cos*", "cos/", "cos)",
                                        "sqrtsin", "sqrtcos", "sqrtsqrt", "sqrtln", "sqrt+", "sqrt-", "sqrt*", "sqrt/", "sqrt)",
                                        "lnsin", "lncos", "lnsqrt", "lnln", "ln+", "ln-", "ln*", "ln/", "ln)"};

            foreach (string symbolPair in prohibitedSymbolsCombination)
            {
                if (inputString.Contains(symbolPair))
                {
                    syntaxError = true;
                    break;
                }
            }
            return syntaxError;
        }

        private string TransformToA1Algorithm(string inputString)
        {
            string transformedString = inputString;

            Dictionary<string, string> alphabetA1 = new Dictionary<string, string>()
            {
                {"sin", "a"},
                {"cos", "b"},
                {"sqrt", "c"},
                {"ln", "d"}
            };

            foreach (KeyValuePair<string, string> keyValuePair in alphabetA1)
            {
                if (transformedString.Contains(keyValuePair.Key))
                {
                    transformedString = transformedString.Replace(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return transformedString;
        }

        public string TransformToA2Algorithm(string inputString)
        {
            string transformedString = inputString;
            char[] englishAlphabet = "ABCDFFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int key = 1;

            Dictionary<int, string> alphabetA2 = new Dictionary<int, string>();

            foreach (char value in englishAlphabet) // Сформировали словарь из индекса и соответствующей ему буквы
            {
                alphabetA2.Add(key, value.ToString());
                key++;
            }

            string pattern = @"\d{1,}"; // Паттерн для поиска числового значения
            Regex rgx = new Regex(pattern);

            foreach (Match match in rgx.Matches(transformedString)) // Замена совпадений в исходной строке
            {
                Console.WriteLine(match.Value);
                transformedString = transformedString.Replace(match.Value, alphabetA2.ElementAt(match.Index).Value);
            }
            return transformedString;
        }


        private void valueButton_Click(object sender, EventArgs e) // Обработчик кнопок, вводящих значения
        {
            Button numberButton = (Button)sender;
            inputText.Text += numberButton.Text;
        }

        private void backSpaceButton_Click(object sender, EventArgs e) // Обработчик кнопки Backspace
        {
            bool lastSymbolOfStringIsLetter = true;
            char lastSymbolOfString;

            if (inputText.Text.Length != 0) // Пока строка не пуста
            {
                do
                {
                    inputText.Text = inputText.Text.Remove(inputText.Text.Length - 1); // Удаляем последний элемент строки
                    if (inputText.Text.Length != 0)
                        lastSymbolOfString = inputText.Text[inputText.Text.Length - 1];
                    else
                        lastSymbolOfString = ' ';

                    if (Char.IsLetter(lastSymbolOfString)) // И если последний элемент строки это текстовый символ, то продолжаем удаление, иначе останавливаемся
                        lastSymbolOfStringIsLetter = true;
                    else
                        lastSymbolOfStringIsLetter = false;

                } while (lastSymbolOfStringIsLetter);
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            inputText.Text = String.Empty;
        }

        private void enterButton_Click(object sender, EventArgs e) // Обработчик кнопки задания функции
        {
            inputString = inputText.Text;

            if (CheckSyntaxError(inputString))
            {
                MessageBox.Show("Обнаружена синтаксическая ошибка, проверьте введеную функцию");
                inputString = String.Empty;
            }
            else
            {
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) // Обработчик кнопки отмены
        {
            Close();
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            if (CheckSyntaxError(inputText.Text))
            {
                MessageBox.Show("Обнаружена синтаксическая ошибка, проверьте введеную функцию");
                inputString = String.Empty;
                inputText.Text = String.Empty;
            }
            else
            {
                inputText.Text = TransformToA1Algorithm(inputText.Text);
                inputText.Text = TransformToA2Algorithm(inputText.Text);
            }
        }
    }
}
