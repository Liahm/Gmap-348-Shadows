using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour 
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "NextLevel";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	
//---------------------------------------------------------------------MONO METHODS:

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

//--------------------------------------------------------------------------METHODS:

//--------------------------------------------------------------------------HELPERS:
	
}