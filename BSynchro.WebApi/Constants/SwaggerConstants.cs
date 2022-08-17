using BSynchro.Helpers.Configuration;

namespace BSynchro.WebApi.Constants
{
    /// <summary>
    /// Contains all swagger related constants
    /// </summary>
    public class SwaggerConstants: IBaseSwaggerSettings
    {
        /// <summary>
        /// swagger title
        /// </summary>
        public string GetTitle() => "BSynchro WebApi New";
        /// <summary>
        /// swagger version
        /// </summary>
        public string GetVersion() => "v1.0";
        /// <summary>
        /// swagger description
        /// </summary>
        public string GetDescription() => "Dotnet core 6 BSynchro WebApi New";
        /// <summary>
        /// swagger endpoint name
        /// </summary>
        public string GetEndpointName() => "BSynchro WebApi New v1.0";
    }
}