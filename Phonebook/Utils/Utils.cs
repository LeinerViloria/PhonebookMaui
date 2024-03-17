using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Phonebook.Utils
{
    public static class Utils
    {
        public static async Task ShowToast(string Message, double FontSize = 14, ToastDuration Duration = ToastDuration.Short)
        {
            CancellationTokenSource cancellationTokenSource = new ();

            var toast = Toast.Make(Message, Duration, FontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
