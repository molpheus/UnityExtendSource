using UnityEngine;
using System.IO;

using UnityEditor;

#if UNITY_EDITOR
namespace com.molmolgames.U_Ex
{
    /// <summary>
    /// project templeate create script
    /// </summary>
    public class ProjectBaseTemplate : Editor
    {
        /// <summary> create project name </summary>
        static string ProjectName = "_";

        /// <summary> create project folders </summary>
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

        /// <summary> Special folder names </summary>
        static string[] UnityFolders = new string[] {
            "Editor",
            "Resources",
            "StreamingAssets",
        };

        /// <summary> Special folder names as Just once create </summary>
        static string[] UnityFolderOnce = new string[] {
            "Editor Default Resources",
            "Gizmos",
            "Plugins",
            "Standard Assets",
        };

        [MenuItem ("Assets/molmolgames/ProjectBase/Create")]
        static private void Create ()
        {
            var w = EditorWindow.GetWindow<InputConfirmWindow>(true);
            w.Setup (text => {
                if (text == null) {
                    EditorUtility.DisplayDialog ("CANSEL", "Processing interrupted", "OK");
                    return;
                }

                ProjectName = text;

                string projectBase = Application.dataPath;
                foreach ( string name in UnityFolderOnce ) {
                    CreateFolder (projectBase, name);
                }
                foreach ( string name in UnityFolders ) {
                    CreateFolder (projectBase, name);
                }

                CreateFolder (projectBase, ProjectName);
                projectBase = Path.Combine (projectBase, ProjectName);
                foreach ( string name in UnityFolders ) {
                    CreateFolder (projectBase, name);
                }
                foreach ( string name in ProjectFolders ) {
                    CreateFolder (projectBase, name);
                }

                EditorUtility.DisplayDialog ("SUCCESS", "Processing completed", "OK");
            });
        }

        static private void CreateFolder (string root, string name)
        {
            string path = Path.Combine(root, name);
            if ( Directory.Exists (root) ) {
                if ( !Directory.Exists (path) ) {
                    Directory.CreateDirectory (path);
                }
                string filePath = path + "/cvs.tmp";
                Debug.Log ("filePath " + filePath);
                if ( !File.Exists (filePath) ) {
                    using ( var f = File.Create (filePath) ) {
                        f.Close ();
                    }
                }
            }
        }
    }

    public class InputConfirmWindow : EditorWindow
    {
        /// <summary> callback action </summary>
        private System.Action<string> _callback;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"> confirm action </param>
        public void Setup(System.Action<string> callback)
        {
            _callback = callback;
        }

        private string _input = "";
        private bool _isInit = false;

        private void OnGUI ()
        {
            GUILayout.Label ("project folder name");
            GUILayout.Space (10f);
            GUI.SetNextControlName ("ForcusField");
            _input = GUILayout.TextField (_input);

            //
            EditorGUI.BeginDisabledGroup (string.IsNullOrEmpty (_input));
            GUILayout.BeginHorizontal ();
            if (GUILayout.Button("OK", GUILayout.Height (30f)) ) {
                _callback (_input);
                Close ();
            }
            EditorGUI.EndDisabledGroup ();
            if (GUILayout.Button("CLOSE", GUILayout.Height(30f))) {
                _callback (null);
                Close ();
            }
            GUILayout.EndHorizontal ();

            if (_isInit == false) {
                EditorGUI.FocusTextInControl ("ForcusField");
            }
            _isInit = true;
        }
    }
}
#endif