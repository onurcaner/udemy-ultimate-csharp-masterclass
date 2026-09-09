namespace Section14_NumericTypesSuggester;

internal class FormState
{
    private readonly StringNumber _maxValue = new();
    private readonly StringNumber _minValue = new();

    public string MinValue
    {
        get => this._minValue.Value;
        set
        {
            this._minValue.Value = value;
            this.RaiseMainFormStateChanged();
        }
    }

    public string MaxValue
    {
        get => this._maxValue.Value;
        set
        {
            this._maxValue.Value = value;
            this.RaiseMainFormStateChanged();
        }
    }

    public bool IsIntegral
    {
        get;
        set
        {
            field = value;
            this.RaiseMainFormStateChanged();
        }
    } = true;

    public bool IsPrecise
    {
        get;
        set
        {
            field = value;
            this.RaiseMainFormStateChanged();
        }
    }

    public bool IsMinValueParsable => this._minValue.IsParsable;
    public bool IsMaxValueParsable => this._maxValue.IsParsable;
    public bool IsMaxValueGteMinValue => StringNumber.Compare(this._maxValue, this._minValue) >= 0;

    public event EventHandler? MainFormStateChanged;

    private void RaiseMainFormStateChanged()
    {
        this.MainFormStateChanged?.Invoke(this, EventArgs.Empty);
    }
}