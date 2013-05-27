using UnityEngine;
using System.Collections;

public class ScaleScript : MonoBehaviour {
	
	public Vector3 add_amount;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale+=add_amount;
		rigidbody.WakeUp();
	}
	
	void OnCollision(Collision other){
			
		if (other.rigidbody!=null)
			other.rigidbody.WakeUp();
	}
}
