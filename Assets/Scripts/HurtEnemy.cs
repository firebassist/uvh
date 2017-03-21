using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if (other.name == "Enemy_Walking") 
		if (other.tag == "Enemy") 
		{
			Debug.Log ("Enemy Hit");
			Destroy (other.gameObject);
			//HealthManager.HurtPlayer (damageToGive);
		}
	}
}
