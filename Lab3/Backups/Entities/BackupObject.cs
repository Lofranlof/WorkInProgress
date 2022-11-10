using Backups.Exceptions;

namespace Backups.Entities;

public class BackupObject
{
    public BackupObject(string name, string path)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(path))
        {
            throw new BackupExceptions("Name of backup object or path to backup object doesn't is invalid");
        }

        Name = name;
        Path = path;
    }

    public string Name { get; }
    public string Path { get; }
}