using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FbScript : MonoBehaviour {

	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;

	void Awake()
	{
		if (FB.IsInitialized) {
			FB.Init (() => {
				if (FB.IsInitialized)
					FB.ActivateApp ();
				else
					Debug.LogError ("Could not initialize FB");
			},
				isGameShown => {
					if (!isGameShown)
						Time.timeScale = 0;
					else
						Time.timeScale = 1;
				});
		} else
			FB.ActivateApp ();
		}

	#region Login/Logout

	public void FBlogin()
	{

		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		permissions.Add ("email");
		permissions.Add ("user_friends");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}
		

	#endregion

	void AuthCallBack (IResult result)
	{

		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
			} else {
				Debug.Log ("FB is not logged in");
			}

		}
	}

	void SetInit()
		{

		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
		}
	}

	void OnHideUnity(bool isGameShown)
	{

		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	#region Inviting

	public void FBGameRequest(){
		FB.AppRequest ("Come and play ", title:"Quiz");
	}

	public void FBAppInvites()
	{
		FB.Mobile.AppInvite (new System.Uri (""));
	}

	#endregion

}





