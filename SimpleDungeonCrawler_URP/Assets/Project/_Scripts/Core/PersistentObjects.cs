// ######################################################################
// PersistentObjects - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using Project.Utility;
using UnityEngine;

namespace Project
{
	public class PersistentObjects : SingletonMonoBehaviour<PersistentObjects>
	{
		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSource AudioSource { get; private set; }
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public UI.FadePanelUI FadePanelUI { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Start()
		{
			if (AudioSource == null) { AudioSource = gameObject.AddComponent<AudioSource>(); }
		}
		#endregion
	}
}