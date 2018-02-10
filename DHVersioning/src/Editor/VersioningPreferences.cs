using UnityEngine;

namespace DH.Versioning
{
//    [CreateAssetMenu(fileName = "VersioningPreferences", menuName = "DH/Versioning/Create Versioning Preferences", order = 0)]
    public class VersioningPreferences : ScriptableObject
    {
        public const string Path = "Assets/DHVersioning/src/Editor/VersioningPreferences.asset";
        public const string FileLabel = "VersioningPreferences";
        
        private bool automaticallyIncreaseRevisionBySave = true;
        private bool automaticallyIncreaseBuild = true;
        private bool automaticallyIncreaseWithPlay = true;

        public bool AutomaticallyIncreaseRevisionBySave
        {
            get { return automaticallyIncreaseRevisionBySave; }
            set { automaticallyIncreaseRevisionBySave = value; }
        }

        public bool AutomaticallyIncreaseBuild
        {
            get { return automaticallyIncreaseBuild; }
            set { automaticallyIncreaseBuild = value; }
        }

        public bool AutomaticallyIncreaseWithPlay
        {
            get { return automaticallyIncreaseWithPlay; }
            set { automaticallyIncreaseWithPlay = value; }
        }
    }
}