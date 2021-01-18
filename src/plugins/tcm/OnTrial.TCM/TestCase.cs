using System.Collections.Generic;

namespace OnTrial.TCM.Core
{
    public class TestCase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        List<TestStep> TestSteps { get; set; }
        List<Attachment> Attachments { get; set; }
    }
}