using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgebraicExpressionsTranslation
{
    public partial class SimpleMainForm : Form
    {
        string immutableInfixString;
        string currentInfixString;
        string postfixString;

        Dictionary<char, double> numberMeanings = new Dictionary<char, double>();
        Dictionary<string, string> functionMeanings;
        List<TextBox> textBoxesList = new List<TextBox>();

        const string stackPointerSymbol = "<";
        const string whiteSpace = " ";

        Transformation transformationFull;
        Transformation transformationTact;

        Calculation calculationFull;
        Calculation calculationTact;

        bool valuesParsed = false;

        public SimpleMainForm()
        {
            InitializeComponent();
        }

        private void UpdateTransformation()
        {
            transformationTact = new Transformation(immutableInfixString, isTactMode: true);
            transformationFull = new Transformation(immutableInfixString, isTactMode: false);
        }

        private void UpdateCalculation()
        {
            //calculationTact = new Calculation(postfixString, isTactMode: true);
            //calculationFull = new Calculation(postfixString, isTactMode: false);
        }

        private void functionWizardButton_Click(object sender, EventArgs e) // Обработчик мастера функций
        {
            SimpleFunctionWizard simpleFunctionWizard = new SimpleFunctionWizard();

            simpleFunctionWizard.FormClosing += (sfw_sender, sfw_e) =>
            {
                //Обновляем переменную основной формы при закрытии
                if (simpleFunctionWizard.GetInputString().Length != 0)
                {
                    immutableInfixString = simpleFunctionWizard.GetInputString();
                    currentInfixString = simpleFunctionWizard.GetInputString();
                    immutableInfixText.Text = immutableInfixString;

                    functionsMeaningsListBox.Items.Clear();

                    functionMeanings = simpleFunctionWizard.GetFunctionMeanings(); // Возвращаем пару словарь пар для функций (замена-заменяемое)

                    foreach (KeyValuePair<string, string> keyValuePair in functionMeanings)
                    {
                        string functionMeaningsString = "Функция: " + keyValuePair.Value + " = " + keyValuePair.Key;
                        functionsMeaningsListBox.Items.Add(functionMeaningsString);
                    }

                    UpdateTransformation();
                    valuesParsed = false;
                }
            };
            simpleFunctionWizard.Show();
        }

        private void fullAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (immutableInfixString == null)
                return;

            transformationFull.General();

            postfixString = transformationFull.GetOutputString();
            postfixText.Text = postfixString;
        }

        private void tactAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (immutableInfixString == null)
                return;

            transformationTact.SetTactButtonPressed();

            VisualizeStack();

            transformationTact.General();

            if (transformationTact.GetEndFlag())
            {
                fullAlgorithmButton.Enabled = true;
                fullCalculationButton.Enabled = true;
                tactCalculationButton.Enabled = true;
                enterCalculationButton.Enabled = true;
                functionWizardButton.Enabled = true;
            }
            else
            {
                fullAlgorithmButton.Enabled = false;
                fullCalculationButton.Enabled = false;
                tactCalculationButton.Enabled = false;
                enterCalculationButton.Enabled = false;
                functionWizardButton.Enabled = false;
            }

            postfixString = transformationTact.GetOutputString();
            currentInfixString = transformationTact.GetCurrentInputString();

            postfixText.Text = postfixString;
            infixText.Text = currentInfixString;
        }

        private void SetDefaultStackPointerVisualization() // Устанавливает отображение указателя в стандартное состояние 
        {
            stackPointer0.Text = whiteSpace;
            stackPointer1.Text = whiteSpace;
            stackPointer2.Text = whiteSpace;
            stackPointer3.Text = whiteSpace;
            stackPointer4.Text = whiteSpace;
            stackPointer5.Text = whiteSpace;
            stackPointer6.Text = whiteSpace;
            stackPointer7.Text = whiteSpace;
            stackPointer8.Text = whiteSpace;
            stackPointer9.Text = whiteSpace;
            stackPointer10.Text = whiteSpace;
            stackPointer11.Text = whiteSpace;
            stackPointer12.Text = whiteSpace;
            stackPointer13.Text = whiteSpace;
            stackPointer14.Text = whiteSpace;
        }

        private void VisualizeStack() // Визуализация стека
        {
            if (transformationTact.GetTactMode())
            {
                if (!transformationTact.GetEndFlag())
                {
                    switch (transformationTact.stack.GetStackPointerPos() - 1)
                    {
                        case 0:
                            stack0.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer0.Text = stackPointerSymbol;
                            break;
                        case 1:
                            stack1.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer1.Text = stackPointerSymbol;
                            break;
                        case 2:
                            stack2.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer2.Text = stackPointerSymbol;
                            break;
                        case 3:
                            stack3.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer3.Text = stackPointerSymbol;
                            break;
                        case 4:
                            stack4.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer4.Text = stackPointerSymbol;
                            break;
                        case 5:
                            stack5.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer5.Text = stackPointerSymbol;
                            break;
                        case 6:
                            stack6.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer6.Text = stackPointerSymbol;
                            break;
                        case 7:
                            stack7.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer7.Text = stackPointerSymbol;
                            break;
                        case 8:
                            stack8.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer8.Text = stackPointerSymbol;
                            break;
                        case 9:
                            stack9.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer9.Text = stackPointerSymbol;
                            break;
                        case 10:
                            stack10.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer10.Text = stackPointerSymbol;
                            break;
                        case 11:
                            stack11.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer11.Text = stackPointerSymbol;
                            break;
                        case 12:
                            stack12.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer12.Text = stackPointerSymbol;
                            break;
                        case 13:
                            stack13.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer13.Text = stackPointerSymbol;
                            break;
                        case 14:
                            stack14.Text = Convert.ToString(transformationTact.stack.GetStackElement(transformationTact.stack.GetStackPointerPos() - 1));
                            SetDefaultStackPointerVisualization();
                            stackPointer14.Text = stackPointerSymbol;
                            break;
                    }
                }
            }
        }

        private void tactCalculationButton_Click(object sender, EventArgs e) // Потактовое вычисление постфиксного выражения
        {

        }

        private void fullCalculationButton_Click(object sender, EventArgs e) // Вычисление постфиксного выражения
        {

        }

        private void updateCalculationButton_Click(object sender, EventArgs e)
        {
            AddTextBoxesToList();
            TryParseDouble();
            UpdateCalculation();
        }

        private void Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || e.KeyChar == 101) // запрет на ввод всего кроме BackSp, ., -, e
                return;
            else
                e.Handled = true;
        }
    
        private void TryParseDouble()
        {
            double value;
            if (!valuesParsed)
            {
                foreach (TextBox textBox in textBoxesList)
                {
                    if (Double.TryParse(textBox.Text, out value))
                    {
                        valuesParsed = true;
                        Console.WriteLine("'{0}' --> {1}", textBox.Name, value);
                        numberMeanings.Add(Convert.ToChar(textBox.Name), value);
                    }
                    else
                    {
                        valuesParsed = false;
                        MessageBox.Show("Введены неверные значения!");
                        return;
                    }
                }
            }
        }
    
        private void AddTextBoxesToList()
        {
            textBoxesList.Add(A);
            textBoxesList.Add(B);
            textBoxesList.Add(C);
            textBoxesList.Add(D);
            textBoxesList.Add(E);
            textBoxesList.Add(F);
            textBoxesList.Add(G);
            textBoxesList.Add(H);
            textBoxesList.Add(I);
            textBoxesList.Add(J);
        }
    }
}
