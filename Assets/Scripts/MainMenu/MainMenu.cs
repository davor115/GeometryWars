using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public void StartButton()
    {
        SceneManager.LoadScene("mainscene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoBackButton()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("tutorial");
    }

}
