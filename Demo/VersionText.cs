using DH.Versioning;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{

	public Text TextComponent; 
	
	// Use this for initialization
	void Start ()
	{
		Version v = Version.LoadFromDefaultPath();
		TextComponent.text = string.Format("Version: {0}", v.FullVersion);
	}
}
