using UnityEngine;
using System.Collections;
using System;

public class DestroyEnemy : MonoBehaviour {

    public AudioSource hitSound;
    int temp;
	// Use this for initialization
	void Start () {
        /*
        GameObject coreGameObject = GameObject.FindGameObjectsWithTag("CoreGame");
        if (coreGame != null)
        {
            coreGame = 
        }
         */
         temp = CoreGame.nyawa;
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            hitSound.Play();
            CoreGame.health -= 50;

            if (50+CoreGame.health-50<=0) {
                
                UnitySampleAssets._2D.PlatformerCharacter2D.mati = true;
            }
        }
    }
}
