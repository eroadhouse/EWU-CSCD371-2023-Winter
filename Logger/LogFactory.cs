using System;

namespace Logger;

public class LogFactory
{
    public string? FileLoggerPath { get; private set; }

    public void ConfigureFileLogger(string filePath)
    {
        FileLoggerPath = filePath;
    }

    public BaseLogger CreateLogger(string className)
    {
        switch (className)
        {
            case "FileLogger":
                if (FileLoggerPath is null) { return null!; }
                FileLogger fileLogger = new(filePath: FileLoggerPath)
                {ClassName = className};
                return fileLogger;
            default:
                throw new ArgumentException("Invalid class name in FileLogger");
        }
    }
}
