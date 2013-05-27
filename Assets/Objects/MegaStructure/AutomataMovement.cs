using UnityEngine;
using System.Collections;

public class AutomataMovement : MonoBehaviour {
	
	public float speed;
	public Vector3 direction;
	bool movingOnward,move_ok;
	Timer timer;
	
	public Collider restrictBox;
	// Use this for initialization
	void Start () {
		timer=new Timer(1000,RandomDirection);
	}
	
	// Update is called once per frame
	void Update () {
		if (movingOnward){
			transform.position+=direction*speed;
		}
		else{
			transform.position+=-direction*speed;
		}
		/*
		if (Vector3.Distance(restrictBox.bounds.center,transform.position)>restrictBox.size.magnitude/2){
			ChangeDirection(!move_ok);
		}
		else
			move_ok=movingOnward;
			*/
	}
	
	void OnCollision(Collider other){
		//change direction
	}
	
	void ChangeDirection(bool direction){
		movingOnward=direction;
		timer.Delay=Random.Range(0,1000);
	}
	void RandomDirection(){
		ChangeDirection(Subs.RandomBool());
	}

	void ToggleDirection(){
		ChangeDirection(!movingOnward);
	}
}
