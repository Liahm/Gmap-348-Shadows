using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the use of controllers
/// <summary>
public class Axes : MonoBehaviour
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "Axes";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	public enum Action
	{
		MoveX, MoveY,
		CamX, CamY,
		Jump, Interact
		//Interact = change lights
	}
//---------------------------------------------------------------------MONO METHODS:

//--------------------------------------------------------------------------METHODS:
	public static Dictionary<Action, string> toStr = new Dictionary<Action, string>
	{
		{Action.MoveX, "Horizontal"},
		{Action.MoveY, "Vertical"},
		{Action.CamX, "Cam Horizontal"},
		{Action.CamY, "Cam Vertical"},
		{Action.Jump, "Jump"},
		{Action.Interact, "Interact"}
	};

	public static float GetAxis(Action a)
	{
		return Input.GetAxis(toStr[a]);
	}
//--------------------------------------------------------------------------HELPERS:
	
}
