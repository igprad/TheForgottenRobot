using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowBox(string dialog)
	{
		dBox.SetActive (true);
		dText.text = dialog;
	}

	public void CloseBox()
	{
		dBox.SetActive (false);
	}
}
