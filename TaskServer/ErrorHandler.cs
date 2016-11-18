using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskServer
{
    public class ErrorHandler
    {
        Config _conf;
        public ErrorHandler(Config conf)
        {
            _conf = conf;
        }
    }
    //place for custom exceptions
    public class DBConnectorException : Exception
    {
        string _exceptionString;
        public DBConnectorException(string exceptionString)
        {
            _exceptionString = exceptionString;
        }
    }
    public class ConfigException : Exception
    {
        string _exceptionString;

        public ConfigException(string exceptionstring)
        {
            _exceptionString = exceptionstring;
        }
    }
}
