using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public KeyCode forwardKey;
	public KeyCode backKey;
	public KeyCode turnLeftKey;
	public KeyCode turnRightKey;

	public KeyCode shootKey;
	public Gun gun;

	Rigidbody rb;
	float speed = 8f;
	float turnSpeed = 20f;

	bool alive = true;
	float killTime;
	Renderer[] renderers;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		renderers = GetComponentsInChildren<Renderer>();
    }
	

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(shootKey)) {
			if (killTime <= Time.time) {
				if(alive)
					gun.Shoot();
				else
					Respawn();
			}
		}

		if(!alive)
			return;

		if(Input.GetKey(forwardKey)) {
			rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
		}
		else if(Input.GetKey(backKey)) {
			rb.AddRelativeForce(Vector3.back * speed, ForceMode.Acceleration);
		}

		if(Input.GetKey(turnLeftKey)) {
			rb.AddRelativeTorque(Vector3.down * turnSpeed, ForceMode.Acceleration);
		}
		else if(Input.GetKey(turnRightKey)) {
			rb.AddRelativeTorque(Vector3.up * turnSpeed, ForceMode.Acceleration);
		}
	}

	public void Kill() {
		killTime = Time.time + 1f;
		rb.isKinematic = true;
		rb.detectCollisions = false;
		foreach(var r in renderers) {
			r.enabled = false;
		}
		alive = false;
	}

	void Respawn() {
		rb.isKinematic = false;
		rb.detectCollisions = true;
		foreach(var r in renderers) {
			r.enabled = true;
		}
		alive = true;
		killTime = Time.time + 0.5f;

		var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		var selectedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		transform.position = selectedPoint.transform.position;
		transform.rotation = selectedPoint.transform.rotation;
	}
}
