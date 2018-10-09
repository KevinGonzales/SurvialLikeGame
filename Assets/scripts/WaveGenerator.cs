using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	public GameObject[] enemies ;
	private int minNumberToGenerate;
	private int MaxNumberToGenerate;
	private int amount ;
	private static int leftStatic;
	private int left ;

	public GameObject[] Spawns;
	public LevelController levelController;
	// Use this for initialization
	void Start () {
		minNumberToGenerate = 5;
		MaxNumberToGenerate = 10;
		left = 0;
		leftStatic = 0;
		//generateWave ();
	}

	public void generateWave(){
		minNumberToGenerate += 6 * levelController.GetLevel ();
		MaxNumberToGenerate += 6 * levelController.GetLevel ();

		amount = Random.Range (minNumberToGenerate,MaxNumberToGenerate);
		left = amount;
		leftStatic = amount;

		for(int i= 0; i< amount;i++){
			Vector3 pos = Spawns [Random.Range (0, Spawns.Length)].transform.position;

			int enemy = Random.Range (1, 100);
			if(enemy <=50){
				enemy = 0;
			}
			else if(enemy <=80){
				enemy = 1;
			}
			else if(enemy <=100){
				enemy = 2;
			}
			Instantiate (enemies[enemy],pos,Quaternion.identity);
		}
	}

	void Update(){
		left = leftStatic;
	}

	float RandomSign() {
		if (Random.Range(0, 2) == 0) {
			return -1f;
		}
		return 1f;
	}

	public int getAmountSpawned(){
		return amount;
	}

	public int getAmountLeft(){
		return left;
	}

	public static void LostOne(){
		leftStatic--;
	}
}
