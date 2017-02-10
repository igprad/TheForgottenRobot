using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerStart : MonoBehaviour {

	private DialogManager dMan;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		string dialog = "Selamat Bermain Temukan jalan keluar dari labirin ini :D";
		//dMan.ShowBox (dialog);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//dMan.CloseBox ();
	}
}
