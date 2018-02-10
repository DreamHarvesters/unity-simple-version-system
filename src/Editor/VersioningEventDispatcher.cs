using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;

namespace DH.Versioning
{
    [InitializeOnLoad]
    public static class VersioningEventDispatcher
    {
        static VersioningEventDispatcher()
        {
            EditorApplication.playModeStateChanged += OnEditorApplicationPlayModeStateChanged;
            AssemblyReloadEvents.afterAssemblyReload += OnAssembliesReload;
        }
        
        private static void OnEditorApplicationPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
            {
                PlayVersionIncreaser playVersionIncreaser = new PlayVersionIncreaser();
                playVersionIncreaser.IncreaseVersion();
            }
        }

        private static void OnAssembliesReload()
        {
            RevisionIncreaser revisionVersionIncreaser = new RevisionIncreaser();
            revisionVersionIncreaser.IncreaseVersion();
        }
        
        [PostProcessBuild]
        private static void OnBuilt()
        {
            BuildVersionIncreaser buildVersionIncreaser = new BuildVersionIncreaser();
            buildVersionIncreaser.IncreaseVersion();
        }
    }
}