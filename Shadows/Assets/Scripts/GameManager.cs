using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour 
{
//------------------------------------------------------------------------CONSTANTS:
	public static GameManager Instance;
	private const string LOG_TAG = "GameManager";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	public PlayerController PC;
	public int LigthNumber, MaxLights;
	public Axes.Action Interact;

	private bool x;
	private SpawnShadows[] SS;

//---------------------------------------------------------------------MONO METHODS:

	void Start() 
	{
		if (Instance == null)
        {
            Instance = this;	
            //DontDestroyOnLoad(this.gameObject); /* Set the GameManager to persist through scene loading */
        }
		else
        {
            Destroy(this.gameObject);
        }

		if(SceneManager.GetActiveScene().name == "Main Menu")
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		x = false;

		SS = GameObject.FindObjectsOfType<SpawnShadows>();
	}
		
	void Update()
    {
		if(Input.GetKeyUp(KeyCode.R))
		{
			PC.Restart();
		}
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if(!x)	
			{
				Cursor.lockState = CursorLockMode.None;
				x = true;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
				x = false;
			}
		}
		if(Input.GetButtonDown(Axes.toStr[Interact]))
		{
			SwitchLights();
			foreach(SpawnShadows ss in SS)
			{
				ss.SwitchState();
			}
		}
    }

//--------------------------------------------------------------------------METHODS:

//--------------------------------------------------------------------------HELPERS:
	private void SwitchLights()
	{
		if(LigthNumber == MaxLights - 1	)
		{
			LigthNumber = 0;
		}
		else
		{
			LigthNumber++;	
		}
	}
}