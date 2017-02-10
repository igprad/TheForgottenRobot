using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour {
    public Text txtnyawa;
    public Text txthealth;
    public static int nyawa = 3;
    public static decimal health = 100;
    public AudioSource loseSound;

    public GameObject window;
    public Text windowText;

    private int tempCounter = 0;

	// Use this for initialization
	void Start () {
        health = 100;
        nyawa = 3;
        txtnyawa.text = nyawa.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        txtnyawa.text = nyawa.ToString();
        if (health > 30)
            txthealth.color = Color.black;
        if (nyawa <= 0) {
            if (tempCounter == 0)
            {
                loseSound.Play();
                tempCounter = 1;
            }
            windowText.text = "\t\tGagal, Silahkan Pilih menu di bawah ini";
            window.GetComponent<Animator>().SetTrigger("Open");
        }
        txthealth.text = health.ToString();
        if (health <= 30) {
            txthealth.color = Color.red;
        }
        if (health <= 0)
        {
            nyawa--;
            health = 100;
            //nanti respawn su..........
        }
        
	}
    

}
