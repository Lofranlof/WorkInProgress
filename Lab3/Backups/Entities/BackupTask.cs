using System.Collections.ObjectModel;
using Backups.Algorithms;
using Backups.Exceptions;
using Backups.Repositories;

namespace Backups.Entities;

public class BackupTask
{
    private readonly List<BackupObject> _backupObjects;

    public BackupTask(Backup backup, BackupConfiguration backupConfig, string name)
    {
        BackupConfig = backupConfig;
        Backup = backup;
        NameOfBackupTask = name;
        _backupObjects = backupConfig.BackupObjects.ToList();
    }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;
    public BackupConfiguration BackupConfig { get; }
    public string NameOfBackupTask { get; }
    public Backup Backup { get; }

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

    public void CreateRestorePoint()
    {
        List<Storage> 
    }

    public void CreateBackup()
    {
        Backup backup = new Backup();
    }
}