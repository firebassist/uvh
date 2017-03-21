using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	/*** Part 3 ***/
	public GameObject currentCheckPoint;

	private PlayerController player;

	public HealthManager healthManager;

	/*** Part 5 ***/
	public float respawnDelay;

	/*** Part 7 ***/
	private float gravityStore;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		//Debug.Log ("Player Respawn");
//		player.transform.position = currentCheckPoint.transform.position;
		/*** Part 9 ***/
//		healthManager.FullHealth ();
		//healthManager.isDead = false;

		/*** Part 5 ***/
		StartCoroutine ("RespawnPlayerCoroutine");
	}

	public IEnumerator RespawnPlayerCoroutine()
	{
		/*** Part 5 ***/
		//player.enabled = false;

		player.gameObject.SetActive(false);
		player.GetComponent<Renderer> ().enabled = false;

		/*** Part 7 ***/
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;


		/*** Part 6 prevent sticky wall***/ 
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		/*** Part 5 ***/
		yield return new WaitForSeconds (respawnDelay);

		//player.enabled = true;
		player.gameObject.SetActive(true);
		player.GetComponent<Renderer> ().enabled = true;

		/*** Part 7 ***/
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;

		/*** Part 11 prevents respawn knockback ***/
		player.knockbackCount = 0;
		Debug.Log ("Player Respawn");
		player.transform.position = currentCheckPoint.transform.position;

		/*** Part 9 ***/
		healthManager.FullHealth ();
		healthManager.isDead = false; /*** prevent making player dead for respawn properly***/
	}

}
