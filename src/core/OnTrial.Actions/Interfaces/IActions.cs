using System.Collections.Generic;

namespace OnTrial.Actions
{
    public interface IActions
    {
        List<Dictionary<string, object>> Sequence { get; set; }
        Dictionary<string, object> ToDictionary();
    }
}
