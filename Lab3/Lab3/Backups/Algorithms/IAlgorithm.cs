using Backups.Entities;

namespace Backups.Algorithms;

public interface IAlgorithm
{
    Storage CreateStorage(BackupObject backupObject, int restorePointNumber, string backupTaskName);
}