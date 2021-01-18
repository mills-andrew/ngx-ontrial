using OnTrial.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnTrial.Desktop.Default.Windows
{
    public class WindowsProtocol : ProtocolService
    {
        public WindowsProtocol()
        {
            base.BuildW3CProtocol();
        }
    }
}
