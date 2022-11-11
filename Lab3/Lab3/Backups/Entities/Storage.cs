using Backups.Algorithms;

namespace Backups.Entities;

public class Storage
{
    public Storage(string storageName, string storagePath)
    {
        StorageName = storageName;
        StoragePath = storagePath;
    }

    public string StorageName { get; }
    public string StoragePath { get; }
}