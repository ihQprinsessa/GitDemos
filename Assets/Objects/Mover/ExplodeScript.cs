using UnityEngine;
using System.Collections;
using System.Linq;
using NotificationSys;

public class ExplodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NotificationCenter.Instance.addListener(EXPLODE,NotificationType.Explode);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void EXPLODE(Notification note){
		Debug.Log("Received Explode Notification message!");
		
		collider.enabled=true;
		rigidbody.isKinematic=false;
		
		if (transform.parent.rigidbody!=null)
			rigidbody.velocity=transform.parent.rigidbody.velocity;
		transform.parent=null;
		
		
		var exp=(Explosion_note)note;
		//exp.addForce(rigidbody);
	}
	
	void OnDestroy(){
		NotificationCenter.Instance.removeListener(EXPLODE,NotificationType.Explode);
	}
}
