using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPlayerMenu : MonoBehaviour
{
    public GameObject playerMenu;
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
    }
}
