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
            if(buttonDecoration == ButtonDecoration.Normal)
            {
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UseVisualStyleBackColor = true;
            }else if (buttonDecoration == ButtonDecoration.Dark)
            {

                this.BackColor = System.Drawing.SystemColors.ScrollBar;
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UseVisualStyleBackColor = false;
            }
            else
            {
                this.BackColor = System.Drawing.Color.Goldenrod;
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UseVisualStyleBackColor = false;
            }
        }

    }
}
