using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShadows : MonoBehaviour 
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "SpawnShadows";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:

	public GameManager GM;
	public ShadowsClass[] SC;
	public bool x,z;

	[System.Serializable]
	public class ShadowsClass
	{
		public GameObject[] Shadows;
		public GameObject PlayerShadow, Light;
	}
	
	
	private GameObject player;
	private int lightVal;
//---------------------------------------------------------------------MONO METHODS:

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
		
	void Update()
    {
		lightVal = GM.LigthNumber;
		if(SC[lightVal].PlayerShadow != null)
		{
			if(SC[lightVal].PlayerShadow.activeSelf)
				blockMovement();
		}
    }

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			SC[lightVal].PlayerShadow.SetActive(true);
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			SC[lightVal].PlayerShadow.SetActive(false);
		}
	}

//--------------------------------------------------------------------------METHODS:
	public void SwitchState()
	{
		Debug.Log("lightval  "+ lightVal);
		foreach(ShadowsClass sc in SC)
		{
			foreach(GameObject shad in sc.Shadows) //Turn off all shadows in this class
				shad.SetActive(false);
			sc.Light.SetActive(false); //Turn off all other lights
			if(sc.PlayerShadow != null)
				sc.PlayerShadow.SetActive(false); //Turn off the player's shadow

			SC[lightVal].Light.SetActive(true);
			foreach(GameObject shad in SC[lightVal].Shadows) //Turn on all shadows in this class
			shad.SetActive(true);
			if(SC[lightVal].PlayerShadow != null)
				SC[lightVal].PlayerShadow.SetActive(true); //Turn on the player's shadow

		}
	}

//--------------------------------------------------------------------------HELPERS:
	///<Summary>
	///B;pcls the x,y or z direction of the shadow that spawns.
	///<Summary>
	private void blockMovement()
	{
		if(SC[lightVal].PlayerShadow != null)
		{
			if(x)
			{
				SC[lightVal].PlayerShadow.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
			}
			else if(z)
			{
				SC[lightVal].PlayerShadow.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
			}
		}
	}
	
}
