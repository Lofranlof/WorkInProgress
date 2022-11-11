using Backups.Entities;
using Backups.Exceptions;

namespace Backups.Algorithms;

public class SingleStorageAlgorithm : IAlgorithm
{
    public Storage CreateStorage(BackupObject backupObject, int restorePointNumber, string backupTaskName)
    {
        if (backupObject == null)
        {
            throw new BackupExceptions("invalid backup object");
        }

        if (restorePointNumber < 0)
        {
            throw new BackupExceptions("Invalid number of restore point");
        }

        if (string.IsNullOrWhiteSpace(backupTaskName))
        {
            throw new BackupExceptions("Invalid name of backup task");
        }

        string storageName = $"{backupObject.Name}_{restorePointNumber}";
        string storagePath = $"./{backupTaskName}/RestorePointNUmber_{restorePointNumber}.zip";
        Storage newStorage = new (storageName, storagePath);
        return newStorage;
    }
}