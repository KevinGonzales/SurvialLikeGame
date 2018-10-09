using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour {
	// Use this for initialization
	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;

	void Start () {
		gun1.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("One")){
			disableAll ();
			gun1.SetActive (true);
		}
		if(Input.GetButton("Two")){
			disableAll ();
			gun2.SetActive (true);
		}
		if(Input.GetButton("Three")){
			disableAll ();
			gun3.SetActive (true);
		}
	}

	private void disableAll(){
		gun1.SetActive (false);
		gun2.SetActive (false);
		gun3.SetActive (false);

	}
}
