using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFrontEnd
{
    internal class OperatorButton : System.Windows.Forms.Button
    {
        public OperatorButton(string text , string name)
        {
            this.Text = text;
            this.Name = name;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Location = new System.Drawing.Point(402, 3);
            //this.Size = new System.Drawing.Size(129, 47);
            this.TabIndex = 4;
            this.UseVisualStyleBackColor = false;
        }
    }
}
