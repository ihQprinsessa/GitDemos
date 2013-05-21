using UnityEngine;
using System.Collections;

public class LevelRandomizer : MonoBehaviour {
	
	public Transform CubePrefab;
	
	public void RandomizeLevel(){
		for (int i=0;i<100;i++){
			createRandomCube(CubePrefab);
		}
	}
	
	public void createRandomCube(Transform prefab){
		var randomPos=-500*Vector3.one+1000*new Vector3(Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
		
		var angle=0;
		if (Random.Range(0,100)<50)
			angle=90;
		var randomAngle=Quaternion.AngleAxis(angle,Vector3.up);
		
		var cube=Instantiate(prefab,randomPos,randomAngle) as Transform;
		
		cube.localScale=new Vector3(Random.Range(1,100f),Random.Range(1,100f),Random.Range(1,100f));
	}
}
