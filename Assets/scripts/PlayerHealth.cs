using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private int hitsIcanTake ;
	public GameObject gameOver;
	public Text uiHealth;
	static bool alive;
	PowerUps powerUps;


	// Use this for initialization
	void Start () {
		hitsIcanTake = 100;
		alive = true;
		powerUps = new PowerUps ();
	}
		


	public void Heal(){
		Debug.Log ("called");
		if(hitsIcanTake < 100){
			hitsIcanTake += 10;
			if(hitsIcanTake > 100){
				hitsIcanTake = 100;
			}
			uiHealth.text = "Health : "+ hitsIcanTake + " %";
		}
	}

	public void gotHit(){
		hitsIcanTake--;
		if(hitsIcanTake <=0 ){
			gameOver.SetActive (true);
			hitsIcanTake = 0;
			alive = false;
		}
		uiHealth.text = "Health : "+ hitsIcanTake + " %";
	}

	public static bool getAlive(){
		return alive;
	}
		
}
