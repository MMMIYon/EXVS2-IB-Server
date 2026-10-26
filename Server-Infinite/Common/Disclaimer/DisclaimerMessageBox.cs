namespace ServerInfinite.Common;

/// <summary>
/// Shows a bilingual disclaimer on Windows at startup; auto-closes after a short delay.
/// Runs on a background STA thread and does not block application startup.
/// </summary>
internal static class DisclaimerMessageBox
{
    public static void Start()
    {
        // 1.1.3: the startup disclaimer dialog is disabled (Start() does nothing).
        // Original behaviour kept below for reference:
        //
        // if (!OperatingSystem.IsWindows())
        //     return;
        //
        // var thread = new Thread(ShowDialog)
        // {
        //     IsBackground = true,
        // };
        // thread.SetApartmentState(ApartmentState.STA);
        // thread.Start();
    }

    private static void ShowDialog()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using var form = new DisclaimerDialogForm();
        form.ShowDialog();
    }
}
