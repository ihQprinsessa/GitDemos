using UnityEngine;
using System.Collections;
using NotificationSys;

public class ShipScript : MonoBehaviour {
	
	public Transform destroy_particleeffect;

	// Use this for initialization
	void Start () {
		//graphics=GetComponent<graphics>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DestroySelf(){
		Instantiate(destroy_particleeffect,transform.position,Quaternion.identity);
		
		NotificationCenter.Instance.sendNotification(new DisengageParent_note(transform.parent.rigidbody.velocity));
		NotificationCenter.Instance.sendNotification(new Explosion_note(transform.position,100,5));
	}
}
