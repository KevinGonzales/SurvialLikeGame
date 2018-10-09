using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	int currLevel;
	public WaveGenerator waveGenerator;
	int amount;
	public Text amountSpwaned;
	public Text amountLeft;
	public GameObject NextWave;


	void awake(){
		currLevel = 0;
		//waveGenerator.generateWave ();
		//amount = waveGenerator.getAmountSpawned ();
	}

	public int GetLevel(){
		return currLevel;
	}

	void Update(){
		//Debug.Log ("Left "+ waveGenerator.getAmountLeft ());
		amountLeft.text = "Left : " + waveGenerator.getAmountLeft ();
		amountSpwaned.text = "Level : " + currLevel;
		if(waveGenerator.getAmountLeft() <= 0 ){
			NextWave.SetActive (true);
			currLevel++;
			waveGenerator.generateWave ();
			StartCoroutine (CloseNextWave());
		}
	}

	IEnumerator CloseNextWave()
	{
		//print(Time.time);
		yield return new WaitForSecondsRealtime(5);
		NextWave.SetActive (false);

		//print(Time.time);
	}
		

}
