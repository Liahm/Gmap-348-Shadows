using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "MainMenu";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	
//---------------------------------------------------------------------MONO METHODS:

//--------------------------------------------------------------------------METHODS:

	public void StartGame()
	{
		if(SceneManager.GetActiveScene().name == "End")
		{
			SceneManager.LoadScene("Tutorial 1");	
		}
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);		
	}

	public void Quit()
	{
		Application.Quit();
	}

//--------------------------------------------------------------------------HELPERS:
	
}