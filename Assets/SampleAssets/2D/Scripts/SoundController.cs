using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SoundController : MonoBehaviour {
    public AudioSource bunyi;
    public AudioSource bgm_main_menu;
    public GameObject soundcontrol;
    private bool cekHidup = true;
    private static int cekAda=1;
	// Use this for initialization
	void Start () {
        cekAda++;
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName != "Main Menu" && Application.loadedLevelName != "Select Level")
        {
            bgm_main_menu.Stop();
            cekHidup = false;
        }
        else if ((Application.loadedLevelName == "Main Menu" || Application.loadedLevelName == "Select Level")&&cekHidup==false) {
            bgm_main_menu.Play();
            cekHidup = true;
        }
        
	}

    void Awake()
    {
        if (cekAda == 1)
        {
            DontDestroyOnLoad(soundcontrol);
            return;
        }
        Destroy(soundcontrol);
        
    }

    
}
