using System.Collections.Generic;

namespace OnTrial.Actions
{
    /// <summary>
    /// Input source state is used as a generic term to describe the state associated with each input source.
    /// </summary>
    public interface IDevice
    {
        public string Name { get; set; }
        public string Type { get; }
        public List<Dictionary<string, object>> Actions { get; set; }
    }
}
