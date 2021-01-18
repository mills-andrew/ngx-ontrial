using System.Collections.Generic;

namespace OnTrial.Web
{
    public interface IWebTable
    {
        public IWebElement Element { get; }
        public List<IWebElement> Headers { get; }
        public List<IWebElement> Rows { get; }
        public List<IWebElement> Cells { get; }

        public List<List<(string Key, string Value)>> Data();
    }
}
