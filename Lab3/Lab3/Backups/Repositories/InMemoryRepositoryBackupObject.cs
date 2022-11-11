using Backups.Entities;
using Backups.Exceptions;

namespace Backups.Repositories;

public class InMemoryRepositoryBackupObject : IRepositoryBackupObject
{
    private readonly List<BackupObject> _backupObjects;
    public InMemoryRepositoryBackupObject(List<BackupObject> backupObjects)
    {
        _backupObjects = backupObjects;
    }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;
    public List<BackupObject> GetAllBackupObjects()
    {
        return BackupObjects.ToList();
    }

    public List<BackupObject> GetBackupObjectsByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BackupExceptions("Invalid name of backup object");
        }

        return BackupObjects.Where(backupObj => backupObj.Name == name).ToList();
    }
}