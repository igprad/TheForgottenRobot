using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UINavigator : MonoBehaviour {

    public void GoToMainMenu() 
    {

        SceneManager.LoadScene("Main Menu");
    }

    public void GoToSelectLevel()
    {
        SceneManager.LoadScene("Select Level");
    }

    public void Exit() {
        Application.Quit();
    }

    public void GoToLevel3() {
        SceneManager.LoadScene("Level 3");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }


}
