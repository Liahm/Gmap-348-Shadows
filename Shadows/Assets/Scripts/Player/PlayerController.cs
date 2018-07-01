using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
//------------------------------------------------------------------------CONSTANTS:

	private const string LOG_TAG = "PlayerController";
	public bool VERBOSE = false;

//---------------------------------------------------------------------------FIELDS:
	public CharacterController cc;
	[Space(10)]
	public Camera cam;
	public Collider col;
	public Axes.Action horizontal, vertical, jump;

	public float
		speed =1,
		fallMultiplier = 2.5f,
		jumpspeed= 6; //9.3692f, sqrt(2*gravity*jumpHeight)
	public Vector3
		playerMove=Vector3.zero,
		netForce=Vector3.zero,//velocity added for one frame only
		constVelocity=Vector3.zero;//constant velocity added every frame, ex for accumulating gravity/jumping
	
//---------------------------------------------------------------------MONO METHODS:

	void FixedUpdate()
	{
		if(transform.position.y < -10f)
		{
			Restart();
			//We can add a "you die message"
			return;
		}

		MovePlayer();
		Jump();
	}

//--------------------------------------------------------------------------METHODS:
	public void AddForce(Vector3 f) {
		netForce+=f;
	}
	public void AddVelocity(Vector3 v) {
		constVelocity+=v;
	}
	public bool isGrounded()
	{
		return cc.isGrounded;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public Vector3 velocity {
		get {
			if (cc) {
				return cc.velocity;
			}else {
				return playerMove+constVelocity+netForce*Time.deltaTime;
			}
		}
	}
	
//--------------------------------------------------------------------------HELPERS:
	protected virtual void Jump()
	{
		bool grounded = isGrounded();

		if(Input.GetButtonDown(Axes.toStr[jump]) && grounded)
		{
			constVelocity.y = jumpspeed;
		}
		else
		{
			if(constVelocity.y < 0)
				constVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier -1) * Time.deltaTime;		
		}
	}
	protected virtual void MovePlayer()
	{
		Vector3 camForward = Vector3.Cross(Vector3.up,cam.transform.right).normalized;
		Vector3 inputVector = new Vector3(Axes.GetAxis(vertical), 0, Axes.GetAxis(horizontal));
		Vector3 playerDirection = inputVector.x * camForward + inputVector.z * cam.transform.right;
		playerDirection.y = 0f;

		bool grounded = isGrounded();
		playerMove = speed * playerDirection;

		//Reset the jump speed vals
		if(grounded && netForce.y<0) 
		{
			netForce.y=0;
		}
		if(grounded && constVelocity.y<0) {
			constVelocity.y=-.1f;
		}

		constVelocity+=netForce*Time.deltaTime;

		playerMove+=constVelocity;
		Vector3 v=playerMove;
		v.y=0;

		cc.Move(playerMove*Time.deltaTime);

		if(grounded) 	constVelocity*=0.6f;
		else 	
			constVelocity=Vector3.Lerp(constVelocity,Vector3.zero,.5f*Time.deltaTime);
		
		netForce=9.81f*Vector3.down;
	}
}
