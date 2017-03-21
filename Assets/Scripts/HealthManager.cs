using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	/*** Part 9 ***/
	public int maxPlayerHealth;

	public static int playerHealth;

	//Text text;

	public bool isDead; /*** prevent making player dead for respawn properly***/

	private LevelManager levelManager;

	/*** Part 18 ***/
	private LifeManager lifeManager;

	/*** Part 26 ***/
	public Slider healthSlider;


	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		healthSlider = GetComponent<Slider>();
		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager> ();
		isDead = false; /*** prevent making player dead for respawn properly***/

		lifeManager =  FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) { /*** prevent making player dead for respawn properly***/
//			if (playerHealth <= 0) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();

			lifeManager.TakeLife ();
			isDead = true;
		}

		//text.text = "" + playerHealth;
		healthSlider.value = playerHealth;
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
