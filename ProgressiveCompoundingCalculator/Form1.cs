using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProgressiveCompoundingCalculator
{
    public partial class Form1 : Form
    {
        private TextBox? activeInput;  // Made nullable

        public Form1()
        {
            InitializeComponent();
            SetupForm();
            WireUpEvents();
        }

        // Added to resolve Form1_Load error
        private void Form1_Load(object? sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void SetupForm()
        {
            // Form properties
            this.Text = "Progressive Compounding Calculator";
            this.ClientSize = new Size(450, 600);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Main container panel (calculator)
            Panel calculatorPanel = new Panel();
            calculatorPanel.BackColor = Color.White;
            calculatorPanel.BorderStyle = BorderStyle.None;
            calculatorPanel.Size = new Size(400, 550);
            calculatorPanel.Location = new Point(
                (this.ClientSize.Width - calculatorPanel.Width) / 2,
                (this.ClientSize.Height - calculatorPanel.Height) / 2);
            calculatorPanel.Anchor = AnchorStyles.None;
            this.Controls.Add(calculatorPanel);

            // Title label
            Label titleLabel = new Label();
            titleLabel.Text = "Progressive Compounding Calculator";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(51, 51, 51);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(
                (calculatorPanel.Width - titleLabel.Width) / 2, 20);
            calculatorPanel.Controls.Add(titleLabel);

            // Input fields
            AddInputField(calculatorPanel, "Initial Balance ($):", "initial", 60);
            AddInputField(calculatorPanel, "Multiplier (e.g., 1.05 for 5% increase):", "multiplier", 130);
            AddInputField(calculatorPanel, "Number of Times:", "times", 200);

            // Keypad
            CreateKeypad(calculatorPanel, 270);

            // Result panel
            SetupResultPanel(calculatorPanel);
        }

        private void SetupResultPanel(Panel calculatorPanel)
        {
            Panel resultPanel = new Panel();
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new Size(360, 150);
            resultPanel.Location = new Point(20, 380);
            resultPanel.BackColor = Color.FromArgb(233, 247, 239);
            resultPanel.BorderStyle = BorderStyle.None;
            resultPanel.Visible = false;
            calculatorPanel.Controls.Add(resultPanel);

            // Final amount label
            Label finalAmountLabel = new Label();
            finalAmountLabel.Name = "finalAmountLabel";
            finalAmountLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            finalAmountLabel.ForeColor = Color.FromArgb(46, 125, 50);
            finalAmountLabel.AutoSize = true;
            finalAmountLabel.Location = new Point(10, 10);
            resultPanel.Controls.Add(finalAmountLabel);

            // Breakdown components
            Label breakdownLabel = new Label();
            breakdownLabel.Text = "Breakdown:";
            breakdownLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            breakdownLabel.AutoSize = true;
            breakdownLabel.Location = new Point(10, 40);
            resultPanel.Controls.Add(breakdownLabel);

            ListBox breakdownListBox = new ListBox();
            breakdownListBox.Name = "breakdownListBox";
            breakdownListBox.Size = new Size(340, 90);
            breakdownListBox.Location = new Point(10, 60);
            breakdownListBox.BackColor = Color.FromArgb(248, 248, 248);
            breakdownListBox.BorderStyle = BorderStyle.None;
            resultPanel.Controls.Add(breakdownListBox);
        }

        private void AddInputField(Panel parent, string labelText, string name, int top)
        {
            Label label = new Label();
            label.Text = labelText;
            label.Font = new Font("Arial", 9, FontStyle.Bold);
            label.AutoSize = true;
            label.Location = new Point(20, top);
            parent.Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Name = name;
            textBox.Size = new Size(360, 20);
            textBox.Location = new Point(20, top + 20);
            textBox.Font = new Font("Arial", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            parent.Controls.Add(textBox);
        }

        private void CreateKeypad(Panel parent, int top)
        {
            TableLayoutPanel keypadPanel = new TableLayoutPanel();
            keypadPanel.Size = new Size(360, 200);
            keypadPanel.Location = new Point(20, top);
            keypadPanel.ColumnCount = 3;
            keypadPanel.RowCount = 5;

            for (int i = 0; i < 3; i++)
                keypadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            for (int i = 0; i < 5; i++)
                keypadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));

            parent.Controls.Add(keypadPanel);

            // Number buttons
            AddKeypadButton(keypadPanel, "7", 0, 0);
            AddKeypadButton(keypadPanel, "8", 0, 1);
            AddKeypadButton(keypadPanel, "9", 0, 2);
            AddKeypadButton(keypadPanel, "4", 1, 0);
            AddKeypadButton(keypadPanel, "5", 1, 1);
            AddKeypadButton(keypadPanel, "6", 1, 2);
            AddKeypadButton(keypadPanel, "1", 2, 0);
            AddKeypadButton(keypadPanel, "2", 2, 1);
            AddKeypadButton(keypadPanel, "3", 2, 2);
            AddKeypadButton(keypadPanel, "0", 3, 0);
            AddKeypadButton(keypadPanel, ".", 3, 1);

            // Clear button
            Button clearButton = AddKeypadButton(keypadPanel, "C", 3, 2);
            clearButton.BackColor = Color.FromArgb(244, 67, 54);
            clearButton.ForeColor = Color.White;

            // Calculate button
            Button calculateButton = new Button();
            calculateButton.Text = "Calculate";
            calculateButton.Dock = DockStyle.Fill;
            calculateButton.Font = new Font("Arial", 12);
            calculateButton.BackColor = Color.FromArgb(33, 150, 243);
            calculateButton.ForeColor = Color.White;
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.FlatAppearance.BorderSize = 0;
            keypadPanel.SetColumnSpan(calculateButton, 3);
            keypadPanel.Controls.Add(calculateButton, 0, 4);
            calculateButton.Click += CalculateButton_Click!;
        }

        private Button AddKeypadButton(TableLayoutPanel panel, string text, int row, int column)
        {
            Button button = new Button();
            button.Text = text;
            button.Dock = DockStyle.Fill;
            button.Font = new Font("Arial", 12);
            button.BackColor = Color.FromArgb(76, 175, 80);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            panel.Controls.Add(button, column, row);
            button.Click += KeypadButton_Click!;
            return button;
        }

        private void WireUpEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is TextBox textBox)
                        {
                            textBox.Enter += (sender, e) =>
                            {
                                activeInput = (TextBox)sender;
                            };
                        }
                    }
                }
            }

            if (this.Controls.Count > 0 && this.Controls[0] is Panel mainPanel)
            {
                foreach (Control control in mainPanel.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        activeInput = textBox;
                        break;
                    }
                }
            }
        }

        private void KeypadButton_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;

            Button button = (Button)sender;
            string value = button.Text;

            if (value == "C")
            {
                // Clear all input fields in the calculator panel
                if (this.Controls[0] is Panel calculatorPanel)
                {
                    foreach (Control control in calculatorPanel.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            textBox.Text = "";
                        }
                    }

                    // Hide the result panel if it's visible
                    var resultPanel = GetControl<Panel>(calculatorPanel, "resultPanel");
                    if (resultPanel != null)
                    {
                        resultPanel.Visible = false;
                    }
                }
            }
            else
            {
                // Existing number/decimal input logic
                if (activeInput == null) return;

                if (value == ".")
                {
                    if (!activeInput.Text.Contains("."))
                    {
                        activeInput.Text += value;
                    }
                }
                else
                {
                    activeInput.Text += value;
                }
            }
        }

        private void CalculateButton_Click(object? sender, EventArgs e)
        {
            if (this.Controls.Count == 0 || this.Controls[0] is not Panel calculatorPanel)
                return;

            // Get controls with null checks
            var initialTextBox = GetControl<TextBox>(calculatorPanel, "initial");
            var multiplierTextBox = GetControl<TextBox>(calculatorPanel, "multiplier");
            var timesTextBox = GetControl<TextBox>(calculatorPanel, "times");

            if (initialTextBox == null || multiplierTextBox == null || timesTextBox == null)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate inputs
            if (!ValidateInput(initialTextBox.Text, out double initial, "Initial balance") ||
                !ValidateInput(multiplierTextBox.Text, out double multiplier, "Multiplier") ||
                !ValidateInput(timesTextBox.Text, out int times, "Number of times", true))
            {
                return;
            }

            // Perform calculation
            var (result, breakdown) = CalculateCompounding(initial, multiplier, times);

            // Display results
            DisplayResults(calculatorPanel, result, breakdown);
        }

        private T? GetControl<T>(Panel panel, string name) where T : Control
        {
            return panel.Controls.Find(name, true).FirstOrDefault() as T;
        }

        private bool ValidateInput(string input, out double value, string fieldName)
        {
            if (!double.TryParse(input, out value) || value <= 0)
            {
                MessageBox.Show($"Please enter a valid {fieldName} (positive number)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateInput(string input, out int value, string fieldName, bool isInt = false)
        {
            if (!int.TryParse(input, out value) || value < 1)
            {
                MessageBox.Show($"Please enter a valid {fieldName} (whole number at least 1)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private (double result, List<string> breakdown) CalculateCompounding(double initial, double multiplier, int times)
        {
            double result = initial;
            List<string> breakdown = new List<string>();

            for (int i = 1; i <= times; i++)
            {
                double newAmount = result * multiplier;
                double increase = newAmount - result;
                result = newAmount;
                breakdown.Add($"Period {i}: +${increase:F2} → ${result:F2}");
            }

            return (result, breakdown);
        }

        private void DisplayResults(Panel calculatorPanel, double result, List<string> breakdown)
        {
            // Create and configure the results form
            Form resultsForm = new Form
            {
                Text = "Calculation Results",
                Size = new Size(400, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Create the results controls
            Label finalAmountLabel = new Label
            {
                Text = $"Final Amount: ${result:F2}",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 125, 50),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label breakdownLabel = new Label
            {
                Text = "Breakdown:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 50)
            };

            ListBox breakdownListBox = new ListBox
            {
                Size = new Size(340, 350),
                Location = new Point(20, 80),
                Font = new Font("Arial", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Add items to the breakdown list
            breakdownListBox.Items.AddRange(breakdown.ToArray());

            // Create a close button
            Button closeButton = new Button
            {
                Text = "Close",
                Size = new Size(100, 30),
                Location = new Point(260, 440),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            closeButton.Click += (s, e) => resultsForm.Close();

            // Add controls to the form
            resultsForm.Controls.AddRange(new Control[] 
            { 
                finalAmountLabel, 
                breakdownLabel, 
                breakdownListBox, 
                closeButton 
            });

            // Show the results form as a dialog
            resultsForm.ShowDialog(this);
        }
    }
}