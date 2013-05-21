using UnityEngine;
using System.Collections;

public class AirDrag : MonoBehaviour {
	
	public float 
				velocity_drag=1,velocity_max=100,
				angular_drag=1,angular_max=100;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		if (rigidbody.velocity!=Vector3.zero)
			rigidbody.AddForce(rigidbody.velocity*-velocity_drag);

		if (rigidbody.angularVelocity!=Vector3.zero)
			rigidbody.AddTorque(rigidbody.angularVelocity*-angular_drag);
	
		//clamp velocities
		rigidbody.velocity=Vector3.ClampMagnitude(rigidbody.velocity,velocity_max);
		rigidbody.angularVelocity=Vector3.ClampMagnitude(rigidbody.angularVelocity,angular_max);
	}
}
