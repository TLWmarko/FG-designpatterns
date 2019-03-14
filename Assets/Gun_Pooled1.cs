using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pooled1 : MonoBehaviour
{
	public KeyCode shootKey;
	public GameObject bullet;

	float shootTime;
	float shootInterval = 0.1f;

	Bullet_Pooled1[] bulletPool = new Bullet_Pooled1[10];
	int bulletPoolFreeIndex = 0;

	void Start() {
		for(int i = 0; i < bulletPool.Length; i++) {
			bulletPool[i] = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet_Pooled1>();
			bulletPool[i].pool = this;
			bulletPool[i].gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKey(shootKey)) {
			if (shootTime <= Time.time && bulletPoolFreeIndex < bulletPool.Length) {
				bulletPool[bulletPoolFreeIndex].transform.position = transform.position;
				bulletPool[bulletPoolFreeIndex].transform.rotation = transform.rotation;
				bulletPool[bulletPoolFreeIndex].poolIndex = bulletPoolFreeIndex;
				bulletPool[bulletPoolFreeIndex].gameObject.SetActive(true);
				bulletPool[bulletPoolFreeIndex].Launch();
				bulletPoolFreeIndex++;
				shootTime = Time.time + shootInterval;
			}
		}
    }

	public void ReturnBullet(int index) {
		bulletPoolFreeIndex--;
		var tempBullet = bulletPool[index];
		bulletPool[index] = bulletPool[bulletPoolFreeIndex];
		bulletPool[index].poolIndex = index;
		bulletPool[bulletPoolFreeIndex] = tempBullet;
		bulletPool[bulletPoolFreeIndex].gameObject.SetActive(false);
	}
}
