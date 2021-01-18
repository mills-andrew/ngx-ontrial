using System.Drawing;

namespace OnTrial.Desktop
{
    public interface IWindowService
    {
        public Size Size { get; set; }
        public Point Position { get; set; }

        public string Id();

        public void Close();
        public void GetWindowHandles();
        public void New();
        public void MaximizeWindow();
    }
}
