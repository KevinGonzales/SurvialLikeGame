using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUps : MonoBehaviour {

	static bool ShootFaster;	
	static bool GainHealth;		
	static bool Invisibility;	
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		ShootFaster = false;
		GainHealth = false;
		Invisibility = false;
	}

	// Update is called once per frame
	/*void FixedUpdate () {
		if(ShootFaster){
			ShootFasterStart ();
		}
		if(GainHealth){
			//gain some health
		}
		if(Invisibility){
			InvisibilityStart ();
		}
	}*/

	/*void OnCollisionEnter (Collision col)
	{
		Debug.Log ("power");

		if(col.gameObject.tag == "ShootFaster")
		{
			ShootFaster = true;
			Debug.Log ("power");
			StartCoroutine (ShootFasterStart());
			Destroy (col.gameObject);
		}
		if(col.gameObject.tag == "GainHealth")
		{
			GainHealth = true;
			Debug.Log ("power");
			Destroy (col.gameObject);
			GainHealth = false;
		}
		if(col.gameObject.tag == "Invisibility")
		{
			Invisibility = true;
			Debug.Log ("power");
			StartCoroutine (InvisibilityStart());
			Destroy (col.gameObject);
		}
		//stopped working for some reason
	}*/ 

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "ShootFaster")
		{
			Destroy (col.gameObject);

			ShootFaster = true;
			//Debug.Log ("power faster");
			StartCoroutine (ShootFasterStart());
		}
		if(col.gameObject.tag == "GainHealth")
		{
			Destroy (col.gameObject);
			playerHealth.Heal ();
		}
		if(col.gameObject.tag == "Invisibility")
		{
			Destroy (col.gameObject);

			Invisibility = true;
			//Debug.Log ("power invisible");
			StartCoroutine (InvisibilityStart());
		}
	}

	public bool getPowerUpShootFaster(){
		return ShootFaster;
	}

	public void setPowerUpShootFaster(bool powerUp){
		ShootFaster = powerUp;
	}

	public bool getPowerUpHealth(){
		return GainHealth;
	}

	public void setPowerUpHealth(bool powerUp){
		GainHealth = powerUp;
	}

	public bool getPowerUpInvisibility(){
		return Invisibility;
	}

	public void setPowerUpInvisibility(bool powerUp){
		Invisibility = powerUp;
	}

	IEnumerator ShootFasterStart()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(5);
		ShootFaster = false;
		//print(Time.time);
	}
	IEnumerator InvisibilityStart()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(5);
		Invisibility = false;
		//print(Time.time);
	}
}
