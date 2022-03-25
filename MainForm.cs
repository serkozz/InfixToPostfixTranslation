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

        public MainForm()
        {
            InitializeComponent();
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
                }
            };
            functionWizard.Show();
        }

        private void updateValuesButton_Click(object sender, EventArgs e)
        {
            postfixText.Text = postfixString;
        }

        private void fullAlgorithmButton_Click(object sender, EventArgs e)
        {
            AlgorithmV2 algorithmV2 = new AlgorithmV2 (immutableInfixString, isUsingDecisionTable: false, isTactMode: false); // a - sin, b - cos, c - sqrt, d - ln

            Console.WriteLine("---INPUT STRING---");
            Console.WriteLine(algorithmV2.GetInputString());
            Console.WriteLine("---OUTPUT STRING---");
            algorithmV2.General();
            Console.WriteLine(algorithmV2.GetOutputString());

            postfixString = algorithmV2.GetOutputString();
            postfixText.Text = postfixString;
        }

        private void tactAlgorithmButton_Click(object sender, EventArgs e) // Does not work
        {
            AlgorithmV2 algorithmV2 = new AlgorithmV2(immutableInfixString, isUsingDecisionTable: true, isTactMode: true);
            algorithmV2.General();

            postfixString = algorithmV2.GetOutputString();
            postfixText.Text = postfixString;
        }
    }
}
