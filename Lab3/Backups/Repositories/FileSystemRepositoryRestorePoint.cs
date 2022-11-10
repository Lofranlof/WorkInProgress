using Backups.Entities;

namespace Backups.Repositories;

public class FileSystemRepositoryRestorePoint : IRepositoryBackupRestorePoint
{
    public BackupObject ReadAllBackups()
    {
        throw new NotImplementedException();
    }

    public BackupObject ReadBackupByName()
    {
        throw new NotImplementedException();
    }
}