using UnityEngine;
using System.Collections;

public class MoverBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate() {
	
		var dir=Vector3.zero;

		if (Input.GetKey(KeyCode.W)){
			dir+=Vector3.forward;
		}
		else 
		if (Input.GetKey(KeyCode.S)){
			dir+=Vector3.back;
		}
		
		if (Input.GetKey(KeyCode.A)){
			dir+=Vector3.left;
		}
		else 
		if (Input.GetKey(KeyCode.D)){
			dir+=Vector3.right;
		}
		
		if (Input.GetKey(KeyCode.Space)){
			dir+=Vector3.up;
		}
		else
		if (Input.GetKey(KeyCode.LeftControl)){
			dir+=Vector3.down;
		}
		
		Move(dir,0.1f);
	}
	
	void Move(Vector3 dir,float speed){
		transform.position+=Vector3.Normalize(dir)*speed;
	}
}
