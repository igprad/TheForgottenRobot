using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class SceneController : MonoBehaviour
{
    public GameObject panel;
   
    Animator animator;
    float fireRate;
    bool status_pause;
    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (status_pause == false) {
            panel.SetActive(false);
            Time.timeScale = 1;
            
        }

        else if (status_pause == true) {
            panel.SetActive(true);
            Time.timeScale = 0;
   
        }
    }

    public void setPanelNonAKtif()
    {
        status_pause = false;
    }

    public void setPanelAktif()
    {

        status_pause = true;
    }



    //IEnumerator Pause()
    //{
    //    animator.SetTrigger("Open");
    //    yield return new WaitForSeconds(0.5f);
    //    Time.timeScale = 0;
    //}

}


