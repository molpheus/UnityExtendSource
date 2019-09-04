using UnityEngine;
using UnityEditor;
using System.IO;

public class ProjectBaseTemplate : Editor
{
    static string ProjectName = "_";

    static string[] ProjectFolders = new string[] {
        "Animation",
        "Audio",
        //"Editor",
        "Font",
        "Image",
        "Logo",
        "Model",
        "Prefab",
        //"Resources",
        "Scenes",
        "Scripts",
        "Shader",
        "Splash Image",
        //"StreamingAssets",

    };

    static string[] UnityFolders = new string[] {
        "Editor",
        "Resources",
        "StreamingAssets",
    };
    static string[] UnityFolderOnce = new string[] {
        "Editor Default Resources",
        "Gizmos",
        "Plugins",
        "Standard Assets",
    };

    [MenuItem("ProjectBase/Create")]
    static private void Create()
    {
        string projectBase = Application.dataPath;
        foreach(string name in UnityFolderOnce) {
            CreateFolder(projectBase, name);
        }
        foreach (string name in UnityFolders) {
            CreateFolder(projectBase, name);
        }

        CreateFolder(projectBase, ProjectName);
        projectBase = Path.Combine(projectBase, ProjectName);
        foreach (string name in UnityFolders) {
            CreateFolder(projectBase, name);
        }
        foreach (string name in ProjectFolders) {
            CreateFolder(projectBase, name);
        }

        EditorUtility.DisplayDialog("完了", "処理が完了しました", "OK");
    }

    static private void CreateFolder(string root, string name)
    {
        string path = Path.Combine(root, name);
        if (Directory.Exists(root)) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            string filePath = path + "/.empty";
            Debug.Log("filePath " + filePath);
            if (!File.Exists(filePath)) {
                using(var f = File.Create(filePath))
                {
                    f.Close();
                }
            }
        }
    }
}

