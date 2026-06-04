namespace ServerInfinite.Common;

internal sealed class DisclaimerDialogForm : Form
{
    private const int AutoCloseSeconds = 5;
    private const string Message =
        "免费程序，当心诈骗\r\n" +
        "Free software — beware of scams\r\n" +
        "若您已付费，请及时维权\r\n" +
        "If you have paid, please seek remedies promptly";

    private readonly Label _messageLabel;
    private readonly Button _okButton;
    private readonly System.Windows.Forms.Timer _closeTimer;
    private int _secondsRemaining = AutoCloseSeconds;

    public DisclaimerDialogForm()
    {
        Text = "Server-Infinite";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ControlBox = true;
        TopMost = true;
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

        const int clientWidth = 500;
        const int horizontalPadding = 20;
        const int topPadding = 16;
        const int gapBeforeButton = 18;
        const int bottomPadding = 16;
        const int buttonHeight = 36;
        const int textPadding = 4;

        var textWidth = clientWidth - horizontalPadding * 2;
        var messageFont = new Font("Microsoft YaHei Bold UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        var measuredTextHeight = TextRenderer.MeasureText(
            Message,
            messageFont,
            new Size(textWidth, int.MaxValue),
            TextFormatFlags.WordBreak).Height;
        var messageHeight = measuredTextHeight + textPadding;

        var buttonY = topPadding + messageHeight + gapBeforeButton;
        ClientSize = new Size(clientWidth, buttonY + buttonHeight + bottomPadding);

        _messageLabel = new Label
        {
            AutoSize = false,
            Text = Message,
            Location = new Point(horizontalPadding, topPadding),
            Size = new Size(textWidth, messageHeight),
            Font = messageFont,
        };
        _okButton = new Button
        {
            Size = new Size(130, buttonHeight),
            Location = new Point((ClientSize.Width - 130) / 2, buttonY),
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
            DialogResult = DialogResult.OK,
        };
        _okButton.Click += (_, _) => Close();

        _closeTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        _closeTimer.Tick += OnCloseTimerTick;

        Controls.Add(_messageLabel);
        Controls.Add(_okButton);
        AcceptButton = _okButton;

        Shown += OnShown;
        FormClosed += (_, _) => _closeTimer.Stop();
    }

    private void OnShown(object? sender, EventArgs e)
    {
        UpdateOkButtonText();
        _closeTimer.Start();
    }

    private void OnCloseTimerTick(object? sender, EventArgs e)
    {
        _secondsRemaining--;
        if (_secondsRemaining <= 0)
        {
            _closeTimer.Stop();
            Close();
            return;
        }

        UpdateOkButtonText();
    }

    private void UpdateOkButtonText() => _okButton.Text = $"确定 ({_secondsRemaining})";
}
