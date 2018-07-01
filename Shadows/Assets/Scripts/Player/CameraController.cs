using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class CameraController : MonoBehaviour
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "CameraController";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;
	public Axes.Action camX,camY;
	public bool reverse;
 
	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis
//---------------------------------------------------------------------MONO METHODS:
	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}
 
	void Update ()
	{
		float mouseX, mouseY;
		if(reverse)
		{
			mouseX = Axes.GetAxis(camX);
			mouseY =  -Axes.GetAxis(camY);
		}
		else
		{
			mouseX = Axes.GetAxis(camX);
			mouseY =  Axes.GetAxis(camY);	
		}

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}


//--------------------------------------------------------------------------METHODS:

//--------------------------------------------------------------------------HELPERS:
	
}