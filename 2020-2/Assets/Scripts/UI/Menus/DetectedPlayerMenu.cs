using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPlayerMenu : MonoBehaviour
{
    public GameObject playerMenu,gameOver,gameWin,win,player;
    private bool isActive;

    private void Start() {
        isActive = false;
    }
    
    void Update()
    {

        if(Input.GetButtonDown("Cancel")){
            if(!isActive){
                playerMenu.SetActive(true);
                isActive = true;
                Time.timeScale = 0f;
            }else{
                playerMenu.SetActive(false);
                isActive = false;
                Time.timeScale = 1f;
            }
        }
        if(player.GetComponent<Collider2D>().isTrigger){
            Debug.Log("GameOVer");
            StartCoroutine(LoadLevel(1));
        }
        if(win.GetComponent<Collider2D>().isTrigger == false){
            Destroy(win);
            StartCoroutine(LoadLevel(2));
        }
    }


    public IEnumerator LoadLevel(int option){
        //Esperar y cambiar
        yield return new WaitForSeconds(1);

        if(option == 1){
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }else if(option == 2){
            gameWin.SetActive(true);
            Time.timeScale = 0f;
        }
         
    }

}
