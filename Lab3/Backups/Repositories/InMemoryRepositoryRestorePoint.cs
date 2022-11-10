using Backups.Entities;

namespace Backups.Repositories;

public class InMemoryRepositoryRestorePoint : IRepositoryBackupRestorePoint
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