using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	public bool turnedOn=true;
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	void Update ()
	{
		if (turnedOn){
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
				
				//rigidbody.AddRelativeTorque(new Vector3(-rotationY, rotationX, 0));
			}
			else if (axes == RotationAxes.MouseX)
			{
				//rigidbody.AddRelativeTorque(Vector3.left*(Input.GetAxis("Mouse Y") * sensitivityY));
				//rigidbody.AddRelativeTorque(Vector3.up*(Input.GetAxis("Mouse X") * sensitivityX));
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
				
				//rigidbody.AddRelativeTorque(new Vector3(-(Input.GetAxis("Mouse Y") * sensitivityY),(Input.GetAxis("Mouse X") * sensitivityX),0));
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}
		else{
			rotationY = 0F;
			//transform.localEulerAngles=Vector3.MoveTowards(transform.localEulerAngles,Vector3.forward,Time.deltaTime*10);
			
			//transform.localEulerAngles=Vector3.Slerp(transform.localEulerAngles,Vector3.forward,Time.deltaTime);
		}
	}
	void Start ()
	{
		// Make the rigid body not change rotation
		//if (rigidbody)
			//rigidbody.freezeRotation = true;
	}
	
	public void rotateView(Vector3 target,Vector3 rotation,float speed){
	  	//var targetRotation = Quaternion.LookRotation(target - transform.position,rotation);
		var targetRotation = Quaternion.LookRotation(target - transform.position,rotation);
		var str = Mathf.Min (speed * Time.deltaTime, 1);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
	}
}