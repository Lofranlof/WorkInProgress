using Backups.Entities;

namespace Backups.Repositories;

public interface IRepositoryBackupRestorePoint
{
    List<Storage> InitStorage(BackupTask backupTask);
}