using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculatorFrontEnd
{
    internal class UIButton : Button
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public UIButton(string name , string text , int row , int column , ButtonType buttonType)
        {
            Row = row;
            Column = column;
            this.Text = text;
            this.Name = name;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            if(buttonType == ButtonType.NumpadButton)
            {
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UseVisualStyleBackColor = true;
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
