using System.Collections.ObjectModel;
using Backups.Algorithms;
using Backups.Exceptions;
using Backups.Repositories;

namespace Backups.Entities;

public interface IBackupConfiguration
{
    void SetStorageAlgorithm(IAlgorithm algorithm);

    void SetBackupObjectRepository(IRepositoryBackupObject backupObjectRep);

    void SetRestorePointRepository(IRepositoryBackupRestorePoint restorePointRep);
}