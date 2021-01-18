namespace OnTrial.Api
{
    public class EndPoint
    {
        public ApiMethod Method { get; private set; }
        public string Template { get; private set; }

        public EndPoint(ApiMethod pMethod, string pTemplate)
        {
            this.Method = pMethod;
            this.Template = pTemplate;
        }
    }
}
