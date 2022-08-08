namespace CalculatorFrontEnd
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CalculatorButtons = new UIButton[24];
            this.buttonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.displayLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.CalculatorText = new System.Windows.Forms.TextBox();
            this.displayLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsTableLayout
            // 
            this.buttonsTableLayout.Location = new System.Drawing.Point(0, 0);
            this.buttonsTableLayout.Name = "buttonsTableLayout";
            this.buttonsTableLayout.Size = new System.Drawing.Size(250, 400);
            this.buttonsTableLayout.TabIndex = 0;
            // 
            // displayLayout
            // 
            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.displayLayout.Controls.Add(this.ResultsLabel);
            this.displayLayout.Controls.Add(this.CalculatorText);
            this.displayLayout.Location = new System.Drawing.Point(0, 0);
            this.displayLayout.Name = "displayLayout";
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.displayLayout.Size = new System.Drawing.Size(200, 100);
            this.displayLayout.TabIndex = 1;
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.Location = new System.Drawing.Point(3, 0);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(100, 20);
            this.ResultsLabel.TabIndex = 0;
            // 
            // CalculatorText
            // 
            this.CalculatorText.Location = new System.Drawing.Point(3, 23);
            this.CalculatorText.Name = "CalculatorText";
            this.CalculatorText.Size = new System.Drawing.Size(100, 20);
            this.CalculatorText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.buttonsTableLayout);
            this.Controls.Add(this.displayLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.displayLayout.ResumeLayout(false);
            this.displayLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel buttonsTableLayout;
        private System.Windows.Forms.TableLayoutPanel displayLayout;
        private System.Windows.Forms.Label ResultsLabel;
    }
}

