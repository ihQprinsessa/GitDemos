using UnityEngine;
using System.Collections;

public class LightIntensityChanger : MonoBehaviour {
	
	public float intensity_min,intensity_max;
	
	// Use this for initialization
	void Start () {
	
	}
	float timer;
	// Update is called once per frame
	void Update () {
		timer+=Time.deltaTime;

		light.intensity=intensity_min+(1+Mathf.Cos(timer))*((intensity_max-intensity_min)/2);;
	}
}
