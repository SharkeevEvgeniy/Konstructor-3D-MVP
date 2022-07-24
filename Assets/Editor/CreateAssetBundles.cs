using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateAssetBundles
{

    public static string assetBundleDirectory = "Assets/AssetBundles/";

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {

        //if main directory doesnt exist create it
        if (Directory.Exists(assetBundleDirectory))
        {
            Directory.Delete(assetBundleDirectory, true);
        }

        Directory.CreateDirectory(assetBundleDirectory);

        //create bundles for all platform (use IOS for editor support on MAC but must be on IOS build platform)
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.iOS);
        AppendPlatformToFileName("IOS");
        Debug.Log("IOS bundle created...");

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
        AppendPlatformToFileName("Android");
        Debug.Log("Android bundle created...");

        RemoveSpacesInFileNames();

        AssetDatabase.Refresh();
        Debug.Log("Process complete!");
    }

    static void RemoveSpacesInFileNames()
    {
        foreach (string path in Directory.GetFiles(assetBundleDirectory))
        {
            string oldName = path;
            string newName = path.Replace(' ', '-');
            File.Move(oldName, newName);
        }
    }

    static void AppendPlatformToFileName(string platform)
    {
        foreach (string path in Directory.GetFiles(assetBundleDirectory))
        {
            string[] files = path.Split('/');
            string fileName = files[files.Length - 1];
            if (fileName.Contains(".") || fileName.Contains("Bundle"))
            {
                File.Delete(path);
            }
            else if (!fileName.Contains("-"))
            {
                FileInfo info = new FileInfo(path);
                info.MoveTo(path + "-" + platform);
            }
        }
    }

    static void AppendPlatformToFileName_Test(string platform)
    {
        platform = "Android";
        var expectedPath = @"Resources\AppBundles\Model-Android";

        foreach (string path in Directory.GetFiles(assetBundleDirectory))
        {
            string[] files = path.Split('/');
            string fileName = files[files.Length - 1];
            if (fileName.Contains(".") || fileName.Contains("Bundle"))
            {
                File.Delete(path);
            }
            else if (!fileName.Contains("-"))
            {
                FileInfo info = new FileInfo(path);
                info.MoveTo(path + "-" + platform);
                if(info.Name == expectedPath)
                {
                    Debug.LogWarning("The test is passed");
                }
                else
                {
                    Debug.LogWarning("The test wasn't passed");
                }
            }
        }
    }
}
