using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalculatorFrontEnd
{
    enum ButtonDecoration
    {
        Gold,
        Dark,
        Normal
    }
    enum CalculatorTextStatus
    {
        ShowingPreviousResult,
        Typing
    }
    enum CalculatorButtonType
    {
        Numeric,
        UnaryOperator,
        BinaryOperator,
        ClearEntry,
        ClearAll,
        Backspace,
        Equate,
        Decimal
    }
    public partial class Form1 : Form
    {
        private System.Windows.Forms.TableLayoutPanel _buttonsTableLayout;
        private System.Windows.Forms.TableLayoutPanel _displayLayout;
        private System.Windows.Forms.Label _resultsLabel;
        private UIButton[] _calculatorButtons;
        private System.Windows.Forms.TextBox _calculatorText;
        private CalculatorTextStatus _calculatorTextStatus;
        private string _currentInput, _previousInput;
        private Calculator.CustomCalculator _calculator;
        private readonly Newtonsoft.Json.Linq.JObject _buttonDetailsJSON;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private Newtonsoft.Json.Linq.JObject GetDetailsFromJson(string pathName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathName))
                {
                    string json = reader.ReadToEnd();
                    dynamic jsonArray = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var jsonObject = jsonArray[0];
                    return jsonArray[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        private void InitializeButtonArray()
        {
            int index = 0;
            foreach(System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> element in _buttonDetailsJSON)
            {
                string key = element.Key;
                var jsonObject = element.Value;
                _calculatorButtons[index++] = new UIButton(key,
                    jsonObject["Text"].ToString(),
                    Int32.Parse((string)jsonObject["Row"]),
                    Int32.Parse(jsonObject["Column"].ToString()),
                    Calculator.ConverterClass.GetEnumFromString<ButtonDecoration>(jsonObject["Decoration"].ToString()),
                    Calculator.ConverterClass.GetEnumFromString<CalculatorButtonType>(jsonObject["ButtonType"].ToString())
                    );
            }
        }
        public Form1()
        {

            //Initialization
            this._calculatorButtons = new UIButton[24];
            this._buttonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._displayLayout = new System.Windows.Forms.TableLayoutPanel();
            this._resultsLabel = new System.Windows.Forms.Label();
            this._calculatorText = new System.Windows.Forms.TextBox();
            this._displayLayout.SuspendLayout();
            this.SuspendLayout();
            this._buttonDetailsJSON = GetDetailsFromJson(ResourceFile.JsonPath);
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Edit");
            this._copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Copy");
            this._pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Paste");
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Help");
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Exit");
            _resultsLabel.Text = "";
            _calculatorText.Text = "0";
            if(this._buttonDetailsJSON != null)
            {
                InitializeButtonArray();
            }
            //InitializeComponent();
            _currentInput = "";
            _previousInput = "";
            this._calculator = new Calculator.CustomCalculator();

            //calculator Text box
            this._calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
            this._calculatorText.BorderStyle = BorderStyle.None;
            this._calculatorText.Dock = DockStyle.Fill;
            this._calculatorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._calculatorText.TextAlign = HorizontalAlignment.Right;

            //result label
            this._resultsLabel.AutoSize = false;
            this._resultsLabel.BorderStyle = BorderStyle.None;
            this._resultsLabel.Dock = DockStyle.Fill;
            this._resultsLabel.Font = this._calculatorText.Font;
            this._resultsLabel.TextAlign = ContentAlignment.MiddleRight;

            //button layout
            this._buttonsTableLayout.Size = new System.Drawing.Size(534, 322);
            this._buttonsTableLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsTableLayout.Location = new System.Drawing.Point(0, 166);
            this._buttonsTableLayout.RowCount = 6;
            this._buttonsTableLayout.ColumnCount = 4;
            for (int column = 0; column < this._buttonsTableLayout.ColumnCount; column++)
            {
                this._buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for (int row = 0; row < this._buttonsTableLayout.RowCount; row++)
            {
                this._buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            }
            //Display Layout
            this._displayLayout.AutoSize = true;
            this._displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._displayLayout.RowCount = 2;
            this._displayLayout.ColumnCount = 1;
            this._displayLayout.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);


            //Button Layout



            this._displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            for (int row = 0; row < this._displayLayout.RowCount; ++row)
            {
                this._displayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            //MenuStrip
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this._editToolStripMenuItem,
                this._helpToolStripMenuItem,
                this._exitToolStripMenuItem
            });
            this._menuStrip.Dock = DockStyle.None;
            //EditToolStrip MenuItem
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this._copyToolStripMenuItem,
                this._pasteToolStripMenuItem
            });

            this._exitToolStripMenuItem.Click += (object sender, EventArgs e) =>
            {
                this.Close();
            };


            //Form Component

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._displayLayout);
            this.Controls.Add(this._buttonsTableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this._displayLayout.ResumeLayout(false);
            this._buttonsTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private void ClickButtonHandler (object sender , EventArgs e)
        {
            UIButton button = (UIButton)sender;
            double answer;
            switch (button.Type)
            {
                case CalculatorButtonType.Numeric:
                    if (_calculatorTextStatus == CalculatorTextStatus.ShowingPreviousResult)
                    {
                        _calculatorTextStatus = CalculatorTextStatus.Typing;
                        _currentInput = button.Text;
                    }
                    else
                    {
                        _currentInput += button.Text;
                    }
                    break;
                case CalculatorButtonType.UnaryOperator:
                    break;
                case CalculatorButtonType.BinaryOperator:
                    string binaryOperator = button.Text == "÷" ? "/" : button.Text;

                    //Check Whether the last operator is a character or not
                    if (_calculatorTextStatus == CalculatorTextStatus.ShowingPreviousResult)
                    {
                        if(_previousInput == "")
                        {
                            _previousInput = "0" + binaryOperator;
                        }
                        else
                        {
                            _previousInput = _previousInput.Remove(_previousInput.Length - 1,1) + binaryOperator;

                        }
                    }
                    else
                    {
                        if(_previousInput == "")
                        {
                            _previousInput = "0+"+_currentInput;
                        }
                        else
                        {
                            _previousInput += _currentInput;
                        }
                        answer = _calculator.Evaluate(_previousInput);
                        _previousInput = answer.ToString() + binaryOperator ;
                        _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                        _currentInput = answer.ToString();
                    }
                    break;
                case CalculatorButtonType.ClearEntry:
                    _currentInput = "0";
                    _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                    break;
                case CalculatorButtonType.Backspace:
                    break;
                case CalculatorButtonType.ClearAll:
                    _currentInput = "0";
                    _previousInput = "";
                    _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                    break;
                case CalculatorButtonType.Decimal:
                    if(_calculatorTextStatus == CalculatorTextStatus.ShowingPreviousResult)
                    {
                        _calculatorTextStatus = CalculatorTextStatus.Typing;
                        _currentInput = "0.";
                    }
                    else
                    {
                        if(_currentInput.Contains(".") == false)
                        {
                            _currentInput += ".";
                        }
                    }
                    break;
                case CalculatorButtonType.Equate:
                    if (_previousInput == "") _previousInput = "0+";
                    if (_currentInput == "") _currentInput = "0";
                    _previousInput = (_previousInput + _currentInput);
                     answer = _calculator.Evaluate(_previousInput);
                    _currentInput = answer.ToString();
                    _previousInput = _currentInput;
                    _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                    break;
                default:
                    break;
            }
            _calculatorText.Focus();
            _calculatorText.Text = _currentInput;
            _calculatorText.SelectionStart = _calculatorText.Text.Length;
            _resultsLabel.Text = _previousInput;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("We Have : {0} elements in Buttons",_calculatorButtons.Length);
            this.ActiveControl = this._displayLayout;
            _displayLayout.Controls.Add(_resultsLabel,0,0);
            _displayLayout.Controls.Add(_calculatorText,0,1);
            for (int index = 0; index < _calculatorButtons.Length; index++)
            {
                _calculatorButtons[index].Click += new EventHandler(ClickButtonHandler);
                this._buttonsTableLayout.Controls.Add(_calculatorButtons[index], _calculatorButtons[index].Column, _calculatorButtons[index].Row);
            }
        }
    }
}
