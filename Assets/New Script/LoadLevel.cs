using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
    public GameObject level2, level3,gembok1,gembok2;
	// Use this for initialization
	void Start () {
        //level2.SetActive(false);
        //level3.SetActive(false);
        //gembok1.SetActive(true);
        //gembok2.SetActive(true);
        //LevelProgress.Load();


        //untuk tes presentasi
        level2.SetActive(true);
        gembok1.SetActive(false);
        level3.SetActive(true);
        gembok2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelProgress.level.Count == 1) {
            level2.SetActive(true);
            gembok1.SetActive(false);
        }
        if (LevelProgress.level.Count == 2) {
            level2.SetActive(true);
            gembok1.SetActive(false);
            level3.SetActive(true);
            gembok2.SetActive(false);
        }
	}
}
