// ######################################################################
// StatMeterUISetupHelper - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class StatMeterUISetupHelper : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private ImageData m_fillImageData = new ImageData();
		[SerializeField] private ImageData m_backgroundImageData = new ImageData();
		#endregion

		#region MonoBehaviour Callback Method(s):
#if UNITY_EDITOR
		private void OnValidate()
		{
			m_fillImageData.SetColor();
			m_backgroundImageData.SetColor();
		}
#endif
		private void Start() => Destroy(this);
		#endregion

		#region Support Class(es):
		[System.Serializable]
		public class ImageData
		{
			#region Inspector Assigned Field(s):
			[field: SerializeField] public Image Image;
			[field: SerializeField] public Color Color;
			#endregion

			#region Constructor(s):
			public ImageData() => Color = new Color(1f, 1f, 1f, 1f);
			#endregion

			#region Public API:
			public void SetColor()
			{
				if (Image == null) { return; }
				Image.color = Color;
			}
			#endregion
		}
		#endregion
	}
}
