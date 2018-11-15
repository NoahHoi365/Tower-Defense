using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScript : MonoBehaviour {

    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
        
}
