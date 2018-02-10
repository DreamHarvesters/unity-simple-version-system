using System;
using UnityEditor;
using UnityEngine;

namespace DH.Versioning
{
    public class RevisionIncreaser : AssetPostprocessor, IIncreaseVersion
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            RevisionIncreaser revisionVersionIncreaser = new RevisionIncreaser();
            revisionVersionIncreaser.IncreaseVersion();
        }
        
        public void IncreaseVersion()
        {
            VersionSystem system = VersionSystem.Instance;
            system.SetRevisionVersion(system.Version.Revision + 1);
        }
    }
}