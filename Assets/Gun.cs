using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public KeyCode shootKey;
	public GameObject bullet;

	float shootTime;
	float shootInterval = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(shootKey)) {
			if (shootTime <= Time.time) {
				Instantiate(bullet, transform.position, transform.rotation);
				shootTime = Time.time + shootInterval;
			}
		}
    }
}
