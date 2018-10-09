using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceTurret : MonoBehaviour {
	AudioSource laser;
	public GameObject Turret;
	public GameObject source;
	public Image image;
	public GameObject ReloadText;
	PowerUps powerUps;
	bool shoot;
	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<AudioSource>();
		shoot = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Vector3 startRay = new Vector3 (Camera.main.transform.position.x+.1f,Camera.main.transform.position.y-.86f,Camera.main.transform.position.z+.35f);
		Debug.DrawRay(source.transform.position, source.transform.forward, Color.magenta);
		if (Input.GetButton("Fire1"))
		{	
			if(shoot){
				shoot = false;
				StartCoroutine(Shoot());
				Vector3 pos = new Vector3 (source.transform.position.x,source.transform.position.y,source.transform.position.z +4f);
				Instantiate (Turret,pos,Quaternion.identity);
				image.GetComponent<Image>().color = new Color32(255,0,0,255);
				ReloadText.SetActive (true);
			}
		}

	}
	void OnEnable() {
		StartCoroutine(Shoot());
	}
	IEnumerator Shoot()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(5);
		shoot = true;
		image.GetComponent<Image>().color = new Color32(255,255,255,255);
		ReloadText.SetActive (false);

		//print(Time.time);
	}
}

