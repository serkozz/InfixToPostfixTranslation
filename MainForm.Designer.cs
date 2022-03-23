
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
            this.stackText = new System.Windows.Forms.TextBox();
            this.tactAlgorithmButton = new System.Windows.Forms.Button();
            this.fullAlgorithmButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.updateValuesButton = new System.Windows.Forms.Button();
            this.stackPointerText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // immutableInfixText
            // 
            this.immutableInfixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.immutableInfixText.Location = new System.Drawing.Point(16, 36);
            this.immutableInfixText.MaxLength = 80;
            this.immutableInfixText.Name = "immutableInfixText";
            this.immutableInfixText.ReadOnly = true;
            this.immutableInfixText.Size = new System.Drawing.Size(825, 29);
            this.immutableInfixText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходное выражение в инфиксной форме (неизменяемое)";
            // 
            // functionWizardButton
            // 
            this.functionWizardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionWizardButton.Location = new System.Drawing.Point(216, 218);
            this.functionWizardButton.Name = "functionWizardButton";
            this.functionWizardButton.Size = new System.Drawing.Size(167, 53);
            this.functionWizardButton.TabIndex = 2;
            this.functionWizardButton.Text = "Мастер функций";
            this.functionWizardButton.UseVisualStyleBackColor = true;
            this.functionWizardButton.Click += new System.EventHandler(this.functionWizardButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(282, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Текущее инфиксное выражение";
            // 
            // infixText
            // 
            this.infixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infixText.Location = new System.Drawing.Point(16, 105);
            this.infixText.MaxLength = 80;
            this.infixText.Name = "infixText";
            this.infixText.ReadOnly = true;
            this.infixText.Size = new System.Drawing.Size(825, 29);
            this.infixText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(315, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Постфиксное выражение";
            // 
            // postfixText
            // 
            this.postfixText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postfixText.Location = new System.Drawing.Point(16, 177);
            this.postfixText.MaxLength = 640;
            this.postfixText.Name = "postfixText";
            this.postfixText.ReadOnly = true;
            this.postfixText.Size = new System.Drawing.Size(825, 29);
            this.postfixText.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Стек";
            // 
            // stackText
            // 
            this.stackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackText.Location = new System.Drawing.Point(16, 245);
            this.stackText.MaxLength = 640;
            this.stackText.Multiline = true;
            this.stackText.Name = "stackText";
            this.stackText.ReadOnly = true;
            this.stackText.Size = new System.Drawing.Size(107, 291);
            this.stackText.TabIndex = 8;
            // 
            // tactAlgorithmButton
            // 
            this.tactAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tactAlgorithmButton.Location = new System.Drawing.Point(216, 483);
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
            this.fullAlgorithmButton.Location = new System.Drawing.Point(674, 483);
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
            this.label5.Location = new System.Drawing.Point(417, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Выполнение алгоритма";
            // 
            // updateValuesButton
            // 
            this.updateValuesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateValuesButton.Location = new System.Drawing.Point(674, 218);
            this.updateValuesButton.Name = "updateValuesButton";
            this.updateValuesButton.Size = new System.Drawing.Size(167, 53);
            this.updateValuesButton.TabIndex = 12;
            this.updateValuesButton.Text = "Обновить";
            this.updateValuesButton.UseVisualStyleBackColor = true;
            this.updateValuesButton.Click += new System.EventHandler(this.updateValuesButton_Click);
            // 
            // stackPointerText
            // 
            this.stackPointerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackPointerText.Location = new System.Drawing.Point(128, 245);
            this.stackPointerText.MaxLength = 640;
            this.stackPointerText.Multiline = true;
            this.stackPointerText.Name = "stackPointerText";
            this.stackPointerText.ReadOnly = true;
            this.stackPointerText.Size = new System.Drawing.Size(71, 291);
            this.stackPointerText.TabIndex = 289;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 546);
            this.Controls.Add(this.stackPointerText);
            this.Controls.Add(this.updateValuesButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fullAlgorithmButton);
            this.Controls.Add(this.tactAlgorithmButton);
            this.Controls.Add(this.stackText);
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
        private System.Windows.Forms.TextBox stackText;
        private System.Windows.Forms.Button tactAlgorithmButton;
        private System.Windows.Forms.Button fullAlgorithmButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updateValuesButton;
        private System.Windows.Forms.TextBox stackPointerText;
    }
}

