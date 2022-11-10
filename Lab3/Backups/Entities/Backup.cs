namespace Backups.Entities;

public class Backup
{
    private readonly List<RestorePoint> _restorePointCollection;

    public Backup(IReadOnlyCollection<RestorePoint> restorePoints, BackupTask backupTask)
    {
        _restorePointCollection = restorePoints.ToList();
        BackupTask = backupTask;
    }

    public IReadOnlyCollection<RestorePoint> RestorePointsCollection => _restorePointCollection;
    public BackupTask BackupTask { get; }
}