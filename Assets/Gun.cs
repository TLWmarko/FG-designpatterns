using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject bullet;

	float shootTime;
	float shootInterval = 0.1f;
	

	//
	// Normal
	//
	public void Shoot() {
		if(shootTime <= Time.time) {
			Instantiate(bullet, transform.position, transform.rotation);
			shootTime = Time.time + shootInterval;
		}
	}
	




	//
	// Pooled 1
	//
	/*
	Bullet[] bulletPool = new Bullet[10];
	int bulletPoolFreeIndex = 0;

	void Start() {
		for(int i = 0; i < bulletPool.Length; i++) {
			bulletPool[i] = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>();
			bulletPool[i].poolOwner = this;
			bulletPool[i].gameObject.SetActive(false);
		}
	}
	
	public void Shoot() {
		if(shootTime <= Time.time && bulletPoolFreeIndex < bulletPool.Length) {
			bulletPool[bulletPoolFreeIndex].transform.position = transform.position;
			bulletPool[bulletPoolFreeIndex].transform.rotation = transform.rotation;
			bulletPool[bulletPoolFreeIndex].poolIndex = bulletPoolFreeIndex;
			bulletPool[bulletPoolFreeIndex].gameObject.SetActive(true);
			bulletPool[bulletPoolFreeIndex].Launch();
			bulletPoolFreeIndex++;
			shootTime = Time.time + shootInterval;
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
	*/

	//
	// Pooled 2
	//
	/*
	Bullet[] bulletPool = new Bullet[10];
	int bulletPoolFreeIndex = 0;

	void Start() {
		for(int i = 0; i < bulletPool.Length; i++) {
			bulletPool[i] = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>();
			bulletPool[i].poolOwner = this;
			bulletPool[i].gameObject.SetActive(false);
		}
	}
	
	public void Shoot() {
		if(shootTime <= Time.time) {
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
	*/
}
