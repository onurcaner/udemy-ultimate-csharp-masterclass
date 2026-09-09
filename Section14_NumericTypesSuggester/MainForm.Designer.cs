using System.ComponentModel;

namespace Section14_NumericTypesSuggester;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        MinValueLabel = new System.Windows.Forms.Label();
        MinValueTextBox = new System.Windows.Forms.TextBox();
        MaxValueLabel = new System.Windows.Forms.Label();
        MaxValueTextBox = new System.Windows.Forms.TextBox();
        IntegralOnlyCheckBox = new System.Windows.Forms.CheckBox();
        MustBePreciseCheckBox = new System.Windows.Forms.CheckBox();
        SuggestedTypeLabel = new System.Windows.Forms.Label();
        SuggestedTypeValueLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // MinValueLabel
        // 
        MinValueLabel.AutoSize = true;
        MinValueLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
        MinValueLabel.Location = new System.Drawing.Point(34, 27);
        MinValueLabel.Name = "MinValueLabel";
        MinValueLabel.Size = new System.Drawing.Size(165, 45);
        MinValueLabel.TabIndex = 0;
        MinValueLabel.Text = "Min value:";
        // 
        // MinValueTextBox
        // 
        MinValueTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
        MinValueTextBox.Location = new System.Drawing.Point(205, 29);
        MinValueTextBox.Name = "MinValueTextBox";
        MinValueTextBox.Size = new System.Drawing.Size(640, 45);
        MinValueTextBox.TabIndex = 1;
        MinValueTextBox.WordWrap = false;
        MinValueTextBox.TextChanged += MinValueTextBox_TextChanged;
        // 
        // MaxValueLabel
        // 
        MaxValueLabel.AutoSize = true;
        MaxValueLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
        MaxValueLabel.Location = new System.Drawing.Point(34, 83);
        MaxValueLabel.Name = "MaxValueLabel";
        MaxValueLabel.Size = new System.Drawing.Size(170, 45);
        MaxValueLabel.TabIndex = 2;
        MaxValueLabel.Text = "Max value:";
        // 
        // MaxValueTextBox
        // 
        MaxValueTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
        MaxValueTextBox.Location = new System.Drawing.Point(205, 85);
        MaxValueTextBox.Name = "MaxValueTextBox";
        MaxValueTextBox.Size = new System.Drawing.Size(640, 45);
        MaxValueTextBox.TabIndex = 3;
        MaxValueTextBox.WordWrap = false;
        MaxValueTextBox.TextChanged += MaxValueTextBox_TextChanged;
        // 
        // IntegralOnlyCheckBox
        // 
        IntegralOnlyCheckBox.AutoSize = true;
        IntegralOnlyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
        IntegralOnlyCheckBox.Checked = true;
        IntegralOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
        IntegralOnlyCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
        IntegralOnlyCheckBox.Font = new System.Drawing.Font("Segoe UI", 16F);
        IntegralOnlyCheckBox.Location = new System.Drawing.Point(34, 154);
        IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
        IntegralOnlyCheckBox.Size = new System.Drawing.Size(231, 49);
        IntegralOnlyCheckBox.TabIndex = 4;
        IntegralOnlyCheckBox.Text = "Integral only:";
        IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
        IntegralOnlyCheckBox.CheckedChanged += IntegralOnlyCheckBox_CheckedChanged;
        // 
        // MustBePreciseCheckBox
        // 
        MustBePreciseCheckBox.AutoSize = true;
        MustBePreciseCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
        MustBePreciseCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
        MustBePreciseCheckBox.Font = new System.Drawing.Font("Segoe UI", 16F);
        MustBePreciseCheckBox.Location = new System.Drawing.Point(34, 209);
        MustBePreciseCheckBox.Name = "MustBePreciseCheckBox";
        MustBePreciseCheckBox.Size = new System.Drawing.Size(280, 49);
        MustBePreciseCheckBox.TabIndex = 5;
        MustBePreciseCheckBox.Text = "Must be precise:";
        MustBePreciseCheckBox.UseVisualStyleBackColor = true;
        MustBePreciseCheckBox.Visible = false;
        MustBePreciseCheckBox.CheckedChanged += MustBePreciseCheckBox_CheckedChanged;
        // 
        // SuggestedTypeLabel
        // 
        SuggestedTypeLabel.AutoSize = true;
        SuggestedTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        SuggestedTypeLabel.Location = new System.Drawing.Point(34, 288);
        SuggestedTypeLabel.Name = "SuggestedTypeLabel";
        SuggestedTypeLabel.Size = new System.Drawing.Size(228, 38);
        SuggestedTypeLabel.TabIndex = 6;
        SuggestedTypeLabel.Text = "Suggested type:";
        // 
        // SuggestedTypeValueLabel
        // 
        SuggestedTypeValueLabel.AutoSize = true;
        SuggestedTypeValueLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        SuggestedTypeValueLabel.Location = new System.Drawing.Point(268, 288);
        SuggestedTypeValueLabel.Name = "SuggestedTypeValueLabel";
        SuggestedTypeValueLabel.Size = new System.Drawing.Size(250, 38);
        SuggestedTypeValueLabel.TabIndex = 7;
        SuggestedTypeValueLabel.Text = "Not enough data!";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(937, 382);
        Controls.Add(SuggestedTypeValueLabel);
        Controls.Add(SuggestedTypeLabel);
        Controls.Add(MustBePreciseCheckBox);
        Controls.Add(IntegralOnlyCheckBox);
        Controls.Add(MaxValueTextBox);
        Controls.Add(MaxValueLabel);
        Controls.Add(MinValueTextBox);
        Controls.Add(MinValueLabel);
        Text = "C# Numeric Types Suggester";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label SuggestedTypeLabel;

    private System.Windows.Forms.Label SuggestedTypeValueLabel;

    private System.Windows.Forms.CheckBox MustBePreciseCheckBox;

    private System.Windows.Forms.TextBox MinValueTextBox;
    private System.Windows.Forms.Label MaxValueLabel;
    private System.Windows.Forms.TextBox MaxValueTextBox;
    private System.Windows.Forms.CheckBox IntegralOnlyCheckBox;

    private System.Windows.Forms.Label MinValueLabel;

    #endregion
}