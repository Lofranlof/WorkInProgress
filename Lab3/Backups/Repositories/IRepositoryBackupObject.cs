using Backups.Entities;

namespace Backups.Repositories;

public interface IRepositoryBackupObject
{
    BackupObject ReadAllBackupObjects();
    BackupObject ReadBackupObjectByName();
}