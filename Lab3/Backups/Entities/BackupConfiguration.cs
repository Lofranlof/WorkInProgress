using System.Collections.ObjectModel;
using Backups.Algorithms;
using Backups.Exceptions;
using Backups.Repositories;

namespace Backups.Entities;

public class BackupConfiguration : IBackupConfiguration
{
    private readonly IReadOnlyCollection<BackupObject> _backupObjects;

    public BackupConfiguration(IAlgorithm algorithm, IRepositoryBackupRestorePoint repositoryRestorePoint, IRepositoryBackupObject repositoryBackupObject, IReadOnlyCollection<BackupObject> backupObjects)
    {
        if (algorithm == null)
        {
            throw new BackupExceptions("Invalid storage algorithm");
        }

        if (repositoryBackupObject == null)
        {
            throw new BackupExceptions("Invalid backup object repository");
        }

        if (repositoryRestorePoint == null)
        {
            throw new BackupExceptions("Invalid restore point repository");
        }

        StorageAlgorithm = algorithm;
        BackupObjectRepository = repositoryBackupObject;
        RestorePointRepository = repositoryRestorePoint;
        _backupObjects = backupObjects;
    }

    public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects;
    public IAlgorithm StorageAlgorithm { get; private set; }
    public IRepositoryBackupObject BackupObjectRepository { get; private set; }
    public IRepositoryBackupRestorePoint RestorePointRepository { get; private set; }
    public void SetStorageAlgorithm(IAlgorithm algorithm)
    {
        if (algorithm == null)
        {
            throw new BackupExceptions("Invalid storage algorithm");
        }

        StorageAlgorithm = algorithm;
    }

    public void SetBackupObjectRepository(IRepositoryBackupObject backupObjectRep)
    {
        if (backupObjectRep == null)
        {
            throw new BackupExceptions("Invalid backup object repository");
        }

        BackupObjectRepository = backupObjectRep;
    }

    public void SetRestorePointRepository(IRepositoryBackupRestorePoint restorePointRep)
    {
        if (restorePointRep == null)
        {
            throw new BackupExceptions("Invalid restore point repository");
        }

        RestorePointRepository = restorePointRep;
    }
}