using UnityEngine;
using System.Collections;

public class AutomataMovement : MonoBehaviour {
	
	public float speed;
	public Vector3 direction;
	bool movingOnward,move_ok,triggerstay;
	Timer timer;
	
	Transform LimitObject;
	// Use this for initialization
	void Start () {
		timer=new Timer(1000,RandomDirection);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (movingOnward){
			transform.position+=direction*speed;
		}
		else{
			transform.position+=-direction*speed;
		}
		
		/*
		if (Mathf.Abs(LimitObject.position.y-transform.position.y)>9){
		*/
		if (!triggerstay){
			ChangeDirection(!move_ok);
		}
		else
			move_ok=movingOnward;
		
		timer.Active=triggerstay;
		
		triggerstay=false;
	}
	
	void OnCollisionEnter(Collision other){
		//change direction
		if (other.gameObject.GetComponent<AutomataMovement>()!=null)
			ToggleDirection();
		//Debug.Log("Trigger HIT!");
	}
	
	void OnTriggerExit(Collider other){
		//change direction
		if (other.GetComponent<MegaStructureScr>()!=null)
			ChangeDirection(!move_ok);
	}
	void OnTriggerStay(Collider other){
		//change direction
		
		if (other.GetComponent<MegaStructureScr>()!=null)
			triggerstay=true;
	}
	
	void ChangeDirection(bool direction){
		movingOnward=direction;
		if (timer!=null)
			timer.Delay=Random.Range(1000,5000);

	}
	void RandomDirection(){
		ChangeDirection(Subs.RandomBool());
	}

	void ToggleDirection(){
		ChangeDirection(!movingOnward);
	}
	
	public void setLimitObject(Transform obj){
		LimitObject=obj;
	}
	
	public void MoveDirection(bool onward){
		movingOnward=onward;
	}
}
