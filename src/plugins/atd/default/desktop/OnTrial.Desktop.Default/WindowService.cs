using System.Collections.Generic;
using System.Drawing;

namespace OnTrial.Desktop.Default
{
    public class WindowService : IWindowService
    {
        protected DesktopDriver mDriver;

        public WindowService(DesktopDriver pAgent)
        {
            this.mDriver = pAgent;
        }

        public Size Size { get; set; }
        public Point Position { get; set; }

        public string Id() => mDriver.ExecuteEndPoint(DesktopCommand.GetWindowHandle)["value"].ToString();

        public void Close()
        {
            mDriver.ExecuteEndPoint(DesktopCommand.CloseWindow);
        }

        public void GetWindowHandles()
        {
            mDriver.ExecuteEndPoint(DesktopCommand.GetWindowHandles);
        }

        public void New()
        {
            mDriver.ExecuteEndPoint(DesktopCommand.NewWindow, new Dictionary<string, object>()
            {
                { "type", "window" }
            });
        }

        public void MaximizeWindow()
        {
            mDriver.ExecuteEndPoint(DesktopCommand.MaximizeWindow);
        }
    }
}
