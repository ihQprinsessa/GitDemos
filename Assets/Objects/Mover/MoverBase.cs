using UnityEngine;
using System.Collections;

public class MoverBase : MonoBehaviour {
	
	private bool colliding=false;
	MouseLook mouse_look;
	
	// Use this for initialization
	void Start () {
		mouse_look=GetComponent<MouseLook>();
		Debug.Log(""+collider.GetInstanceID());
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
		
		
		if (dir==Vector3.zero){
			if (rigidbody.velocity!=Vector3.zero)
				rigidbody.velocity*=0.55f;
		}
		
		if (ang_dir==Vector3.zero){
			if (rigidbody.angularVelocity!=Vector3.zero)
				rigidbody.angularVelocity*=0.55f;
		}
		
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
}
