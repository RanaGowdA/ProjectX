using MudBlazor;


namespace CustomerRelationshipManagement.Client.Utility
{
    public static class NotificationSnackbarService
    {



        /// <summary>
        ///
        /// </summary>
        /// <param name="TextToDisplay"></param>
        /// <param name="AlertSeverity"></param>
        public static void ShowColorAlerts(string TextToDisplay, Severity AlertSeverity, ISnackbar snackbarService)
        {
            snackbarService.Clear();
            snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            snackbarService.Add(TextToDisplay, AlertSeverity);
        }
    }
}
