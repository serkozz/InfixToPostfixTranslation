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
        private string immutableInfixString;
        private string currentInfixString;
        private string postfixString;

        private string stackPointerSymbol = "<--";

        private Algorithm algorithmFull;
        private Algorithm algorithmTact;

        const int listBoxCapacity = 20; // Вместимость листбокса на форме
        int currentStackListBoxIndex;
        int currentStackPointerListBoxIndex;

        public MainForm()
        {
            InitializeComponent();

            UpdateStackListBox();
            UpdateStackPointerListBox();
        }

        private void UpdateAlgorithm()
        {
            algorithmTact = new Algorithm(immutableInfixString, isTactMode: true);
            algorithmFull = new Algorithm(immutableInfixString, isTactMode: false);
        }

        private void UpdateStackListBox()
        {
            stackListBox.Items.Clear();
            stackPointerListBox.Items.Clear();

            for (int i = 0; i < listBoxCapacity; i++)
            {
                stackListBox.Items.Add(' ');
                stackPointerListBox.Items.Add(' ');
            }

            currentStackListBoxIndex = listBoxCapacity;
        }

        private void UpdateStackPointerListBox()
        {
            stackPointerListBox.Items.Clear();

            for (int i = 0; i < listBoxCapacity; i++)
            {
                stackPointerListBox.Items.Add(' ');
            }

            currentStackPointerListBoxIndex = listBoxCapacity;
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
                    UpdateStackListBox();
                    UpdateStackPointerListBox();
                }
            };
            functionWizard.Show();
        }

        private void updateValuesButton_Click(object sender, EventArgs e)
        {
            postfixText.Text = postfixString;
        }

        private (bool, int, char) InsertItemIntoListbox()
        {
            char lastStackSymbol = algorithmTact.GetStackElement(algorithmTact.GetStackPointerPos() - 1);
            int stackPointerPos = algorithmTact.GetStackPointerPos()-1;

            if (lastStackSymbol != ' ')
                return (true, stackPointerPos, lastStackSymbol);
            else
                return (false, stackPointerPos, lastStackSymbol);
        }

        private void fullAlgorithmButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("---INPUT STRING---");
            Console.WriteLine(algorithmFull.GetInputString());
            Console.WriteLine("---OUTPUT STRING---");
            algorithmFull.General();
            Console.WriteLine(algorithmFull.GetOutputString());

            postfixString = algorithmFull.GetOutputString();
            postfixText.Text = postfixString;
        }

        private void tactAlgorithmButton_Click(object sender, EventArgs e) // Partly working
        {
            algorithmTact.SetTactButtonPressed();

            int previousStackPointerPos = algorithmTact.GetStackPointerPos(); // Переменные запоминающие позиции поинтера нужны для того, чтобы
                                                                               // Исключить дублирование элементов в стеке
            algorithmTact.General();
            int currentStackPointerPos = algorithmTact.GetStackPointerPos();

            postfixString = algorithmTact.GetOutputString();
            currentInfixString = algorithmTact.GetCurrentInputString();

            postfixText.Text = postfixString;
            infixText.Text = currentInfixString;

            (bool, int, char) tuple = InsertItemIntoListbox();

            if (tuple.Item1 && previousStackPointerPos != currentStackPointerPos)
            {
                stackListBox.Items.RemoveAt(currentStackListBoxIndex - 1);
                stackListBox.Items.Insert(currentStackListBoxIndex - 1, tuple.Item3);

                stackPointerListBox.Items.RemoveAt(currentStackPointerListBoxIndex - 1);
                stackPointerListBox.Items.Insert(currentStackPointerListBoxIndex - 1, stackPointerSymbol);

                if (previousStackPointerPos < currentStackPointerPos) // Если происходит сдвиг поинтера к концу стека
                {
                    currentStackListBoxIndex--;
                    currentStackListBoxIndex--;
                }

                if (previousStackPointerPos > currentStackPointerPos) // Если происходит сдвиг поинтера к началу стека
                {
                    UpdateStackPointerListBox();
                    currentStackListBoxIndex++;
                }
            }
        }
    }
}
