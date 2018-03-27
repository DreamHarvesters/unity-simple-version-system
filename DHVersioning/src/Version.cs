using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

namespace DH.Versioning
{
    [CreateAssetMenu(fileName = "Version", menuName = "DH/Versioning/Create Version File", order = 0)]
    public class Version : ScriptableObject
    {
        public const string Path = "Assets/Resources/Version.asset";
        public const string FileLabel = "versionFile";

        public static Version LoadFromDefaultPath()
        {
            return Resources.Load<Version>(Utils.GetFileName(Path, "asset"));
        }

        [SerializeField] private int major;
        [SerializeField] private int minor;
        [SerializeField] private int build;
        [SerializeField] private int revision;
        [SerializeField] private int play;

        public int Major
        {
            get { return major; }
            set { major = value; }
        }

        public int Minor
        {
            get { return minor; }
            set { minor = value; }
        }

        public int Build
        {
            get { return build; }
            set { build = value; }
        }

        public int Revision
        {
            get { return revision; }
            set { revision = value; }
        }

        public int Play
        {
            get { return play; }
            set { play = value; }
        }

        public string FullVersion
        {
            get { return string.Format("{0}.{1}.{2}.{3}.{4}", major, minor, build, revision, play); }
        }

        public string MajorMinorBuildVersion
        {
            get { return string.Format("{0}.{1}.{2}", major, minor, build); }
        }

        public string MajorMinorVersion
        {
            get { return string.Format("{0}.{1}", major, minor); }
        }

        public void ResetRevisionBuildPlayVersions()
        {
            build = 0;
            revision = 0;
            play = 0;
        }
    }
}