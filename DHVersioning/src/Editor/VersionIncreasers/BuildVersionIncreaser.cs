using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Callbacks;
using UnityEngine;

namespace DH.Versioning
{
    public class BuildVersionIncreaser : IIncreaseVersion, IPreprocessBuild
    {
        public int callbackOrder
        {
            get { return 0; }
        }

        public void OnPreprocessBuild(BuildTarget target, string path)
        {
            VersionSystem system = VersionSystem.Instance;
            system.SetBuildVersion(system.Version.Build + 1);
        }

        public void IncreaseVersion()
        {
            VersionSystem system = VersionSystem.Instance;
            system.SetBuildVersion(system.Version.Build + 1);
        }
    }
}