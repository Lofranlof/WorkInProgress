using Backups.Entities;
using Backups.Exceptions;
using Microsoft.VisualBasic.CompilerServices;

namespace Backups.Repositories;

public class InMemoryRepositoryRestorePoint : IRepositoryBackupRestorePoint
{
    private readonly List<Backup> _backups;

    public InMemoryRepositoryRestorePoint(List<Backup> backups)
    {
        _backups = backups;
    }

    public IReadOnlyCollection<Backup> Backups => _backups;

    public List<Storage> InitStorage(BackupTask backupTask)
    {
        if (backupTask == null)
        {
            throw new BackupExceptions("Invalid backup task info");
        }

        return backupTask.BackupObjects.Select(backupObj =>
            backupTask.BackupConfig.StorageAlgorithm.CreateStorage(backupObj, backupTask.Backup.RestorePointsCollection.Count, backupTask.NameOfBackupTask)).ToList();
    }

    public List<Backup> GetAllBackups()
    {
        return Backups.ToList();
    }

    public List<Backup> GetBackupsByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BackupExceptions("Invalid name of backup");
        }

        return Backups.Where(backup => backup.BackupTask.NameOfBackupTask == name).ToList();
    }
}