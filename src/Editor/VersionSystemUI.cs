using UnityEditor;
using UnityEngine;

namespace DH.Versioning
{
    public class VersionSystemUI : EditorWindow
    {
        [MenuItem("DH/Versioning")]
        static void Init()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(VersionSystemUI)) as VersionSystemUI;
            window.Show();
        }

        [SerializeField] private VersionSystem versionSystem;
        [SerializeField] private VersioningPreferences preferences;

        private void OnGUI()
        {
            DrawInitializeIfNot();
            
            DrawVersioningUI();
        }

        private void OnEnable()
        {
            if(versionSystem == null)
                InitSystem();
        }

        void DrawInitializeIfNot()
        {
            if (!VersionSystem.IsInitialized)
            {
                if(GUILayout.Button("Init Versioning System"))
                {
                    InitSystem();
                }
            }
        }

        void DrawVersioningUI()
        {
            if (VersionSystem.IsInitialized)
            {
                EditorGUILayout.LabelField("Revision version may cause conflicts in projects using using subversioning system.");
                preferences.AutomaticallyIncreaseRevisionBySave = GUILayout.Toggle(
                    preferences.AutomaticallyIncreaseRevisionBySave, "Automatically Increase Revision When Saved");
                
                EditorGUILayout.Space();
                preferences.AutomaticallyIncreaseBuild = GUILayout.Toggle(preferences.AutomaticallyIncreaseBuild,
                    "Automatically increase build version");
                
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Revision version may cause conflicts in projects using using subversioning system.");
                preferences.AutomaticallyIncreaseWithPlay = GUILayout.Toggle(preferences.AutomaticallyIncreaseWithPlay,
                    "Automatically increase play version");
                
                EditorGUILayout.Space();
                if(GUILayout.Button("Increment major version"))
                    versionSystem.SetMajorVersion(versionSystem.Version.Major + 1);
                
                EditorGUILayout.Space();
                if(GUILayout.Button("Increment minor version"))
                    versionSystem.SetMinorVersion(versionSystem.Version.Minor + 1);
                
                EditorGUILayout.Space();
                if(GUILayout.Button("Reset all versions"))
                    versionSystem.SetMajorVersion(0);
            }
        }

        void InitSystem()
        {
            versionSystem = new VersionSystem();
            preferences = versionSystem.Preferences;
        }
    }
}