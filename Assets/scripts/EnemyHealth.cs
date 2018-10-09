using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private int hits;
	private int HitsICanTake;
	private string enemyType;
	public GameObject[] blood;
	private bool lost;
	Animator anim;
	//WaveGenerator waveGenerator;

	// Use this for initialization
	void Start () {
		hits = 0;
		switch(gameObject.tag){
		case"Bulk":
			HitsICanTake = 3;
			enemyType = "Bulk";
			break;
		case"Walker":
			HitsICanTake = 2;
			enemyType = "Walker";
			break;
		case"Runner":
			HitsICanTake = 1;
			enemyType = "Runner";
			break;
		}
		anim = GetComponent<Animator>();
		lost = false;
	}

	// Update is called once per frame
	void Update () {
		if(hits >= HitsICanTake){
			anim.SetTrigger ("Lost");
			StartCoroutine(Lost());
		}
	}

	public void GotHit (){
		hits++;
		if((hits-1)<= blood.Length){
			try{
			blood[hits - 1].SetActive (true);
			}
			catch(System.Exception e){
				
			}
		}
	}


	IEnumerator Lost()
	{
		//print(Time.time);
		lost = true;
		yield return new WaitForSecondsRealtime(3);
		WaveGenerator.LostOne ();
		Destroy (this.gameObject);
		//print(Time.time);
	}
	public bool getLost(){
		return lost;
	}
}
