using UnityEngine;
using System.Collections;

public class boxrot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other){
		rigidbody.AddForce((-rigidbody.velocity/2)*10000);
	}
}
