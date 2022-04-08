
namespace AlgebraicExpressionsTranslation
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.immutableInfixText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.functionWizardButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.infixText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.postfixText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tactAlgorithmButton = new System.Windows.Forms.Button();
            this.fullAlgorithmButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.stack0 = new System.Windows.Forms.TextBox();
            this.stack1 = new System.Windows.Forms.TextBox();
            this.stack2 = new System.Windows.Forms.TextBox();
            this.stack3 = new System.Windows.Forms.TextBox();
            this.stack4 = new System.Windows.Forms.TextBox();
            this.stack5 = new System.Windows.Forms.TextBox();
            this.stack6 = new System.Windows.Forms.TextBox();
            this.stack7 = new System.Windows.Forms.TextBox();
            this.stack8 = new System.Windows.Forms.TextBox();
            this.stack9 = new System.Windows.Forms.TextBox();
            this.stack10 = new System.Windows.Forms.TextBox();
            this.stack11 = new System.Windows.Forms.TextBox();
            this.stack12 = new System.Windows.Forms.TextBox();
            this.stack13 = new System.Windows.Forms.TextBox();
            this.stack14 = new System.Windows.Forms.TextBox();
            this.stackPointer0 = new System.Windows.Forms.TextBox();
            this.stackPointer1 = new System.Windows.Forms.TextBox();
            this.stackPointer2 = new System.Windows.Forms.TextBox();
            this.stackPointer3 = new System.Windows.Forms.TextBox();
            this.stackPointer4 = new System.Windows.Forms.TextBox();
            this.stackPointer5 = new System.Windows.Forms.TextBox();
            this.stackPointer6 = new System.Windows.Forms.TextBox();
            this.stackPointer7 = new System.Windows.Forms.TextBox();
            this.stackPointer8 = new System.Windows.Forms.TextBox();
            this.stackPointer9 = new System.Windows.Forms.TextBox();
            this.stackPointer10 = new System.Windows.Forms.TextBox();
            this.stackPointer11 = new System.Windows.Forms.TextBox();
            this.stackPointer12 = new System.Windows.Forms.TextBox();
            this.stackPointer13 = new System.Windows.Forms.TextBox();
            this.stackPointer14 = new System.Windows.Forms.TextBox();
            this.numbersMeaningsListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.functionsMeaningsListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fullCalculationButton = new System.Windows.Forms.Button();
            this.tactCalculationButton = new System.Windows.Forms.Button();
            this.updateCalculationButton = new System.Windows.Forms.Button();
            this.resultText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // immutableInfixText
            // 
            this.immutableInfixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.immutableInfixText.Location = new System.Drawing.Point(16, 36);
            this.immutableInfixText.MaxLength = 80;
            this.immutableInfixText.Name = "immutableInfixText";
            this.immutableInfixText.ReadOnly = true;
            this.immutableInfixText.Size = new System.Drawing.Size(701, 29);
            this.immutableInfixText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходное выражение в инфиксной форме (неизменяемое)";
            // 
            // functionWizardButton
            // 
            this.functionWizardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionWizardButton.Location = new System.Drawing.Point(770, 36);
            this.functionWizardButton.Name = "functionWizardButton";
            this.functionWizardButton.Size = new System.Drawing.Size(195, 147);
            this.functionWizardButton.TabIndex = 2;
            this.functionWizardButton.Text = "Мастер функций";
            this.functionWizardButton.UseVisualStyleBackColor = true;
            this.functionWizardButton.Click += new System.EventHandler(this.functionWizardButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Текущее инфиксное выражение";
            // 
            // infixText
            // 
            this.infixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infixText.Location = new System.Drawing.Point(16, 95);
            this.infixText.MaxLength = 80;
            this.infixText.Name = "infixText";
            this.infixText.ReadOnly = true;
            this.infixText.Size = new System.Drawing.Size(701, 29);
            this.infixText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Постфиксное выражение";
            // 
            // postfixText
            // 
            this.postfixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postfixText.Location = new System.Drawing.Point(16, 154);
            this.postfixText.MaxLength = 640;
            this.postfixText.Name = "postfixText";
            this.postfixText.ReadOnly = true;
            this.postfixText.Size = new System.Drawing.Size(701, 29);
            this.postfixText.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(42, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Стек";
            // 
            // tactAlgorithmButton
            // 
            this.tactAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tactAlgorithmButton.Location = new System.Drawing.Point(133, 333);
            this.tactAlgorithmButton.Name = "tactAlgorithmButton";
            this.tactAlgorithmButton.Size = new System.Drawing.Size(167, 53);
            this.tactAlgorithmButton.TabIndex = 9;
            this.tactAlgorithmButton.Text = "Один такт";
            this.tactAlgorithmButton.UseVisualStyleBackColor = true;
            this.tactAlgorithmButton.Click += new System.EventHandler(this.tactAlgorithmButton_Click);
            // 
            // fullAlgorithmButton
            // 
            this.fullAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullAlgorithmButton.Location = new System.Drawing.Point(133, 392);
            this.fullAlgorithmButton.Name = "fullAlgorithmButton";
            this.fullAlgorithmButton.Size = new System.Drawing.Size(167, 53);
            this.fullAlgorithmButton.TabIndex = 10;
            this.fullAlgorithmButton.Text = "Полностью";
            this.fullAlgorithmButton.UseVisualStyleBackColor = true;
            this.fullAlgorithmButton.Click += new System.EventHandler(this.fullAlgorithmButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(156, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Приведение";
            // 
            // stack0
            // 
            this.stack0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack0.Location = new System.Drawing.Point(17, 578);
            this.stack0.Name = "stack0";
            this.stack0.Size = new System.Drawing.Size(78, 29);
            this.stack0.TabIndex = 13;
            // 
            // stack1
            // 
            this.stack1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack1.Location = new System.Drawing.Point(17, 552);
            this.stack1.Name = "stack1";
            this.stack1.Size = new System.Drawing.Size(78, 29);
            this.stack1.TabIndex = 14;
            // 
            // stack2
            // 
            this.stack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack2.Location = new System.Drawing.Point(17, 526);
            this.stack2.Name = "stack2";
            this.stack2.Size = new System.Drawing.Size(78, 29);
            this.stack2.TabIndex = 15;
            // 
            // stack3
            // 
            this.stack3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack3.Location = new System.Drawing.Point(17, 500);
            this.stack3.Name = "stack3";
            this.stack3.Size = new System.Drawing.Size(78, 29);
            this.stack3.TabIndex = 16;
            // 
            // stack4
            // 
            this.stack4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack4.Location = new System.Drawing.Point(17, 474);
            this.stack4.Name = "stack4";
            this.stack4.Size = new System.Drawing.Size(78, 29);
            this.stack4.TabIndex = 17;
            // 
            // stack5
            // 
            this.stack5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack5.Location = new System.Drawing.Point(17, 448);
            this.stack5.Name = "stack5";
            this.stack5.Size = new System.Drawing.Size(78, 29);
            this.stack5.TabIndex = 18;
            // 
            // stack6
            // 
            this.stack6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack6.Location = new System.Drawing.Point(17, 422);
            this.stack6.Name = "stack6";
            this.stack6.Size = new System.Drawing.Size(78, 29);
            this.stack6.TabIndex = 19;
            // 
            // stack7
            // 
            this.stack7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack7.Location = new System.Drawing.Point(17, 396);
            this.stack7.Name = "stack7";
            this.stack7.Size = new System.Drawing.Size(78, 29);
            this.stack7.TabIndex = 20;
            // 
            // stack8
            // 
            this.stack8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack8.Location = new System.Drawing.Point(17, 370);
            this.stack8.Name = "stack8";
            this.stack8.Size = new System.Drawing.Size(78, 29);
            this.stack8.TabIndex = 21;
            // 
            // stack9
            // 
            this.stack9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack9.Location = new System.Drawing.Point(17, 344);
            this.stack9.Name = "stack9";
            this.stack9.Size = new System.Drawing.Size(78, 29);
            this.stack9.TabIndex = 22;
            // 
            // stack10
            // 
            this.stack10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack10.Location = new System.Drawing.Point(17, 318);
            this.stack10.Name = "stack10";
            this.stack10.Size = new System.Drawing.Size(78, 29);
            this.stack10.TabIndex = 23;
            // 
            // stack11
            // 
            this.stack11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack11.Location = new System.Drawing.Point(17, 292);
            this.stack11.Name = "stack11";
            this.stack11.Size = new System.Drawing.Size(78, 29);
            this.stack11.TabIndex = 24;
            // 
            // stack12
            // 
            this.stack12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack12.Location = new System.Drawing.Point(17, 266);
            this.stack12.Name = "stack12";
            this.stack12.Size = new System.Drawing.Size(78, 29);
            this.stack12.TabIndex = 25;
            // 
            // stack13
            // 
            this.stack13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack13.Location = new System.Drawing.Point(17, 240);
            this.stack13.Name = "stack13";
            this.stack13.Size = new System.Drawing.Size(78, 29);
            this.stack13.TabIndex = 26;
            // 
            // stack14
            // 
            this.stack14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stack14.Location = new System.Drawing.Point(17, 213);
            this.stack14.Name = "stack14";
            this.stack14.Size = new System.Drawing.Size(78, 29);
            this.stack14.TabIndex = 27;
            // 
            // stackPointer0
            // 
            this.stackPointer0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer0.Location = new System.Drawing.Point(101, 578);
            this.stackPointer0.Name = "stackPointer0";
            this.stackPointer0.Size = new System.Drawing.Size(26, 29);
            this.stackPointer0.TabIndex = 28;
            // 
            // stackPointer1
            // 
            this.stackPointer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer1.Location = new System.Drawing.Point(101, 552);
            this.stackPointer1.Name = "stackPointer1";
            this.stackPointer1.Size = new System.Drawing.Size(26, 29);
            this.stackPointer1.TabIndex = 29;
            // 
            // stackPointer2
            // 
            this.stackPointer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer2.Location = new System.Drawing.Point(101, 526);
            this.stackPointer2.Name = "stackPointer2";
            this.stackPointer2.Size = new System.Drawing.Size(26, 29);
            this.stackPointer2.TabIndex = 30;
            // 
            // stackPointer3
            // 
            this.stackPointer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer3.Location = new System.Drawing.Point(101, 500);
            this.stackPointer3.Name = "stackPointer3";
            this.stackPointer3.Size = new System.Drawing.Size(26, 29);
            this.stackPointer3.TabIndex = 31;
            // 
            // stackPointer4
            // 
            this.stackPointer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer4.Location = new System.Drawing.Point(101, 474);
            this.stackPointer4.Name = "stackPointer4";
            this.stackPointer4.Size = new System.Drawing.Size(26, 29);
            this.stackPointer4.TabIndex = 32;
            // 
            // stackPointer5
            // 
            this.stackPointer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer5.Location = new System.Drawing.Point(101, 448);
            this.stackPointer5.Name = "stackPointer5";
            this.stackPointer5.Size = new System.Drawing.Size(26, 29);
            this.stackPointer5.TabIndex = 33;
            // 
            // stackPointer6
            // 
            this.stackPointer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer6.Location = new System.Drawing.Point(101, 422);
            this.stackPointer6.Name = "stackPointer6";
            this.stackPointer6.Size = new System.Drawing.Size(26, 29);
            this.stackPointer6.TabIndex = 34;
            // 
            // stackPointer7
            // 
            this.stackPointer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer7.Location = new System.Drawing.Point(101, 396);
            this.stackPointer7.Name = "stackPointer7";
            this.stackPointer7.Size = new System.Drawing.Size(26, 29);
            this.stackPointer7.TabIndex = 35;
            // 
            // stackPointer8
            // 
            this.stackPointer8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer8.Location = new System.Drawing.Point(101, 370);
            this.stackPointer8.Name = "stackPointer8";
            this.stackPointer8.Size = new System.Drawing.Size(26, 29);
            this.stackPointer8.TabIndex = 36;
            // 
            // stackPointer9
            // 
            this.stackPointer9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer9.Location = new System.Drawing.Point(101, 344);
            this.stackPointer9.Name = "stackPointer9";
            this.stackPointer9.Size = new System.Drawing.Size(26, 29);
            this.stackPointer9.TabIndex = 37;
            // 
            // stackPointer10
            // 
            this.stackPointer10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer10.Location = new System.Drawing.Point(101, 318);
            this.stackPointer10.Name = "stackPointer10";
            this.stackPointer10.Size = new System.Drawing.Size(26, 29);
            this.stackPointer10.TabIndex = 38;
            // 
            // stackPointer11
            // 
            this.stackPointer11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer11.Location = new System.Drawing.Point(101, 292);
            this.stackPointer11.Name = "stackPointer11";
            this.stackPointer11.Size = new System.Drawing.Size(26, 29);
            this.stackPointer11.TabIndex = 39;
            // 
            // stackPointer12
            // 
            this.stackPointer12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer12.Location = new System.Drawing.Point(101, 266);
            this.stackPointer12.Name = "stackPointer12";
            this.stackPointer12.Size = new System.Drawing.Size(26, 29);
            this.stackPointer12.TabIndex = 40;
            // 
            // stackPointer13
            // 
            this.stackPointer13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer13.Location = new System.Drawing.Point(101, 240);
            this.stackPointer13.Name = "stackPointer13";
            this.stackPointer13.Size = new System.Drawing.Size(26, 29);
            this.stackPointer13.TabIndex = 41;
            // 
            // stackPointer14
            // 
            this.stackPointer14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointer14.Location = new System.Drawing.Point(101, 213);
            this.stackPointer14.Name = "stackPointer14";
            this.stackPointer14.Size = new System.Drawing.Size(26, 29);
            this.stackPointer14.TabIndex = 42;
            // 
            // numbersMeaningsListBox
            // 
            this.numbersMeaningsListBox.FormattingEnabled = true;
            this.numbersMeaningsListBox.Location = new System.Drawing.Point(310, 222);
            this.numbersMeaningsListBox.Name = "numbersMeaningsListBox";
            this.numbersMeaningsListBox.Size = new System.Drawing.Size(252, 342);
            this.numbersMeaningsListBox.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(344, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 24);
            this.label7.TabIndex = 47;
            this.label7.Text = "Обозначения чисел";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(584, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 24);
            this.label8.TabIndex = 49;
            this.label8.Text = "Обозначения функций";
            // 
            // functionsMeaningsListBox
            // 
            this.functionsMeaningsListBox.FormattingEnabled = true;
            this.functionsMeaningsListBox.Location = new System.Drawing.Point(568, 222);
            this.functionsMeaningsListBox.Name = "functionsMeaningsListBox";
            this.functionsMeaningsListBox.Size = new System.Drawing.Size(246, 342);
            this.functionsMeaningsListBox.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(845, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 24);
            this.label6.TabIndex = 52;
            this.label6.Text = "Вычисление";
            // 
            // fullCalculationButton
            // 
            this.fullCalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullCalculationButton.Location = new System.Drawing.Point(821, 457);
            this.fullCalculationButton.Name = "fullCalculationButton";
            this.fullCalculationButton.Size = new System.Drawing.Size(167, 53);
            this.fullCalculationButton.TabIndex = 51;
            this.fullCalculationButton.Text = "Полностью";
            this.fullCalculationButton.UseVisualStyleBackColor = true;
            this.fullCalculationButton.Click += new System.EventHandler(this.fullCalculationButton_Click);
            // 
            // tactCalculationButton
            // 
            this.tactCalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tactCalculationButton.Location = new System.Drawing.Point(821, 398);
            this.tactCalculationButton.Name = "tactCalculationButton";
            this.tactCalculationButton.Size = new System.Drawing.Size(167, 53);
            this.tactCalculationButton.TabIndex = 50;
            this.tactCalculationButton.Text = "Один такт";
            this.tactCalculationButton.UseVisualStyleBackColor = true;
            this.tactCalculationButton.Click += new System.EventHandler(this.tactCalculationButton_Click);
            // 
            // updateCalculationButton
            // 
            this.updateCalculationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateCalculationButton.Location = new System.Drawing.Point(820, 326);
            this.updateCalculationButton.Name = "updateCalculationButton";
            this.updateCalculationButton.Size = new System.Drawing.Size(167, 53);
            this.updateCalculationButton.TabIndex = 53;
            this.updateCalculationButton.Text = "Задать";
            this.updateCalculationButton.UseVisualStyleBackColor = true;
            this.updateCalculationButton.Click += new System.EventHandler(this.updateCalculationButton_Click);
            // 
            // resultText
            // 
            this.resultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultText.Location = new System.Drawing.Point(136, 584);
            this.resultText.MaxLength = 640;
            this.resultText.Name = "resultText";
            this.resultText.ReadOnly = true;
            this.resultText.Size = new System.Drawing.Size(701, 29);
            this.resultText.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(133, 557);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 24);
            this.label9.TabIndex = 54;
            this.label9.Text = "Результат";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 613);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.updateCalculationButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fullCalculationButton);
            this.Controls.Add(this.tactCalculationButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.functionsMeaningsListBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numbersMeaningsListBox);
            this.Controls.Add(this.stackPointer14);
            this.Controls.Add(this.stackPointer13);
            this.Controls.Add(this.stackPointer12);
            this.Controls.Add(this.stackPointer11);
            this.Controls.Add(this.stackPointer10);
            this.Controls.Add(this.stackPointer9);
            this.Controls.Add(this.stackPointer8);
            this.Controls.Add(this.stackPointer7);
            this.Controls.Add(this.stackPointer6);
            this.Controls.Add(this.stackPointer5);
            this.Controls.Add(this.stackPointer4);
            this.Controls.Add(this.stackPointer3);
            this.Controls.Add(this.stackPointer2);
            this.Controls.Add(this.stackPointer1);
            this.Controls.Add(this.stackPointer0);
            this.Controls.Add(this.stack14);
            this.Controls.Add(this.stack13);
            this.Controls.Add(this.stack12);
            this.Controls.Add(this.stack11);
            this.Controls.Add(this.stack10);
            this.Controls.Add(this.stack9);
            this.Controls.Add(this.stack8);
            this.Controls.Add(this.stack7);
            this.Controls.Add(this.stack6);
            this.Controls.Add(this.stack5);
            this.Controls.Add(this.stack4);
            this.Controls.Add(this.stack3);
            this.Controls.Add(this.stack2);
            this.Controls.Add(this.stack1);
            this.Controls.Add(this.stack0);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fullAlgorithmButton);
            this.Controls.Add(this.tactAlgorithmButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.postfixText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infixText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.functionWizardButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.immutableInfixText);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlgebraicExpressionsTranslation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox immutableInfixText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button functionWizardButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox infixText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox postfixText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tactAlgorithmButton;
        private System.Windows.Forms.Button fullAlgorithmButton;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox stack0;
        protected System.Windows.Forms.TextBox stack1;
        protected System.Windows.Forms.TextBox stack2;
        protected System.Windows.Forms.TextBox stack3;
        protected System.Windows.Forms.TextBox stack4;
        protected System.Windows.Forms.TextBox stack5;
        protected System.Windows.Forms.TextBox stack6;
        protected System.Windows.Forms.TextBox stack7;
        protected System.Windows.Forms.TextBox stack8;
        protected System.Windows.Forms.TextBox stack9;
        protected System.Windows.Forms.TextBox stack10;
        protected System.Windows.Forms.TextBox stack11;
        protected System.Windows.Forms.TextBox stack12;
        protected System.Windows.Forms.TextBox stack13;
        protected System.Windows.Forms.TextBox stack14;
        protected System.Windows.Forms.TextBox stackPointer0;
        protected System.Windows.Forms.TextBox stackPointer1;
        protected System.Windows.Forms.TextBox stackPointer2;
        protected System.Windows.Forms.TextBox stackPointer3;
        protected System.Windows.Forms.TextBox stackPointer4;
        protected System.Windows.Forms.TextBox stackPointer5;
        protected System.Windows.Forms.TextBox stackPointer6;
        protected System.Windows.Forms.TextBox stackPointer7;
        protected System.Windows.Forms.TextBox stackPointer8;
        protected System.Windows.Forms.TextBox stackPointer9;
        protected System.Windows.Forms.TextBox stackPointer10;
        protected System.Windows.Forms.TextBox stackPointer11;
        protected System.Windows.Forms.TextBox stackPointer12;
        protected System.Windows.Forms.TextBox stackPointer13;
        protected System.Windows.Forms.TextBox stackPointer14;
        private System.Windows.Forms.ListBox numbersMeaningsListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox functionsMeaningsListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button fullCalculationButton;
        private System.Windows.Forms.Button tactCalculationButton;
        private System.Windows.Forms.Button updateCalculationButton;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.Label label9;
    }
}

