using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Web.Default
{
    public class WebTable : IWebTable
    {
        #region Public Properties

        public IWebElement Element => this.agent.FindElement(key, value);
        public List<IWebElement> Headers => agent.FindElements(Element, WebLocator.TagName, "th").ToList();
        public List<IWebElement> Rows => agent.FindElements(Element, WebLocator.TagName, "tr").ToList();
        public List<IWebElement> Cells => agent.FindElements(Element, WebLocator.TagName, "td").ToList();

        #endregion

        #region Private Properties

        private IWebAgent agent;
        private WebLocator key;
        private string value;

        #endregion

        #region Constructor(s)

        public WebTable(IWebAgent pAgent, WebLocator pKey, string pValue)
        {
            this.agent = pAgent;
            this.key = pKey;
            this.value = pValue;
        }

        #endregion

        public List<List<(string Key, string Value)>> Data()
        {
            List<List<(string Key, string Value)>> data = new List<List<(string Key, string Value)>>();
            List<IWebElement> headers = Headers;
            List<IWebElement> rows = Rows;

            for (int x = 1; x < rows.Count; x++)
            {
                var cellsInRow = agent.FindElements(rows[x], WebLocator.TagName, "td").ToList();
                List<(string Key, string Value)> rowData = new List<(string Key, string Value)>();
                for (int y = 0; y < headers.Count; y++)
                {
                    rowData.Add((headers[y].Text, cellsInRow[y].Text));
                }
                data.Add(rowData);
            }
            return data;
        }
    }
}
