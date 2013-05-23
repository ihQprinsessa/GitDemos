using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer{
	
	//class
	public delegate void TimerEvent();
	public static List<Timer> timers=new List<Timer>(),timers_destroyed=new List<Timer>();
	
	public static void UpdateTimers () {
		foreach (var t in timers){
			t.Update();
			if (t.Destroyed)
				timers_destroyed.Add(t);
		}
		if (timers_destroyed.Count>0){
			foreach (var t in timers_destroyed){
				timers.Remove(t);
			}
			timers_destroyed.Clear();
		}
	}
	
	//object
	float time,tick;
	TimerEvent timer_event;
	
	public float Delay{get{return time;} set{time=value/1000;}}
	public bool Destroyed{get;private set;}

	public Timer(int millis,TimerEvent te){
		timers.Add(this);
		
		time=tick=millis/1000;
		timer_event=te;
	}
	
	public void Update(){
		tick-=Time.deltaTime;
		
		if (tick<=0){
			if (timer_event!=null)
				timer_event();
			Reset();
		}
	}
	
	//subs
	
	public void Reset(){
		tick=time;
	}
	
	public void Destroy(){
		Destroyed=true;
	}
}
