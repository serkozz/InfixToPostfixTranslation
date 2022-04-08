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
    public partial class MainForm : Form
    {
        string immutableInfixString;
        string currentInfixString;
        string postfixString;

        const string stackPointerSymbol = "<";
        const string whiteSpace = " ";

        Transformation transformationFull;
        Transformation transformationTact;

        Calculation calculationFull;
        Calculation calculationTact;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateAlgorithm()
        {
            transformationTact = new Transformation(immutableInfixString, isTactMode: true);
            transformationFull = new Transformation(immutableInfixString, isTactMode: false);
        }

        private void UpdateCalculation()
        {
            calculationTact = new Calculation(postfixString, isTactMode: true);
            calculationFull = new Calculation(postfixString, isTactMode: false);
        }

        private void functionWizardButton_Click(object sender, EventArgs e) // Обработчик мастера функций
        {
            FunctionWizard functionWizard = new FunctionWizard();

            functionWizard.FormClosing += (fw_sender, fw_e) =>
            {
                //Обновляем переменную основной формы при закрытии
                if (functionWizard.inputString.Length != 0)
                {
                    immutableInfixString = functionWizard.inputString;
                    currentInfixString = functionWizard.inputString;

                    immutableInfixText.Text = immutableInfixString;

                    UpdateAlgorithm();
                }
            };
            functionWizard.Show();
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
                updateCalculationButton.Enabled = true;
            }
            else
            {
                fullAlgorithmButton.Enabled = false;
                fullCalculationButton.Enabled = false;
                tactCalculationButton.Enabled = false;
                updateCalculationButton.Enabled = false;
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
            UpdateCalculation();
        }
    }
}
