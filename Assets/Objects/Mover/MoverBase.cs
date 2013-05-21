using UnityEngine;
using System.Collections;

public class MoverBase : MonoBehaviour {
	
	private bool colliding=false;
	MouseLook2 mouse_look;
	
	// Use this for initialization
	void Start () {
		mouse_look=transform.FindChild("direction").GetComponent<MouseLook2>();
		Debug.Log(""+mouse_look);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
	
		var dir=Vector3.zero;
		var ang_dir=Vector3.zero;
		
		//input
		
		if (Input.GetMouseButtonDown(1)){
			mouse_look.turnedOn=!mouse_look.turnedOn;
		}
		
		//forward/backward
		if (Input.GetKey(KeyCode.W)){
			dir+=Vector3.forward;
		}
		else 
		if (Input.GetKey(KeyCode.S)){
			dir+=Vector3.back;
		}
		
		//strafe
		if (Input.GetKey(KeyCode.A)){
			dir+=Vector3.left;
		}
		else 
		if (Input.GetKey(KeyCode.D)){
			dir+=Vector3.right;
		}
		
		//up/down
		if (Input.GetKey(KeyCode.Space)){
			dir+=Vector3.up;
		}
		else
		if (Input.GetKey(KeyCode.LeftControl)){
			dir+=Vector3.down;
		}
		
		//rotation
		
		if (Input.GetKey(KeyCode.R)){
			ang_dir+=Vector3.down;
		}
		else
		if (Input.GetKey(KeyCode.F)){
			ang_dir+=Vector3.up;
		}
		
		if (Input.GetKey(KeyCode.Z)){
			ang_dir+=Vector3.left;
		}
		else
		if (Input.GetKey(KeyCode.C)){
			ang_dir+=Vector3.right;
		}
		
		if (Input.GetKey(KeyCode.Q)){
			ang_dir+=Vector3.forward;
		}
		else
		if (Input.GetKey(KeyCode.E)){
			ang_dir+=Vector3.back;
		}
		
		
		//movement
		//if (!colliding)
		Move(dir,10);
		Rotate(ang_dir,1);
		
					
		//mouse rotation
		if (mouse_look.turnedOn)
			rigidbody.MoveRotation(mouse_look.transform.rotation);

		//rigidbody.velocity=getForceDrag(dir,rigidbody.velocity,0.60f);
		rigidbody.angularVelocity=getForceDrag(ang_dir,rigidbody.angularVelocity,0.60f);
		
		if (dir==Vector3.zero)
			rigidbody.velocity*=0.6f;
		
		
		
		//clamp velocities
		rigidbody.velocity=Vector3.ClampMagnitude(rigidbody.velocity,10);
		rigidbody.angularVelocity=Vector3.ClampMagnitude(rigidbody.angularVelocity,1);
		
		colliding=false;
	}
	
	void Move(Vector3 dir,float speed){
		rigidbody.AddRelativeForce(Vector3.Normalize(dir)*speed);
	}
	void Rotate(Vector3 dir,float speed){
		rigidbody.AddRelativeTorque(dir*speed);
	}
	
	void OnCollisionStay(Collision other){
		Debug.Log("Colliding!");
		colliding=true;
	}
	/*
	void OnCollisionEnter(Collision other){
		Debug.Log("en!");
		//colliding=true;
	}
	void OnCollisionExit(Collision other){
		Debug.Log("ex!");
		//colliding=true;
	}
	
	
	void OnTriggerEnter(Collider other){
		Debug.Log("t en!");
		//colliding=true;
	}
	void OnTriggerExit(Collider other){
		Debug.Log("t ex!");
		//colliding=true;
	}
	
	void OnTriggerStay(Collider other){
		Debug.Log("t stay!");
		//colliding=true;
	}
	*/
	
	void OnGUI(){
		

		GUI.Box(new Rect(10,10,200,100),"Mouse move: "+mouse_look.turnedOn);
		
	}
	
	/// <summary>
	/// Gets the force dragged in all non thrusted directions.
	/// </summary>
	/// <returns> a new force vector
	/// The force drag.
	/// </returns>
	/// <param name='thrust'>
	/// Thrust. If thrust is on drag won't affect the force.
	/// </param>
	/// <param name='current'>
	/// Current. Current force
	/// </param>
	/// <param name='drag'>
	/// Drag. amout of drag
	/// </param>
	private Vector3 getForceDrag(Vector3 thrust, Vector3 current,float drag){
		float vx=current.x,vy=current.y,vz=current.z;
		
		if (thrust.x==0){
			vx=current.x*drag;
		}
		if (thrust.y==0){
			vy=current.y*drag;
		}
		if (thrust.z==0){
			vz=current.z*drag;
		}
		return new Vector3(vx,vy,vz);
	}
}
