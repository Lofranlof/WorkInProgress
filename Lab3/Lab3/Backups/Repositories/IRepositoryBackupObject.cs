using Backups.Entities;

namespace Backups.Repositories;

public interface IRepositoryBackupObject
{
    List<BackupObject> GetAllBackupObjects();
    List<BackupObject> GetBackupObjectsByName(string name);
}