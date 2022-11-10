using Backups.Entities;
using Backups.Exceptions;

namespace Backups.Repositories;

public class FileSystemRepositoryBackupObject : IRepositoryBackupObject
{
    public FileSystemRepositoryBackupObject(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new BackupExceptions("Invalid backup objects repository path");
        }

        PathToRep = path;
    }

    public string PathToRep { get; }
    public BackupObject ReadAllBackupObjects()
    {
        throw new NotImplementedException();
    }

    public BackupObject ReadBackupObjectByName()
    {
        throw new NotImplementedException();
    }
}