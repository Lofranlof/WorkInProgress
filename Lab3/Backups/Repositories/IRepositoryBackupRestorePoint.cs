using Backups.Entities;

namespace Backups.Repositories;

public interface IRepositoryBackupRestorePoint
{
    BackupObject ReadAllBackups();
    BackupObject ReadBackupByName();
}