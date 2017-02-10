using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	private bool isShotNormal = false;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public bool shotnormalbtn;
	private float nextFire;

	// Use this for initialization
	void Start () {
		shotnormalbtn = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//if (Input.GetButton ("Fire1") && Time.time > nextFire){
		if (shotnormalbtn==true && Time.time > nextFire){ //&& isShotNormal == true) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
		*/
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		/*
		if (other.tag == "Player") {
			//nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
		*/
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void shotdownTrue() {
		shotnormalbtn = true;
	}

	public void shotdownFalse() {
		shotnormalbtn = false;
	}
}
