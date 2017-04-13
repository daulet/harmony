using System;

namespace Logger
{
    public interface ILogger
    {
        void Error(string message);

        void Info(string message);

        void Verbose(string message);

        void Warning(string message);
    }
}
