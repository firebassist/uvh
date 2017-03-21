﻿using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	/*** Part 3 ***/
	
	public LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			levelManager.currentCheckPoint = gameObject;
			Debug.Log ("Checkpoint" + transform.position);
		}
	}
}
