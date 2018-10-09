using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour {

	public GameObject[] powerUps;
	public GameObject source;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int i = Random.Range (0,1000);
		if(i < 5){
			float x = Random.Range (2,50) * RandomSign();
			float y = Random.Range (0,1.5f);
			float z = Random.Range (2,50) * RandomSign();

			Vector3 pos = new Vector3 (source.transform.position.x + x, source.transform.position.y + y, source.transform.position.z + z);
			Instantiate (powerUps[Random.Range(0,powerUps.Length)],pos,Quaternion.identity);
		}
	}

	float RandomSign() {
		if (Random.Range(0, 2) == 0) {
			return -1f;
		}
		return 1f;
	}
}
