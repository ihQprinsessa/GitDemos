using UnityEngine;
using System.Collections;

public class MainSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//creating level
		var randomizer=GetComponent<LevelRandomizer>();
		randomizer.RandomizeLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
