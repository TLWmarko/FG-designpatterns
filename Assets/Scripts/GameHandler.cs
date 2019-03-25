﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	float timer = 0;
	const float TIMELIMIT = 600f; // 10 minutes

	Player fragLeader = null;

	void Update() {
		timer += Time.deltaTime;
		if(timer >= TIMELIMIT) {
			EndGame();
		}
	}
	public void TryUpdateFragLeader(Player instigator) {
		if(!instigator)
			return;
		if(fragLeader == null || instigator.frags > fragLeader.frags)
			fragLeader = instigator;
	}
	void EndGame() {
		Debug.LogFormat("{0} wins with {1} frags!", fragLeader.name, fragLeader.frags);
	}

	//
	// "Good"
	//
	
	static GameHandler instance;
	public static GameHandler GetInstance() {
		return instance;
	}

	// called when scene starts
	void Awake() {
		instance = this;
	}
	// called when exiting the scene
	void OnDestroy() {
		instance = null;
	}
	
	//
	// Lazy Init 1
	//
	/*
	static GameHandler instance;
	public static GameHandler GetInstance() {
		if (instance == null)
			instance = new GameObject("GameHandler").AddComponent<GameHandler>();
		return instance;
	}
	
	// called when exiting the scene
	void OnDestroy() {
		instance = null;
	}
	*/

	//
	// Lazy Init 2 (need dontdestroy prob)
	//
	/*
	static GameHandler() { // creates singleton when attempting to access
		instance = new GameObject("GameHandler").AddComponent<GameHandler>();
	}
	// called when exiting the scene
	void OnDestroy() {
		instance = null;
	}
	*/
}
