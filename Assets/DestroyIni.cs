using UnityEngine;
using System.Collections;

public class DestroyIni : MonoBehaviour {

    public GameObject explosion;
    public AudioSource explosionSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
            UnitySampleAssets._2D.PlatformerCharacter2D.poin2 = 50;

            Instantiate(explosion, transform.position, transform.rotation);
            explosionSound.Play();
        }
    }
}
