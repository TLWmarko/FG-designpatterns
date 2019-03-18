using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineState {
	public virtual void Update() {}
	public virtual void Enter() { }
}

public class MineStateIdle : MineState {
	public Vector3 homePos;
	public override void Update() {
		// look for player, otherwise move home
	}
}

public class MineStateAttack : MineState {
	public override void Update() {
		// do nothing
	}
}
[System.Serializable]
public class MineStateDetect : MineState {
	[System.NonSerialized]
	public Material blinkMat;
	
	public Color onColor;
	public Color offColor;
	public AnimationCurve blinkCurve;

	float detectTime;

	public override void Enter() {
		detectTime = Time.time;
	}
	public override void Update() {
		var time = Time.time - detectTime;
		var blinkyness = blinkCurve.Evaluate(time);
		blinkMat.SetColor("_EmissionColor", Color.Lerp(offColor, onColor, blinkyness));
		if (blinkCurve.length <= time) {
			// start chasing?
		}
	}
}