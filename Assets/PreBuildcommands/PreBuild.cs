#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PreBuild : IPreprocessBuildWithReport
{
    public int callbackOrder =>  0;

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool overrideFiles)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, overrideFiles);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs, overrideFiles);
            }
        }
    }

    public void OnPreprocessBuild(BuildReport report)
    {
        var sourceDir = $@"{Directory.GetCurrentDirectory()}\Packages";
        var targetDir = $@"{Directory.GetCurrentDirectory()}\Assets\Assemblies";
        
        Debug.Log($"Copying VS packages from {sourceDir} to Unity Assemblies {targetDir}");

        DirectoryCopy(sourceDir, targetDir , true, true);
    }
}
#endif
