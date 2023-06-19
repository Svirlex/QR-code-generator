using UnityEngine;
using System.IO;

public class PermissionHandler : MonoBehaviour
{
    public string folderPath; // Specify the folder path you want to check permissions for

    private void Start()
    {
        CheckPermission();
    }

    private void CheckPermission()
    {
        if (HasWritePermission(folderPath))
        {
            // You have permission to access the folder
            Debug.Log("Permission granted");
        }
        else
        {
            // You don't have permission, request it
            RequestPermission(folderPath);
        }
    }

    private bool HasWritePermission(string path)
    {
        try
        {
            // Attempt to create a file in the specified folder
            using (FileStream fs = File.Create(Path.Combine(path, "permission_test.txt")))
            {
                // File creation succeeded, so delete it
                File.Delete(Path.Combine(path, "permission_test.txt"));
                return true;
            }
        }
        catch (System.UnauthorizedAccessException)
        {
            // Permission denied
            return false;
        }
        catch (IOException)
        {
            // Error occurred while checking permission
            return false;
        }
    }

    private void RequestPermission(string path)
    {
        string formattedPath = path.Replace("/", "\\"); // Use backslashes in Windows file paths

        // Open a file explorer window to the specified folder
        System.Diagnostics.Process.Start("explorer.exe", formattedPath);
    }
}
