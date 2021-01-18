using System.Drawing;

namespace OnTrial.Desktop
{
    public interface IDesktopElement
    {
        public static string KeyId = "ELEMENT";

        public string Id { get; set; }
        public string IsActive { get; }
        public bool IsSelected { get; }
        public string Text { get; }

        public string TagName { get; }
        public Size Size { get; }
        public Point Location { get; }
        public bool IsEnabled { get; }
        public Rectangle Rect { get; }
        public void Clear();
        public void Click();

        public string GetAttribute(string pValue);
        public string GetCssValue(string pValue);
        public string GetProperty(string pValue);
        public void SendKeys(string pText);
    }
}
