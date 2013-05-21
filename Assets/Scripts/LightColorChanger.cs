using UnityEngine;
using System.Collections;

public class LightColorChanger : MonoBehaviour {
	
	float timer,max_time=2;
	Color lerpColor;
	// Use this for initialization
	void Start () {
		timer=max_time;
		lerpColor=randomColor();
	}
	
	// Update is called once per frame
	void Update () {
		light.color=Color.Lerp(light.color,lerpColor,Time.deltaTime);
		
		timer-=Time.deltaTime;
		
		if (timer<0){
			lerpColor=randomColor();
			timer=max_time;
		}
	}
	
	public Color randomColor(){
		return new Color(Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
	}
}
