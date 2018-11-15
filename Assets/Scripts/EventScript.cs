using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
    public AudioSource talk;
    public GameObject RobotEasterEgg;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator RobotDestruct()
    {
        talk.Play();
        yield return new WaitForSeconds(3.13f);
        GameObject.Destroy(RobotEasterEgg);
    }

    public void RobotDestructButton()
    {
        StartCoroutine(RobotDestruct());
    }


}