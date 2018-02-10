using System;
using UnityEditor;
using UnityEngine;

namespace DH.Versioning
{
    
    public class PlayVersionIncreaser : IIncreaseVersion
    {
        public void IncreaseVersion()
        {
            VersionSystem system = VersionSystem.Instance;
            system.SetPlayVersion(system.Version.Play + 1);
        }
    }
}