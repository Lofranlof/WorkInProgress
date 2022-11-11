namespace Backups.Entities;

public class RestorePoint
{
    private readonly List<BackupObject> _objectsAssociatedWithRestorePoint;
    private readonly List<Storage> _storagesInRestorePoint;
    public RestorePoint(DateTime dateOfCreation, IReadOnlyCollection<BackupObject> collectionOfObjects, IReadOnlyCollection<Storage> storages)
    {
        CreationDate = dateOfCreation;
        _objectsAssociatedWithRestorePoint = collectionOfObjects.ToList();
        _storagesInRestorePoint = storages.ToList();
    }

    public DateTime CreationDate { get; }
    public IReadOnlyCollection<BackupObject> BackupObjects => _objectsAssociatedWithRestorePoint;
    public IReadOnlyCollection<Storage> StoragesInRestorePoint => _storagesInRestorePoint;
}