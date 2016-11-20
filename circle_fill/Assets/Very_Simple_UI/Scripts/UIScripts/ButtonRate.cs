using UnityEngine;
using System.Collections;

#if AADOTWEEN
namespace AppAdvisory.UI
{
	/// <summary>
	/// Attached to rate button
	/// </summary>
	public class ButtonRate : MonoBehaviour 
	{
				/// <summary>
		/// If player clicks on the rate button, we call this method.
		/// </summary>
		public void OnClickedRate()
		{
			Application.OpenURL(FindObjectOfType<UIController>().URL_STORE);
		}
	}
}
#endif