using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTurret : MonoBehaviour {
	AudioSource laser;
	public GameObject source;
	public GameObject source2;

	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Vector3 startRay = new Vector3 (Camera.main.transform.position.x+.1f,Camera.main.transform.position.y-.86f,Camera.main.transform.position.z+.35f);
		//Debug.DrawRay(source.transform.position, source.transform.forward, Color.magenta);
				laser.Play();
				RaycastHit hit = new RaycastHit();
		try{
		if(Physics.Raycast(source.transform.position, source.transform.forward,out hit) && (hit.collider.gameObject.tag == "Bulk" || hit.collider.gameObject.tag == "Walker" ||hit.collider.gameObject.tag == "Runner"))
				{
			GameObject enemy = hit.collider.gameObject;
			EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));
			enemyHealth.GotHit ();
				}	

		RaycastHit hit2 = new RaycastHit();
		if(Physics.Raycast(source2.transform.position, source2.transform.forward,out hit2) && (hit.collider.gameObject.tag == "Bulk" || hit.collider.gameObject.tag == "Walker" ||hit.collider.gameObject.tag == "Runner"))
		{
			GameObject enemy = hit.collider.gameObject;
			EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));
			enemyHealth.GotHit ();
		}
		}
		catch(System.Exception e){
			
		}
	}
}

