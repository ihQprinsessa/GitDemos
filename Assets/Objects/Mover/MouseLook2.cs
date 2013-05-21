using UnityEngine;
using System.Collections;

public class MouseLook2 : MonoBehaviour {
	
	public bool turnedOn=true;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	float rotationY = 0F,rotationX = 0f;
	float old_x_axis,old_y_axis;
	
	void Update ()
	{
		if (!turnedOn) return;
			
		rotationX += (Input.GetAxis("Mouse X")-old_x_axis) * sensitivityX;
		old_x_axis=Input.GetAxis("Mouse X");
	
	
		rotationY += (Input.GetAxis("Mouse Y")-old_y_axis) * sensitivityY;
		old_y_axis=Input.GetAxis("Mouse Y");
		//rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	
	}
}