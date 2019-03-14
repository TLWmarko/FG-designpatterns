using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	float speed = 22f;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);

		Destroy(gameObject, 5f);
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.collider.GetComponent<Player>() != null) {
			Destroy(collision.gameObject);
		}
	}
}
