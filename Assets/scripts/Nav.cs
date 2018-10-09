using UnityEngine;
using System.Collections;

public class Nav : MonoBehaviour {
	UnityEngine.AI.NavMeshAgent agent;
	GameObject target;
	PowerUps powerUps ;
	private EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		powerUps = new PowerUps ();
		enemyHealth = (EnemyHealth) gameObject.GetComponent(typeof(EnemyHealth));
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		try{
			if((!(powerUps.getPowerUpInvisibility())) && (!(enemyHealth.getLost() ))){
				agent.SetDestination (target.transform.position);
				}
		}
		catch(System.Exception e){
			
		}
	}
}
