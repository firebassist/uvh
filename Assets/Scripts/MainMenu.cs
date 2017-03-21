using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;


	public void NewGame()
	{
		//Application.LoadLevel (startLevel);
		SceneManager.LoadScene (startLevel);
		//Time.timeScale = 1f; //moves game and player again?
	}
	
	public void QuitGame()
	{
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
}
