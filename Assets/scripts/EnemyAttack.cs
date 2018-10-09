using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public PlayerHealth playerHealth;

	void Start(){
	}
	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Bulk" || hit.gameObject.tag == "Walker" || hit.gameObject.tag == "Runner") {

			Animator anim = hit.gameObject.GetComponent<Animator>();
			anim.SetTrigger ("Attack");
			playerHealth.gotHit ();
		}
	}
}
