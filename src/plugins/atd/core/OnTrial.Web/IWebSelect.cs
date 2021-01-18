using System.Collections.Generic;

namespace OnTrial.Web
{
    public interface IWebSelect
    {
        public List<IWebElement> Options { get; }
        public IWebElement Element { get; }
        public void Select(string pValue);
    }
}
