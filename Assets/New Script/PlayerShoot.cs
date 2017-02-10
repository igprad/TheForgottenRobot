using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	private bool isShotNormal = false;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
    public bool shotnormalbtn;
	private float nextFire;
    public AudioSource shotSFX;
	// Use this for initialization
	void Start () {
        shotnormalbtn = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButton("Fire1") && Time.time > nextFire)
		if (shotnormalbtn==true && Time.time > nextFire){ //&& isShotNormal == true) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			shotSFX.Play ();
		}
	}

    public void shotdownTrue() {
        shotnormalbtn = true;
    }

    public void shotdownFalse() {
        shotnormalbtn = false;
    }
}
