using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
 {
    public Animator anim;
    public void playGame(){
        //Activar animacion
        anim.SetTrigger("Start");

        //Invocar corrutina 
        StartCoroutine(LoadLevel(1));
    }

    public void quitGame(){
        Application.Quit();
    }

    public IEnumerator LoadLevel(int buildIndex){

        //Esperar y cambiar
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(buildIndex);
    }
}
