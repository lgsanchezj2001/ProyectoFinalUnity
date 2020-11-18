using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void returnMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
