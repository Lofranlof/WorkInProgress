using Backups.Exceptions;

namespace Backups.Entities;

public class Backup
{
    private readonly List<RestorePoint> _restorePointCollection;

    public Backup(IReadOnlyCollection<RestorePoint> restorePoints, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BackupExceptions("Invalid name of backup");
        }

        BackupName = name;
        _restorePointCollection = restorePoints.ToList();
    }

    public IReadOnlyCollection<RestorePoint> RestorePointsCollection => _restorePointCollection;
    public string BackupName { get; }
    public void AddRestorePoint(RestorePoint newRestorePoint)
    {
        if (newRestorePoint == null)
        {
            throw new BackupExceptions("Restore point is invalid");
        }

        _restorePointCollection.Add(newRestorePoint);
    }
}