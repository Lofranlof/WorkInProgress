using Backups.Entities;

namespace Backups.Repositories;

public class InMemoryRepositoryBackupObject : IRepositoryBackupObject
{
    public BackupObject ReadAllBackupObjects()
    {
        throw new NotImplementedException();
    }

    public BackupObject ReadBackupObjectByName()
    {
        throw new NotImplementedException();
    }
}