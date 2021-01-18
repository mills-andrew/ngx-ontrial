namespace OnTrial.Desktop
{
    public interface ISessionService
    {
        public string Id { get; set; }

        #region Public Method(s)

        public void NewSession();
        public void DeleteSession();

        #endregion
    }
}
