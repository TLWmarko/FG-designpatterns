using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pooled2 : MonoBehaviour
{
	public KeyCode shootKey;
	public GameObject bullet;

	float shootTime;
	float shootInterval = 0.1f;

	Bullet_Pooled2[] bulletPool = new Bullet_Pooled2[10];
	int bulletPoolFreeIndex = 0;

	void Start() {
		for(int i = 0; i < bulletPool.Length; i++) {
			bulletPool[i] = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet_Pooled2>();
			bulletPool[i].pool = this;
			bulletPool[i].gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKey(shootKey)) {
			if (shootTime <= Time.time) {
				bulletPool[bulletPoolFreeIndex].transform.position = transform.position;
				bulletPool[bulletPoolFreeIndex].transform.rotation = transform.rotation;
				bulletPool[bulletPoolFreeIndex].poolIndex = bulletPoolFreeIndex;
				bulletPool[bulletPoolFreeIndex].gameObject.SetActive(true);
				bulletPool[bulletPoolFreeIndex].Launch();
				bulletPoolFreeIndex++;
				if(bulletPoolFreeIndex >= bulletPool.Length)
					bulletPoolFreeIndex = 0;
				shootTime = Time.time + shootInterval;
			}
		}
    }
}
