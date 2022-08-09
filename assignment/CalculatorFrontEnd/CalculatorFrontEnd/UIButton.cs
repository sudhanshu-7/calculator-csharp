using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculatorFrontEnd
{
    internal class UIButton : Button
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public CalculatorButtonType Type { get; set; }
        public UIButton(string name, string text, int row, int column, ButtonDecoration buttonDecoration, CalculatorButtonType buttonType)
      
        {
            Row = row;
            Column = column;
            this.Text = text;
            this.Name = name;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Type = buttonType;
            this.Dock = DockStyle.Fill; 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            switch (buttonDecoration)
            {
                case ButtonDecoration.Normal:
                    this.UseVisualStyleBackColor = true;
                    break;
                case ButtonDecoration.Dark:
                    this.BackColor = System.Drawing.SystemColors.ScrollBar;
                    this.UseVisualStyleBackColor = false;
                    break;
                case ButtonDecoration.Gold:
                    this.BackColor = System.Drawing.Color.Goldenrod;
                    this.UseVisualStyleBackColor = false;
                    break;
                case ButtonDecoration.Red:
                    this.BackColor = System.Drawing.Color.IndianRed;
                    this.UseVisualStyleBackColor = false;
                    break;
                default:
                    break;
            }
        }

    }
}
