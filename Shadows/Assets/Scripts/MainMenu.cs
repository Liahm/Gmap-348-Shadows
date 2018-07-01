﻿using System.Collections;
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);		
	}

	public void Quit()
	{
		Application.Quit();
	}

//--------------------------------------------------------------------------HELPERS:
	
}