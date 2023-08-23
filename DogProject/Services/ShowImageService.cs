using System.Runtime.InteropServices;

namespace DogProject.Services;

public class ShowImageService : IShowImageService
{
    public void Show(string imagePath)
    {
        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        IntPtr result = ShellExecute(IntPtr.Zero, "open", imagePath, null, null, 1);
    }
}
