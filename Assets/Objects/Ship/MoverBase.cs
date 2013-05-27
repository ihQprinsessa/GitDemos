using UnityEngine;
using System.Collections;
using NotificationSys;

public class MoverBase : MonoBehaviour {
	
	private bool mouse_move=true;
	MouseLook2 mouse_look;
	MouseLook mouse_look_camera;
	ShipScript ShipScr;
	
	bool speed_mode=false;
	
	float health=100;
	
	Quaternion old_camera_rot;
	
	public float Health{get{return health;}set{health=value;
			if (health<=0){
				health=0;
				DestroySelf();
			}
		}}
	
	// Use this for initialization
	void Start () {
		mouse_look=transform.FindChild("direction").GetComponent<MouseLook2>();
		mouse_look_camera=transform.FindChild("Camera").GetComponent<MouseLook>();
		
		ShipScr=transform.FindChild("Ship").GetComponent<ShipScript>();

		old_camera_rot=transform.rotation;
	}
	
	void Update(){
		
		if (Input.GetMouseButtonDown(1)){
			mouse_move=!mouse_move;
			mouse_look_camera.turnedOn=!mouse_move;
		}
		
		if (Input.GetKey(KeyCode.CapsLock)){
			speed_mode=!speed_mode;
		}
		
		//dev
		if (Input.GetKey(KeyCode.H)){
			DestroySelf();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		var dir=Vector3.zero;
		var ang_dir=Vector3.zero;
		//input

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
		
		//speed
		var speed=10;
		if (Input.GetKey(KeyCode.LeftShift)||speed_mode){
			speed=100;
		}
		
		Move(dir,speed);
		Rotate(ang_dir,1);
			
		//mouse rotation
		if (mouse_move){
			//move ship to face direction
			rigidbody.MoveRotation(mouse_look.transform.rotation);
			
			//move camera to face direction
			//mouse_look_camera.rotateView(rigidbody.position+rigidbody.rotation.eulerAngles,-rigidbody.rotation.eulerAngles,10);
			
			//mouse_look_camera.rotateView(transform.position,-transform.rotation.eulerAngles,10);
			
		}

		//rigidbody.velocity=getForceDrag(dir,rigidbody.velocity,0.60f);
		//rigidbody.angularVelocity=getForceDrag(ang_dir,rigidbody.angularVelocity,0.60f);
		
		//if (dir==Vector3.zero)
		if (Input.GetKey(KeyCode.X))
			rigidbody.AddForce(-rigidbody.velocity*3);
		if (ang_dir==Vector3.zero)
			rigidbody.angularVelocity*=0.6f;
		
		//clamp velocities
		rigidbody.velocity=Vector3.ClampMagnitude(rigidbody.velocity,100);
		rigidbody.angularVelocity=Vector3.ClampMagnitude(rigidbody.angularVelocity,1);
	}
	
	void Move(Vector3 dir,float speed){
		rigidbody.AddRelativeForce(Vector3.Normalize(dir)*speed);
	}
	void Rotate(Vector3 dir,float speed){
		rigidbody.AddRelativeTorque(dir*speed);
	}

	
	void OnCollisionEnter(Collision c){
		
		Health-=c.impactForceSum.magnitude;
	}
	
	public void DestroySelf(){
			ShipScr.DestroySelf();
			gameObject.SetActive(false);
	}
	
	
	void OnGUI(){
		GUI.Box(new Rect(10,10,200,100),"Mouse move: "+mouse_move+"\nSpeed: "+rigidbody.velocity+"\n\nHealth: "+health);
	}
	
	/// <summary>
	/// DEV.RUBBISH!
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
