using System.IO.Compression;
using Backups.Entities;
using Backups.Exceptions;

namespace Backups.Repositories;

public class FileSystemRepositoryRestorePoint : IRepositoryBackupRestorePoint
{
    private readonly List<Backup> _backups;

    public FileSystemRepositoryRestorePoint(string path, List<Backup> backups)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new BackupExceptions("Invlaid path of backups repository");
        }

        _backups = backups;
    }

    public IReadOnlyCollection<Backup> Backups => _backups;

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
        return Backups.ToList();
    }

    public List<Backup> GetBackupsByName(string name)
    {
        return Backups.Where(backup => backup.BackupName == name).ToList();
    }

    public void AddBackup(Backup backup)
    {
        if (backup == null)
        {
            throw new BackupExceptions("Invalid backup, backup can't be null");
        }

        _backups.Add(backup);
    }
}