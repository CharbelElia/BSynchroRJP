using System;

namespace BSynchro.Helpers.Exceptions
{
    public class BSynchroBaseException : Exception
    {
        public string Code { get; set; }
        public BSynchroBaseException(string code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
