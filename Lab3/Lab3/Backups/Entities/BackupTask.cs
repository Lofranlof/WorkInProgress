using System.Collections.ObjectModel;
using Backups.Algorithms;
using Backups.Exceptions;
using Backups.Repositories;

namespace Backups.Entities;

public class BackupTask
{
    private readonly List<BackupObject> _backupObjects;

    public BackupTask(BackupConfiguration backupConfig, string name)
    {
        BackupConfig = backupConfig;
        NameOfBackupTask = name;
        _backupObjects = new List<BackupObject>();
        Backup = CreateBackup();
    }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;
    public BackupConfiguration BackupConfig { get; }
    public Backup Backup { get; private set; }
    public string NameOfBackupTask { get; }
    public void AddBackupObject(BackupObject backupObject)
    {
        if (backupObject == null)
        {
            throw new BackupExceptions("Invalid backup object");
        }

        if (BackupObjects.Contains(backupObject))
        {
            throw new BackupExceptions("This backupObject is already in the backup task");
        }

        _backupObjects.Add(backupObject);
    }

    public void RemoveBackupObject(BackupObject backupObject)
    {
        if (backupObject == null)
        {
            throw new BackupExceptions("Invalid backupObject");
        }

        if (!BackupObjects.Contains(backupObject))
        {
            throw new BackupExceptions("No such backup object in backup task");
        }

        _backupObjects.Remove(backupObject);
    }

    public Backup CreateBackup()
    {
        Backup backup = new Backup(new List<RestorePoint>(), NameOfBackupTask);
        Backup = backup;
        return backup;
    }

    public void RunBackupTask()
    {
        List<Storage> storages = BackupConfig.RestorePointRepository.InitStorage(this);
        RestorePoint restorePoint = new RestorePoint(DateTime.Now, storages);
        Backup.AddRestorePoint(restorePoint);
    }
}