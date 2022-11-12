# Hitman

Kill the target when the contractor has been killed.

In another word:
- You have the contractor who is the application where our hitman will wait to be killed.
- And you have the target that will be killed as soon as the source application is killed.

## Download:  

Download the [Zip file](https://github.com/Tom60chat/Hitman/releases) and extract it somewhere.  

# Hot to use it:

Start `Hitman.exe [contractor_id] [target_id]` inside the extracted folder.  

Arguments:
 - contractor_id - The source app to wait for to be closed.
 - target_id - The taget app to close after the source is closed.

 You can implement inside your app with this function:
 ```cs
/// <summary>
/// Kill this process when the application has been killed
/// </summary>
public static bool RegisterForClossing(Process target)
{
    try
    {
        var targetId = target.Id;
        var contractorId = Environment.ProcessId;

        var hitman_folder_path = AppPath.GetFullPath($"Hitman");
        var hitman_folder = new DirectoryInfo(hitman_folder_path);

        if (!hitman_folder.Exists) return false;

        var hitman_subfolders = hitman_folder.GetDirectories();

        if (hitman_subfolders.Length == 0) return false;

        var hitman_files = hitman_subfolders[0].GetFiles("Hitman*");

        if (hitman_files.Length == 0) return false;

        var hitman_path = Path.GetFullPath(hitman_files[0].FullName);
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = hitman_path,
                Arguments = $"{contractorId} {targetId}",
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();

        return !process.HasExited;
    }
    catch
    {
        return false;
    }
}

public static class AppPath
{
    #region Methods
    /// <summary>
    /// Get the full path of a file inside the app directory
    /// </summary>
    /// <param name="fileName">Relative path</param>
    /// <returns>The full path</returns>
    public static string GetFullPath(string fileName)
    {
        fileName = fileName.Replace('\\', '/');
        fileName = fileName.TrimStart('/');

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = Path.Combine(baseDirectory, fileName);
        string path = Path.GetFullPath(relativePath);

        return path;
    }
    #endregion
}
 ```



 Under The Unlicense license.
