﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour {
	AudioSource laser;
	public GameObject source;
	PowerUps powerUps;
	bool shoot;
		// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<AudioSource>();
		shoot = true;
		powerUps = new PowerUps ();
		}

		// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (shoot);
		//Vector3 startRay = new Vector3 (Camera.main.transform.position.x+.1f,Camera.main.transform.position.y-.86f,Camera.main.transform.position.z+.35f);
		Debug.DrawRay(source.transform.position, source.transform.forward, Color.magenta);
		if (Input.GetButton("Fire1"))
		{	
			if(powerUps.getPowerUpShootFaster()){ //have to do diferent cases so their indipendednt of eachother
				laser.Play();
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(source.transform.position, source.transform.forward,out hit) && (hit.collider.gameObject.tag == "Bulk" || hit.collider.gameObject.tag == "Walker" ||hit.collider.gameObject.tag == "Runner"))
				{
					//Destroy(hit.collider.gameObject);
					GameObject enemy = hit.collider.gameObject;
					EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));
					enemyHealth.GotHit ();
				}
			}
			else if(shoot){
				shoot = false;
				laser.Play();
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(source.transform.position, source.transform.forward,out hit) && (hit.collider.gameObject.tag == "Bulk" || hit.collider.gameObject.tag == "Walker" ||hit.collider.gameObject.tag == "Runner"))
				{
					GameObject enemy = hit.collider.gameObject;
					EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));
					enemyHealth.GotHit ();
				}	
				StartCoroutine(Shoot());
			}
		}
	}
	void OnEnable() {
		shoot = true;
	}
	IEnumerator Shoot()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(1);
		shoot = true;
		//print(Time.time);
	}
}
	
