using UnityEngine;
using System.Collections;

public class MegaStructureScr : MonoBehaviour {
	
	public Transform automata_prefab; 
	Transform graphics;
	// Use this for initialization
	void Start () {
		graphics=GetComponent("Graphics") as Transform;
		InitStructure();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void InitStructure(){
		var radius=collider.bounds.size.x/2;
		var up_pos=transform.position+Vector3.one*radius;
		
		var pos=up_pos;
		for(int i=0;i<radius*2;i++){
			for(int j=0;j<radius*2;j++){
				var obj=Instantiate(automata_prefab, pos,Quaternion.identity) as AutomataMovement;
				//obj.restrictBox=transform.collider;
				pos+=Vector3.left;
			}
			up_pos+=Vector3.back;
			pos=up_pos;
		}
	}
}
