using UnityEngine;
using System.Collections;

public class ScaleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale=new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z+0.05f);
		rigidbody.WakeUp();
	}
	
	void OnCollision(Collision other){
			
		if (other.rigidbody!=null)
			other.rigidbody.WakeUp();
	}
}
