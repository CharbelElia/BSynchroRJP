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
        public string GetTitle() => "BSynchro WebApi for customers bank accounts";
        /// <summary>
        /// swagger version
        /// </summary>
        public string GetVersion() => "v1.0";
        /// <summary>
        /// swagger description
        /// </summary>
        public string GetDescription() => ".NET 6.0 BSynchro WebApi";
        /// <summary>
        /// swagger endpoint name
        /// </summary>
        public string GetEndpointName() => "BSynchro WebApi v1.0";
    }
}