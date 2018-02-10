
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace DH.Versioning
{
    [Serializable]
    public class VersionSystem
    {
        public static bool IsInitialized
        {
            get { return AssetDatabase.FindAssets("l:" + Versioning.Version.FileLabel). Length > 0; }
        }

        public static VersionSystem Instance
        {
            get { return new VersionSystem();}
        }
        
        private VersioningPreferences preferences;
        private Version version;

        public VersionSystem()
        {
            LoadOrCreatePreferences();
            LoadOrCreateVersionAsset();
        }

        public VersioningPreferences Preferences
        {
            get { return preferences; }
        }

        public Version Version
        {
            get { return version; }
        }

        public void SetMajorVersion(int version)
        {
            SetMinorVersion(0);
            this.version.Major = version;

            Debug.Log(string.Format("Version update: {0}", this.version.FullVersion));
        }

        public void SetMinorVersion(int version)
        {
            this.version.ResetRevisionBuildPlayVersions();
            this.version.Minor = version;
            
            Debug.Log(string.Format("Version update: {0}", this.version.FullVersion));
        }

        public void SetBuildVersion(int version)
        {
            if (!preferences.AutomaticallyIncreaseBuild)
                return;
            
            this.version.Build = version;

            Debug.Log(string.Format("Version update: {0}", this.version.FullVersion));
        }

        public void SetRevisionVersion(int version)
        {
            if (!preferences.AutomaticallyIncreaseRevisionBySave)
                return;
            
            this.version.Revision = version;
            
            Debug.Log(string.Format("Version update: {0}", this.version.FullVersion));
        }
        
        public void SetPlayVersion(int version)
        {
            if (!preferences.AutomaticallyIncreaseWithPlay)
                return;
            
            this.version.Play = version;
            
            Debug.Log(string.Format("Version update: {0}", this.version.FullVersion));
        }

        private void LoadOrCreateVersionAsset()
        {
            version = AssetDatabase.LoadAssetAtPath<Version>(Version.Path);
            if (version == null)
            {
                string folder, parentPath; 
                Utils.GetFolderAndParentPath(Version.Path, out parentPath, out folder);
                if (!AssetDatabase.IsValidFolder(parentPath + "/" + folder))
                    AssetDatabase.CreateFolder(parentPath, folder);

                version = ScriptableObject.CreateInstance<Version>();
                AssetDatabase.CreateAsset(version, Version.Path);
                
                AssetDatabase.SetLabels(version, new []{Version.FileLabel});
            }
        }

        private void LoadOrCreatePreferences()
        {
            preferences = AssetDatabase.LoadAssetAtPath<VersioningPreferences>(VersioningPreferences.Path);
            if (preferences == null)
            {
                string folder, parentPath; 
                Utils.GetFolderAndParentPath(VersioningPreferences.Path, out parentPath, out folder);
                if (!AssetDatabase.IsValidFolder(parentPath + "/" + folder))
                    AssetDatabase.CreateFolder(parentPath, folder);

                preferences = ScriptableObject.CreateInstance<VersioningPreferences>();
                AssetDatabase.CreateAsset(preferences, VersioningPreferences.Path);
                
                AssetDatabase.SetLabels(preferences, new []{VersioningPreferences.FileLabel});
            }
        }
    }
}