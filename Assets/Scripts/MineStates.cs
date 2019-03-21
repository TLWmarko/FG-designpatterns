using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineState {
	protected Mine mine;
	public virtual void Update() {}
	public virtual void Enter() {}
	public virtual void Start(Mine owner) {}

	protected int DetectPlayers(float detectDist) {
		float minMag = Mathf.Infinity;
		int playerIndex = -1;
		for(int i = 0; i < Player.players.Count; i++) {
			var mag = (Player.players[i].transform.position - mine.transform.position).sqrMagnitude;
			if(mag < minMag) {
				minMag = mag;
				playerIndex = i;
			}
		}
		if(minMag <= detectDist)
			return playerIndex;
		return -1;
	}
}
[System.Serializable]
public class MineStateIdle : MineState {
	public float detectDist;
	Vector3 homePos;
	public override void Start(Mine owner) {
		mine = owner;
		homePos = mine.transform.position;
	}
	public override void Enter() {
		mine.currentState = this;
	}
	public override void Update() {
		if (DetectPlayers(detectDist) != -1) {
			mine.detectState.Enter();
			return;
		}

		mine.rb.AddForce(homePos - mine.transform.position, ForceMode.Acceleration);
	}
}
[System.Serializable]
public class MineStateAttack : MineState {
	public float chasingDistance;
	[System.NonSerialized]
	public Player chasingPlayer;
	public override void Start(Mine owner) {
		mine = owner;
	}
	public override void Enter() {
		mine.currentState = this;
	}
	public override void Update() {
		if(chasingPlayer.alive) {
			var mag = (chasingPlayer.transform.position - mine.transform.position).sqrMagnitude;
			if(mag <= chasingDistance * chasingDistance) {
				mine.rb.AddForce(chasingPlayer.transform.position - mine.transform.position, ForceMode.Acceleration);
				return;
			}
		}
		mine.idleState.Enter();
		return;
	}
}
[System.Serializable]
public class MineStateDetect : MineState {
	public Renderer blinkRenderer;
	public Color onColor;
	public Color offColor;
	public AnimationCurve blinkCurve;
	public float detectDist;

	float detectTime;

	public override void Start(Mine owner) {
		mine = owner;
	}
	public override void Enter() {
		mine.currentState = this;
		detectTime = Time.time;
	}
	public override void Update() {
		var time = Time.time - detectTime;
		var blinkyness = blinkCurve.Evaluate(time);
		blinkRenderer.material.SetColor("_EmissionColor", Color.Lerp(offColor, onColor, blinkyness));
		var animLength = blinkCurve[blinkCurve.length - 1].time;
		if (animLength <= time) {
			var detectedPlayer = DetectPlayers(detectDist);
			if(detectedPlayer != -1) {
				mine.attackState.chasingPlayer = Player.players[detectedPlayer];
				mine.attackState.Enter();
				return;
			}
			mine.idleState.Enter();
			return;
		}
	}
}