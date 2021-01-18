namespace OnTrial.TCM.Core
{
    public class TestStep
    {
        public string Description { get; set; }
        public string Expected { get; set; }
        public Attachment Attachment { get; set; }

        public TestStep(string pDesc) : this(pDesc, "") { }
        public TestStep(string pDesc, string pExpected)
        {
            Description = pDesc;
            Expected = pExpected;
        }
    }
}