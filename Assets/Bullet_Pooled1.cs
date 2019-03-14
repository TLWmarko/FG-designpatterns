using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pooled1 : MonoBehaviour
{
	Rigidbody rb;
	float speed = 22f;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}
	
	public void Launch() {
		rb.velocity = transform.forward * speed;
		StopAllCoroutines();
		StartCoroutine(ReturnToPoolAfterAWhile());
	}

	IEnumerator ReturnToPoolAfterAWhile() {
		yield return new WaitForSeconds(3f);
		pool.ReturnBullet(poolIndex);
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.collider.GetComponent<Player>() != null) {
			Destroy(collision.gameObject);
		}
	}

	[System.NonSerialized]
	public Gun_Pooled1 pool;
	[System.NonSerialized]
	public int poolIndex;
}
