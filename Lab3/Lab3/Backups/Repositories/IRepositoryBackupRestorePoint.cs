using Backups.Entities;

namespace Backups.Repositories;

public interface IRepositoryBackupRestorePoint
{
    List<Storage> InitStorage(BackupTask backupTask);
    List<Backup> GetAllBackups();
    List<Backup> GetBackupsByName(string name);
}