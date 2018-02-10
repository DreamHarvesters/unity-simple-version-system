using UnityEditor.Callbacks;
using UnityEngine;

namespace DH.Versioning
{
    public class BuildVersionIncreaser : IIncreaseVersion
    {
        public void IncreaseVersion()
        {
            VersionSystem system = VersionSystem.Instance;
            system.SetBuildVersion(system.Version.Build + 1);
        }
    }
}