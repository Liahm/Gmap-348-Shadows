using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			coll.GetComponentInParent<PlayerController>().Restart();
		}
	}
}
