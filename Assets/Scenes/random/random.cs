using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {
	
	public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)){
			Instantiate(ball,transform.position+transform.TransformDirection(Vector3.right),Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.S)){
			Instantiate(ball,transform.TransformDirection(Vector3.back),Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.D)){
			Instantiate(ball,transform.TransformDirection(Vector3.left),Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.W)){
			Instantiate(ball,transform.TransformDirection(Vector3.forward),Quaternion.identity);
		}
	}
}
