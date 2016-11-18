using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskServer
{
    class Config
    {
        //private fields
        string _dbDatabaseName;
        string _dbAddress;
        string _dbUserName;
        string _commandsPath;
        string _workingDirectory;
        char _seperator = ';';

        
  
        //end private fields

        //getter setter for private fields
        public string DbAddress
        {
            get { return _dbAddress; }
            set { _dbAddress = value; }
        }
        public string DbUserName
        {
            get { return _dbUserName; }
            set { _dbUserName = value; }
        }
        public string DbDatabaseName
        {
            get { return _dbDatabaseName; }
            set { _dbDatabaseName = value; }
        }
        public string CommandsPath
        {
            get { return _workingDirectory+@"\"+_commandsPath; }
            set { _commandsPath = value; }
        }
        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; }
        }
        public char Seperator
        {
            get { return _seperator; }
            set { _seperator = value; }
        }
        //end getter setter
        public Config()
        {
            _dbAddress = "127.0.0.1";
            _dbDatabaseName = "taskUser";
            _dbUserName = "taskUser";
            _commandsPath = "commands.txt";
            _workingDirectory = Directory.GetCurrentDirectory();
        }
        
    }
}
