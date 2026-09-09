namespace Section14_NumericTypesSuggester;

public partial class MainForm : Form
{
    private static readonly Dictionary<SuggestedType, string> s_suggestedTypeMapping = new()
    {
        [SuggestedType.NotEnoughData] = "Not enough data!",
        [SuggestedType.ImpossibleRepresentation] = "Impossible representation!",
        [SuggestedType.MinValueGtMaxValue] = "\"Max value\" is less than \"Min value\"",

        [SuggestedType.Decimal] = "decimal",
        [SuggestedType.Double] = "double",
        [SuggestedType.Float] = "float",

        [SuggestedType.BigInteger] = "BigInteger",
        [SuggestedType.ULong] = "ulong",
        [SuggestedType.Long] = "long",
        [SuggestedType.UInt] = "uint",
        [SuggestedType.Int] = "int",
        [SuggestedType.UShort] = "ushort",
        [SuggestedType.Short] = "short",
        [SuggestedType.Byte] = "byte",
        [SuggestedType.SByte] = "sbyte"
    };

    private readonly FormState _formState = new();

    public MainForm()
    {
        this.InitializeComponent();
        this.ApplyInitialColors();
        this.ApplyFormState(this._formState);

        this._formState.MainFormStateChanged += this.FormStateChanged;
    }

    private void FormStateChanged(object? sender, EventArgs e)
    {
        if (sender is not FormState formState)
        {
            return;
        }

        this.ApplyFormState(formState);
    }

    private void ApplyInitialColors()
    {
        // Main Form
        this.BackColor = FormColors.FormBackground;

        // Labels
        this.MinValueLabel.ForeColor = FormColors.Label;
        this.MaxValueLabel.ForeColor = FormColors.Label;
        this.IntegralOnlyCheckBox.ForeColor = FormColors.Label;
        this.MustBePreciseCheckBox.ForeColor = FormColors.Label;
        this.SuggestedTypeLabel.ForeColor = FormColors.Label;
        this.SuggestedTypeValueLabel.ForeColor = FormColors.Label;

        // TextBoxes
        // will be applied by this.ApplyMainFormState()
    }

    private void ApplyFormState(FormState formState)
    {
        // Min value
        this.MinValueTextBox.Text = formState.MinValue;
        this.MinValueTextBox.ForeColor = formState.IsMinValueParsable
            ? FormColors.TextBoxTextNormal
            : FormColors.TextBoxTextDanger;
        this.MinValueTextBox.BackColor = formState.IsMinValueParsable
            ? FormColors.TextBoxBackgroundNormal
            : FormColors.TextBoxBackgroundDanger;

        // Max value
        this.MaxValueTextBox.Text = formState.MaxValue;
        this.MaxValueTextBox.ForeColor = formState.IsMaxValueParsable
            ? FormColors.TextBoxTextNormal
            : FormColors.TextBoxTextDanger;
        this.MaxValueTextBox.BackColor = formState.IsMaxValueParsable
            ? FormColors.TextBoxBackgroundNormal
            : FormColors.TextBoxBackgroundDanger;

        // Integral only
        this.IntegralOnlyCheckBox.Checked = formState.IsIntegral;

        // Must be precise
        this.MustBePreciseCheckBox.Checked = formState.IsPrecise;
        this.MustBePreciseCheckBox.Visible = !formState.IsIntegral;

        // Suggested type
        SuggestedType suggestedType = NumericTypeSuggester.DeriveSuggestedType(formState);
        this.SuggestedTypeValueLabel.Text = MainForm.s_suggestedTypeMapping[suggestedType];
    }

    private void MinValueTextBox_TextChanged(object sender, EventArgs e)
    {
        if (sender is not TextBox textBox)
        {
            throw new Exception();
        }

        this._formState.MinValue = textBox.Text;
    }

    private void MaxValueTextBox_TextChanged(object sender, EventArgs e)
    {
        if (sender is not TextBox textBox)
        {
            throw new Exception();
        }

        this._formState.MaxValue = textBox.Text;
    }

    private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is not CheckBox checkBox)
        {
            throw new Exception();
        }

        this._formState.IsIntegral = checkBox.Checked;
    }

    private void MustBePreciseCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is not CheckBox checkBox)
        {
            throw new Exception();
        }

        this._formState.IsPrecise = checkBox.Checked;
    }
}