using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public KeyCode forwardKey;
	public KeyCode backKey;
	public KeyCode turnLeftKey;
	public KeyCode turnRightKey;

	Rigidbody rb;
	float speed = 8f;
	float turnSpeed = 20f;
	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
