namespace Logger;

using System;
using System.IO;

public class FileLogger : BaseLogger
{
    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; }

    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter stream = File.AppendText(FilePath);
        stream.Write(DateTime.Now.ToString() + " ");
        stream.Write(ClassName + " ");
        stream.Write(logLevel + ": ");
        stream.Write(message);
        stream.WriteLine();
        stream.Close();
    }
}