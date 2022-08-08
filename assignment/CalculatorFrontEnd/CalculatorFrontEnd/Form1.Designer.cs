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

            // 
            // _buttonsTableLayout
            // 
            this._buttonsTableLayout.Location = new System.Drawing.Point(0, 0);
            this._buttonsTableLayout.Name = "_buttonsTableLayout";
            this._buttonsTableLayout.Size = new System.Drawing.Size(250, 400);
            this._buttonsTableLayout.TabIndex = 0;
            // 
            // _displayLayout
            // 
            this._displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._displayLayout.Controls.Add(this._resultsLabel);
            this._displayLayout.Controls.Add(this._calculatorText);
            this._displayLayout.Location = new System.Drawing.Point(0, 0);
            this._displayLayout.Name = "_displayLayout";
            this._displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._displayLayout.Size = new System.Drawing.Size(200, 100);
            this._displayLayout.TabIndex = 1;
            // 
            // _resultsLabel
            // 
            this._resultsLabel.Location = new System.Drawing.Point(3, 0);
            this._resultsLabel.Name = "_resultsLabel";
            this._resultsLabel.Size = new System.Drawing.Size(100, 20);
            this._resultsLabel.TabIndex = 0;
            // 
            // _calculatorText
            // 
            this._calculatorText.Location = new System.Drawing.Point(3, 23);
            this._calculatorText.Name = "_calculatorText";
            this._calculatorText.Size = new System.Drawing.Size(100, 20);
            this._calculatorText.TabIndex = 1;
            // 
            // Form1
            // 


        }

        #endregion

    }
}

