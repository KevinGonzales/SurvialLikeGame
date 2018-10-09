using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurret : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Destroy()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(2);
		Destroy (this.gameObject);
		//print(Time.time);
	}
}
