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
        string currentPostfixString;
        string resultString;

        Dictionary<char, double> numberMeanings; // {'A' "10"}
        Dictionary<string, string> functionMeanings; // {"a" "sin"}
        List<TextBox> textBoxesList;

        const string stackPointerSymbol = "<";
        const string whiteSpace = " ";

        Transformation transformationFull;
        Transformation transformationTact;

        Calculation calculationFull;
        Calculation calculationTact;

        public SimpleMainForm()
        {
            InitializeComponent();

            numberMeanings = new Dictionary<char, double>();
            functionMeanings = new Dictionary<string, string>();
            textBoxesList = new List<TextBox>();
        }

        private void UpdateTransformation()
        {
            transformationTact = new Transformation(immutableInfixString, isTactMode: true);
            transformationFull = new Transformation(immutableInfixString, isTactMode: false);
        }

        private void UpdateCalculation()
        {
            calculationTact = new Calculation(postfixString, numberMeanings, functionMeanings, isTactMode: true);
            calculationFull = new Calculation(postfixString, numberMeanings, functionMeanings, isTactMode: false);
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

            VisualizeStack(stackType: Stack.StackType.TransformationStack);

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

        private void VisualizeStack(Stack.StackType stackType) // Визуализация стека
        {
            if (stackType == Stack.StackType.TransformationStack)
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
            else if (stackType == Stack.StackType.CalculationStack)
            {
                if (calculationTact.GetTactMode())
                {
                    if (!calculationTact.GetEndFlag())
                    {
                        switch (calculationTact.stack.GetStackPointerPos() - 1)
                        {
                            case 0:
                                stack0.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer0.Text = stackPointerSymbol;
                                break;
                            case 1:
                                stack1.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer1.Text = stackPointerSymbol;
                                break;
                            case 2:
                                stack2.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer2.Text = stackPointerSymbol;
                                break;
                            case 3:
                                stack3.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer3.Text = stackPointerSymbol;
                                break;
                            case 4:
                                stack4.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer4.Text = stackPointerSymbol;
                                break;
                            case 5:
                                stack5.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer5.Text = stackPointerSymbol;
                                break;
                            case 6:
                                stack6.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer6.Text = stackPointerSymbol;
                                break;
                            case 7:
                                stack7.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer7.Text = stackPointerSymbol;
                                break;
                            case 8:
                                stack8.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer8.Text = stackPointerSymbol;
                                break;
                            case 9:
                                stack9.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer9.Text = stackPointerSymbol;
                                break;
                            case 10:
                                stack10.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer10.Text = stackPointerSymbol;
                                break;
                            case 11:
                                stack11.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer11.Text = stackPointerSymbol;
                                break;
                            case 12:
                                stack12.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer12.Text = stackPointerSymbol;
                                break;
                            case 13:
                                stack13.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer13.Text = stackPointerSymbol;
                                break;
                            case 14:
                                stack14.Text = Convert.ToString(calculationTact.stack.GetStackElement((calculationTact.stack.GetStackPointerPos() - 1), true));
                                SetDefaultStackPointerVisualization();
                                stackPointer14.Text = stackPointerSymbol;
                                break;
                        }
                    }
                }
            }
        }

        private void tactCalculationButton_Click(object sender, EventArgs e) // Потактовое вычисление постфиксного выражения
        {
            if (postfixString == null)
                return;

            calculationTact.SetTactButtonPressed();

            VisualizeStack(stackType: Stack.StackType.CalculationStack);

            calculationTact.General();

            if (calculationTact.GetEndFlag())
            {
                fullAlgorithmButton.Enabled = true;
                tactAlgorithmButton.Enabled = true;
                fullCalculationButton.Enabled = true;
                tactCalculationButton.Enabled = true;
                enterCalculationButton.Enabled = true;
                functionWizardButton.Enabled = true;
            }
            else
            {
                fullAlgorithmButton.Enabled = false;
                tactAlgorithmButton.Enabled = false;
                fullCalculationButton.Enabled = false;
                enterCalculationButton.Enabled = false;
                functionWizardButton.Enabled = false;
            }

            resultString = calculationTact.GetResultString();
            currentPostfixString = calculationTact.GetCurrentPostfixString();

            resultText.Text = resultString;
            postfixText.Text = currentPostfixString;
        }

        private void fullCalculationButton_Click(object sender, EventArgs e) // Вычисление постфиксного выражения
        {
            if (postfixString == null)
                return;
            else
            {
                calculationFull.General();

                resultString = calculationFull.GetResultString();
                resultText.Text = resultString;
            }

        }

        private void updateCalculationButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxesList();
            AddTextBoxesToList();

            ClearNumberMeaningsDictionary();

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

            foreach (TextBox textBox in textBoxesList)
            {
                if (Double.TryParse(textBox.Text, out value))
                {
                    Console.WriteLine("'{0}' --> {1}", textBox.Name, value);
                    numberMeanings.Add(Convert.ToChar(textBox.Name), value);
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

        private void ClearNumberMeaningsDictionary()
        {
            numberMeanings.Clear();
            //functionMeanings.Clear();
        }

        private void ClearTextBoxesList()
        {
            textBoxesList.Clear();
        }
    }
}
