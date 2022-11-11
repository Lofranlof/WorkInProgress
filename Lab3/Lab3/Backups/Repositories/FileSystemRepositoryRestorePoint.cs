using System.IO.Compression;
using Backups.Entities;

namespace Backups.Repositories;

public class FileSystemRepositoryRestorePoint : IRepositoryBackupRestorePoint
{
    public List<Storage> InitStorage(BackupTask backupTask)
    {
        List<Storage> storages = new List<Storage>();
        foreach (BackupObject backupObject in backupTask.BackupObjects)
        {
            Storage storage = backupTask.BackupConfig.StorageAlgorithm.CreateStorage(backupObject, backupTask.Backup.RestorePointsCollection.Count, backupTask.NameOfBackupTask);
            ZipArchive newZip = ZipFile.Open(storage.StoragePath, File.Exists(storage.StoragePath) ? ZipArchiveMode.Update : ZipArchiveMode.Create);
            newZip.CreateEntryFromFile(backupObject.Path, backupObject.Name);
            newZip.Dispose();
            storages.Add(storage);
        }

        return storages;
    }

    public List<Backup> GetAllBackups()
    {
        throw new NotImplementedException();
    }

    public List<Backup> GetBackupsByName(string name)
    {
        throw new NotImplementedException();
    }
}