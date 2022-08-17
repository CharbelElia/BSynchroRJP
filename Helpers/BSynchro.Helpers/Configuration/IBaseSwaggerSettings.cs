namespace BSynchro.Helpers.Configuration
{
    public interface IBaseSwaggerSettings
    {
        public string GetTitle();
        public string GetVersion();
        public string GetDescription();
        public string GetEndpointName();
    }
}