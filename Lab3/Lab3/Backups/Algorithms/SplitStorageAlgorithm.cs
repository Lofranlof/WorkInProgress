using Backups.Entities;

namespace Backups.Algorithms;

public class SplitStorageAlgorithm : IAlgorithm
{
    public Storage CreateStorage(BackupObject backupObject, int restorePointNumber, string backupTaskName)
    {
        string storageName = $"{backupObject.Name}_{restorePointNumber}";
        string storagePath = $"./{backupTaskName}/RestorePointNumber_{restorePointNumber}/{storageName}.zip";
        Storage newStorage = new Storage(storageName, storagePath);
        return newStorage;
    }
}