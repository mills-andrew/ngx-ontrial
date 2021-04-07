using System.Collections.Generic;

namespace OnTrial.ADO
{
    public class TestCase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        List<TestStep> TestSteps { get; set; }
        List<Attachment> Attachments { get; set; }
    }
}