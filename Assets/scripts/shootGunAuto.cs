using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shootGunAuto : MonoBehaviour {
	AudioSource laser;
	public GameObject source;
	PowerUps powerUps;
	public Image image;
	bool shoot;
	int rounds = 30;
	public GameObject ReloadText;
	public Text roundsLeft;

	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<AudioSource>();
		shoot = true;
		powerUps = new PowerUps ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Vector3 startRay = new Vector3 (Camera.main.transform.position.x+.1f,Camera.main.transform.position.y-.86f,Camera.main.transform.position.z+.35f);
		Debug.DrawRay(source.transform.position, source.transform.forward, Color.magenta);
		if (Input.GetButton("Fire1"))
		{	
			if(powerUps.getPowerUpShootFaster()){ //have to do diferent cases so their indipendednt of eachother
				laser.Play();
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(source.transform.position, source.transform.forward,out hit) && (hit.collider.gameObject.tag == "Bulk" || hit.collider.gameObject.tag == "Walker" ||hit.collider.gameObject.tag == "Runner"))
				{
					GameObject enemy = hit.collider.gameObject;
					EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));
					enemyHealth.GotHit ();
				}
			}
			else if(shoot && rounds > 0){
				laser.Play();
				shoot = false;
				rounds--;
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
		if(rounds <= 0){
			ReloadText.SetActive (true);
			image.GetComponent<Image>().color = new Color32(255,0,0,255);
			StartCoroutine(Reload());
		}

		roundsLeft.text =  rounds+  " "  ;
	}
	void OnEnable() {
		shoot = true;
	}
	IEnumerator Shoot()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(.3f);
		shoot = true;
		//print(Time.time);
	}

	IEnumerator Reload()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(3f);
		rounds = 30;
		image.GetComponent<Image>().color = new Color32(255,255,255,255);
		ReloadText.SetActive (false);
		Debug.Log ("Realodaing");

		//print(Time.time);
	}
}

