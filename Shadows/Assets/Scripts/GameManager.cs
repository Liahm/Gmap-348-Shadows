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
	public GameObject CanvasObject;

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
				CanvasObject.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				x = true;
			}
			else
			{
				CanvasObject.SetActive(false);
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

		if(Input.GetKeyDown(KeyCode.N))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else if(Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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