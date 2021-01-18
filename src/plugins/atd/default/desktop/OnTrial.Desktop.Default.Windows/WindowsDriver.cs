namespace OnTrial.Desktop.Default.Windows
{
    public class WindowsDriver : DesktopDriver
    {
        public WindowsDriver(string pId, string pPath) : this(pId, pPath, new WindowsService()) { }
        public WindowsDriver(string pId, string pPath, WindowsService pService) : this(pId, new WindowsOptions(pPath), pService) { }
        public WindowsDriver(string pId, WindowsOptions pOptions) : this(pId, pOptions, new WindowsService()) { }
        public WindowsDriver(string pId, WindowsOptions pOptions, WindowsService pService) : base(pId, pOptions, pService) 
        { 
            base.Build(); 
        }
    }
}
