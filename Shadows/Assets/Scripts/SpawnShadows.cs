using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShadows : MonoBehaviour 
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "SpawnShadows";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:

	[System.Serializable]
	public class ShadowsClass
	{
		public GameObject[] Shadows;
		public Light Light;
		public GameObject PlayerShadow;
	}
	
	public ShadowsClass[] SC;
	
	private int lightVal = GameManager.GetInstance().LigthNumber;
//---------------------------------------------------------------------MONO METHODS:

	void Start() 
	{

	}
		
	void Update()
    {

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


//--------------------------------------------------------------------------HELPERS:

	
}
