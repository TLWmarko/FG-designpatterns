using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	public MineStateDetect detectState;
	public MineStateIdle idleState;
	public MineStateAttack attackState;
	[System.NonSerialized]
	public MineState currentState;
	[System.NonSerialized]
	public Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		//think = Think;

		detectState.Start(this);
		idleState.Start(this);
		attackState.Start(this);

		currentState = idleState;
		currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
		currentState.Update();

		//think();
    }

	private void OnCollisionEnter(Collision collision) {
		var player = collision.collider.GetComponent<Player>();
		if(player != null) {
			player.Kill(null);
			Destroy(gameObject);
		}
	}

	/*
	System.Action think;
	void Think() {
		think = Think2;
	}

	void Think2() {

	}
	*/
}
