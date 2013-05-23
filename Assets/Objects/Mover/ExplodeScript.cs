using UnityEngine;
using System.Collections;
using System.Linq;
using NotificationSys;

public class ExplodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NotificationCenter.Instance.addListener(EXPLODE,NotificationType.Explode);
		NotificationCenter.Instance.addListener(DISENGAGE,NotificationType.DisengageParent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void DISENGAGE(Notification note){
		var n=(DisengageParent_note)note;
		
		collider.enabled=true;
		rigidbody.isKinematic=false;
		
		rigidbody.velocity=n.Velocity;
		transform.parent=null;
	}
	
	void EXPLODE(Notification note){
		var exp=(Explosion_note)note;
		exp.addForce(rigidbody);
	}
	
	void OnDestroy(){
		NotificationCenter.Instance.removeListener(EXPLODE,NotificationType.Explode);
	}
}
