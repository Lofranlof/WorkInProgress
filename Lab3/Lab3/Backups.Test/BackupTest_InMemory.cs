using Backups.Algorithms;
using Backups.Entities;
using Backups.Repositories;

namespace Backups.Test;
using Xunit;
public class BackupTest_InMemory
{
    [Fact]
    public void Test1()
    {
        BackupConfiguration myBackupConfig = new BackupConfiguration(
            new SplitStorageAlgorithm(),
            new InMemoryRepositoryRestorePoint(new List<Backup>()),
            new InMemoryRepositoryBackupObject(new List<BackupObject>()));
        BackupTask myBackup = new BackupTask(myBackupConfig, "Test");

        BackupObject myObject1 = new BackupObject("Hello", "DiskC");
        BackupObject myObject2 = new BackupObject("Bye", "DiskD");
        myBackup.AddBackupObject(myObject1);
        myBackup.AddBackupObject(myObject2);

        myBackup.RunBackupTask();

        myBackup.RemoveBackupObject(myObject1);

        myBackup.RunBackupTask();

        List<RestorePoint> restorePoints = myBackup.Backup.RestorePointsCollection.ToList();

        Assert.True(restorePoints.Count == 2);
        Assert.True(restorePoints[0].StoragesInRestorePoint.Count == 2);
        Assert.True(restorePoints[1].StoragesInRestorePoint.Count == 1);
    }
}