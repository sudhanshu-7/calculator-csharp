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
        Normal,
        Red
    }
    enum CalculatorTextStatus
    {
        ShowingPreviousResult,
        Typing,
        Equated
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
        Decimal,
        Memory
    }
    public partial class Form1 : Form
    {
        #region Members
        private TableLayoutPanel _calculatorUILayout;
        private System.Windows.Forms.TableLayoutPanel _buttonsTableLayout;
        private System.Windows.Forms.TableLayoutPanel _memoryButtonsTableLayout;
        private System.Windows.Forms.TableLayoutPanel _displayLayout;
        private System.Windows.Forms.Label _resultsLabel;
        private UIButton[] _calculatorButtons;
        private UIButton[] _calculatorMemoryButtons;
        private System.Windows.Forms.TextBox _calculatorText;
        private CalculatorTextStatus _calculatorTextStatus;
        private CalculatorTextStatus _calculatorPreviousStatus;
        private string _currentInput, _previousInput;
        private Calculator.CustomCalculator _calculator;
        private readonly Newtonsoft.Json.Linq.JObject _buttonDetailsJSON;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        #endregion
        private void PerformButtonPress(char typedCharacter,CalculatorButtonType buttonType)
        {
            UIButton dummyButton = new UIButton("Dummy", typedCharacter.ToString(), -1, -1, ButtonDecoration.Gold, buttonType);
            dummyButton.Click += new EventHandler(ClickButtonHandler);
            dummyButton.PerformClick();
        }
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
            foreach (System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> element in _buttonDetailsJSON)
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
            this._calculatorUILayout = new TableLayoutPanel();
            this._calculatorButtons = new UIButton[24];
            this._calculatorMemoryButtons = new UIButton[5];
            this._buttonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._displayLayout = new System.Windows.Forms.TableLayoutPanel();
            this._memoryButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
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
            if (this._buttonDetailsJSON != null)
            {
                InitializeButtonArray();
            }
            //InitializeComponent();
            _currentInput = "";
            _previousInput = "";
            this._calculator = new Calculator.CustomCalculator();

            //calculator Text box
            this._calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
            this._calculatorPreviousStatus = CalculatorTextStatus.Equated;
            this._calculatorText.BorderStyle = BorderStyle.Fixed3D;
            this._calculatorText.Dock = DockStyle.Fill;
            this._calculatorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._calculatorText.TextAlign = HorizontalAlignment.Right;

            //result label
            //this._resultsLabel.AutoSize = false;
            //this._resultsLabel.BorderStyle = BorderStyle.None;
            this._resultsLabel.Dock = DockStyle.Fill;
            //this._resultsLabel.Font = this._calculatorText.Font;
            this._resultsLabel.AutoSize = true;
            this._resultsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this._resultsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            // this._resultsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._resultsLabel.Margin = new Padding(0,10,0,0);
            this._resultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._resultsLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this._resultsLabel.TextAlign = ContentAlignment.MiddleRight;

            //button layout
            this._buttonsTableLayout.Size = new System.Drawing.Size(534, 322);
            // this._buttonsTableLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
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
            // this._menuStrip.Dock = DockStyle.Top;
            //EditToolStrip MenuItem
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this._copyToolStripMenuItem,
                this._pasteToolStripMenuItem
            });

            //adding close functionality
            this._exitToolStripMenuItem.Click += (object sender, EventArgs e) =>
            {
                this.Close();
            };
            //adding Copy functionality
            this._copyToolStripMenuItem.Click += (object sender, EventArgs e) =>
            {

                Clipboard.SetText(this._calculatorText.Text);
            };

            //adding paste functionality
            this._pasteToolStripMenuItem.Click += (object sender, EventArgs e) => { 
                _currentInput = Clipboard.GetText();
                _calculatorTextStatus = CalculatorTextStatus.Typing;
                _calculatorText.Text = _currentInput;
            _calculatorText.SelectionStart = _calculatorText.Text.Length;
                _previousInput = "";
                _resultsLabel.Text = "";
            };

            //Memory Buttons
            // Considering that memory operations are fixed
            _calculatorMemoryButtons[0] = new UIButton("Memory Save", "MS", 0, 0, ButtonDecoration.Red, CalculatorButtonType.Memory);
            _calculatorMemoryButtons[1] = new UIButton("Memory Add", "M+", 0, 1, ButtonDecoration.Red, CalculatorButtonType.Memory);
            _calculatorMemoryButtons[2] = new UIButton("Memory Subtract", "M-", 0, 2, ButtonDecoration.Red, CalculatorButtonType.Memory);
            _calculatorMemoryButtons[3] = new UIButton("Memory Clear" , "MC" , 0 ,3 , ButtonDecoration.Red , CalculatorButtonType.Memory);
            _calculatorMemoryButtons[4] = new UIButton("Memory Read", "MR", 0, 4, ButtonDecoration.Red, CalculatorButtonType.Memory);
            
            //Memory Layout
            this._memoryButtonsTableLayout.AutoSize = true;
            // this._memoryButtonsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._memoryButtonsTableLayout.ColumnCount = 5;
            this._memoryButtonsTableLayout.RowCount = 1;
            for (int columns = 0; columns < _memoryButtonsTableLayout.ColumnCount; columns++)
            {
                this._memoryButtonsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            }
            this._memoryButtonsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));

            //UI Layout Component

            this._calculatorUILayout.AutoSize = true;
            this._calculatorUILayout.RowCount = 4;
            this._calculatorUILayout.ColumnCount = 1;
            this._calculatorUILayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._calculatorUILayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _calculatorUILayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            _calculatorUILayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            _calculatorUILayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            _calculatorUILayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));

            _calculatorUILayout.Controls.Add(this._menuStrip);
            _calculatorUILayout.Controls.Add(this._displayLayout);
            _calculatorUILayout.Controls.Add(this._memoryButtonsTableLayout);
            _calculatorUILayout.Controls.Add(this._buttonsTableLayout);
            for(int index = 0; index < _calculatorUILayout.RowCount; index++)
            {
                _calculatorUILayout.Controls[index].Dock = System.Windows.Forms.DockStyle.Fill;
            }

            //Form Component
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            //this.Controls.Add(this._menuStrip);
            //this.Controls.Add(this._displayLayout);
            //this.Controls.Add(this._memoryButtonsTableLayout);
            //this.Controls.Add(this._buttonsTableLayout);
            this.Controls.Add(this._calculatorUILayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculator";
            this._calculatorText.KeyPress += new KeyPressEventHandler(KeyPressEventHandler);
            this.Load += new System.EventHandler(this.Form1_Load);
            this._displayLayout.ResumeLayout(false);
            this._memoryButtonsTableLayout.ResumeLayout(false);
            this._buttonsTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private void KeyPressEventHandler(object sender, KeyPressEventArgs e)
        {
            char typedCharacter = e.KeyChar;
            if (typedCharacter == '÷') typedCharacter = '/';
            CalculatorButtonType buttonType = CalculatorButtonType.Numeric;
            if (Char.IsNumber(typedCharacter)) buttonType = CalculatorButtonType.Numeric;
            else if (ResourceFile.AvailableOperators.Contains(typedCharacter)) buttonType = CalculatorButtonType.BinaryOperator;
            else if (typedCharacter == '\b')
            {
                buttonType = CalculatorButtonType.Backspace;
            }else if(typedCharacter == '.')
            {
                buttonType = CalculatorButtonType.Decimal;
            }
            else if (Char.IsNumber(typedCharacter))
            {
                PerformButtonPress(typedCharacter, CalculatorButtonType.Numeric);
            }
            else if (typedCharacter == '=' || typedCharacter == (char)13) buttonType = CalculatorButtonType.Equate;
            else
            {
                e.Handled = true;
                return;
            }
            PerformButtonPress(typedCharacter , buttonType);
            e.Handled = true;
        }
        private void ClickButtonHandler (object sender , EventArgs e)
        {
            try
            {
                UIButton button = (UIButton)sender;
                double answer;
                switch (button.Type)
                {
                    case CalculatorButtonType.Numeric:
                        if (_calculatorPreviousStatus == CalculatorTextStatus.Equated)
                        {
                            _previousInput = "";
                            _calculatorPreviousStatus = CalculatorTextStatus.Typing;
                        }
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
                            if (_calculatorPreviousStatus == CalculatorTextStatus.Equated)
                            {
                                _previousInput += binaryOperator;
                                _calculatorPreviousStatus = CalculatorTextStatus.Typing;
                            }
                            else if (_previousInput == "")
                            {
                                _previousInput = "0" + binaryOperator;
                            }
                            else
                            {
                                _previousInput = _previousInput.Remove(_previousInput.Length - 1, 1) + binaryOperator;

                            }
                        }
                        else
                        {
                            if (_previousInput == "")
                            {
                                _previousInput = "0+" + _currentInput;
                            }
                            else
                            {
                                _previousInput += _currentInput;
                            }
                            answer = _calculator.Evaluate(_previousInput);
                            _previousInput = answer.ToString() + binaryOperator;
                            _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                            _currentInput = answer.ToString();
                        }
                        break;
                    case CalculatorButtonType.ClearEntry:
                        _currentInput = "0";
                        _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                        break;
                    case CalculatorButtonType.Backspace:
                        Console.WriteLine("Inside Backspace with " + _calculatorTextStatus);
                        if (_calculatorTextStatus == CalculatorTextStatus.Typing && _currentInput.Length > 0)
                        {
                            _currentInput = _currentInput.Remove(_currentInput.Length - 1, 1);
                        }
                        break;
                    case CalculatorButtonType.ClearAll:
                        _currentInput = "0";
                        _previousInput = "";
                        _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                        break;
                    case CalculatorButtonType.Decimal:
                        if (_calculatorTextStatus == CalculatorTextStatus.ShowingPreviousResult)
                        {
                            _calculatorTextStatus = CalculatorTextStatus.Typing;
                            _currentInput = "0.";
                        }
                        else
                        {
                            if (_currentInput.Contains(".") == false)
                            {
                                _currentInput += ".";
                            }
                        }
                        break;
                    case CalculatorButtonType.Equate:
                        if (_calculatorPreviousStatus == CalculatorTextStatus.Equated) break;
                        if (_previousInput == "") _previousInput = "0+";
                        if (_currentInput == "") _currentInput = "0";
                        _previousInput = (_previousInput + _currentInput);
                        answer = _calculator.Evaluate(_previousInput);
                        _currentInput = answer.ToString();
                        _previousInput = _currentInput;
                        _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
                        _calculatorPreviousStatus = CalculatorTextStatus.Equated;
                        break;
                    case CalculatorButtonType.Memory:
                        HandleMemoryEvents(button);
                        break;
                    default:
                        break;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                _previousInput = "";
                _currentInput = "Invalid String Entered";
                _calculatorTextStatus = CalculatorTextStatus.ShowingPreviousResult;
            }

            _calculatorText.Focus();
            _calculatorText.Clear();
            _calculatorText.Text = _currentInput;
            _calculatorText.SelectionStart = _calculatorText.Text.Length;
            _resultsLabel.Text = _previousInput;

        }
        private void HandleMemoryEvents(UIButton buttonObject)
        {
            string name = buttonObject.Name;
            switch (name)
            {
                case "Memory Read":
                    _currentInput = _calculator.MemoryRecall().ToString();
                    break;
                case "Memory Save":
                    if(_calculatorPreviousStatus == CalculatorTextStatus.Equated)
                    {
                        _previousInput = "";
                    }
                    _calculator.MemorySave(Double.Parse(_currentInput));
                    break;
                case "Memory Add":
                    if (_calculatorPreviousStatus == CalculatorTextStatus.Equated)
                    {
                        _previousInput = "";
                    }
                    _calculatorPreviousStatus = CalculatorTextStatus.ShowingPreviousResult;
                    if (_currentInput == "")
                    {
                        _currentInput = "0";
                    }
                    _calculator.MemoryModification(Double.Parse(_currentInput));
                    break;
                case "Memory Subtract":
                    if (_calculatorPreviousStatus == CalculatorTextStatus.Equated)
                    {
                        _previousInput = "";
                    }
                    _calculatorPreviousStatus = CalculatorTextStatus.ShowingPreviousResult;
                    if (_currentInput == "")
                    {
                        _currentInput = "0";
                    }
                    _calculator.MemoryModification(-1 * Double.Parse(_currentInput));
                    break;
                case "Memory Clear":
                    _calculator.MemoryClear();
                    break;
                default:
                  _currentInput = "";
                  _previousInput = "";
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _displayLayout.Controls.Add(_resultsLabel,0,0);
            _displayLayout.Controls.Add(_calculatorText,0,1);
            for (int index = 0; index < _calculatorButtons.Length; index++)
            {
                _calculatorButtons[index].Click += new EventHandler(ClickButtonHandler);
                this._buttonsTableLayout.Controls.Add(_calculatorButtons[index], _calculatorButtons[index].Column, _calculatorButtons[index].Row);
            }
            for (int index = 0; index < _calculatorMemoryButtons.Length; index++)
            {
                _calculatorMemoryButtons[index].Click += new EventHandler(ClickButtonHandler);
                this._memoryButtonsTableLayout.Controls.Add(_calculatorMemoryButtons[index], _calculatorMemoryButtons[index].Column, _calculatorMemoryButtons[index].Row);
            }
            this.ActiveControl = this._calculatorText;
            this._calculatorText.SelectionStart = _calculatorText.Text.Length;
        }
    }
}
