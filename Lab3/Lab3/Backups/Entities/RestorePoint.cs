namespace Backups.Entities;

public class RestorePoint
{
    private readonly List<Storage> _storagesInRestorePoint;
    public RestorePoint(DateTime dateOfCreation, IReadOnlyCollection<Storage> storages)
    {
        CreationDate = dateOfCreation;
        _storagesInRestorePoint = storages.ToList();
    }

    public DateTime CreationDate { get; }
    public IReadOnlyCollection<Storage> StoragesInRestorePoint => _storagesInRestorePoint;
}