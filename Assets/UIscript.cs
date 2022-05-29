using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class UIscript : MonoBehaviour
{
    
    public void StartButton()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
