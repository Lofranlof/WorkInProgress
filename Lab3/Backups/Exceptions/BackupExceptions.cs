namespace Backups.Exceptions;

public class BackupExceptions : Exception
{
    public BackupExceptions() { }

    public BackupExceptions(string message)
        : base(message) { }
}