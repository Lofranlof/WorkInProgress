using Backups.Entities;
using Backups.Exceptions;

namespace Backups.Repositories;

public class FileSystemRepositoryBackupObject : IRepositoryBackupObject
{
    private readonly List<BackupObject> _backupObjects;
    public FileSystemRepositoryBackupObject(string path, List<BackupObject> backupObjects)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new BackupExceptions("Invalid backup objects repository path");
        }

        PathToRep = path;
        _backupObjects = backupObjects;
    }

    public IReadOnlyCollection<BackupObject> BackupsObjects => _backupObjects;
    public string PathToRep { get; }
    public List<BackupObject> GetAllBackupObjects()
    {
        return BackupsObjects.ToList();
    }

    public List<BackupObject> GetBackupObjectsByName(string name)
    {
        return BackupsObjects.Where(backupObj => backupObj.Name == name).ToList();
    }
}