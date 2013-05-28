using UnityEngine;
using System.Collections;

public class PE_AutoDestroy : MonoBehaviour {

	// Use this for initialization
	ParticleSystem PS; 
	void Start () {
		PS=GetComponent("ParticleSystem") as ParticleSystem;
	}
	
	// Update is called once per frame
	void Update () {
		if (PS.isStopped)
			Destroy(gameObject);
	}
}
