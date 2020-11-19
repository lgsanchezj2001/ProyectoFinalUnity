using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject Objects;

    Text text;
    float timer;
    int countDownNumber = 60;

    //Valores del Player
    private Collider2D collider;
    private Rigidbody2D rigidbody;
    private Animator anim;

    //Inicialización de variables
    void Start() {
        text = GetComponent<Text>();
        text.text = countDownNumber.ToString();
        collider = Objects.GetComponent<Collider2D>();
        rigidbody = Objects.GetComponent<Rigidbody2D>();
        anim = Objects.GetComponent<Animator>();
    }

    //Metodo de actualización y verificacion de cronometro
    //cuando llegue a cero y el jugador no a llegado pierde
    void Update() {
        timer += Time.deltaTime;
        if(timer >= 1 && countDownNumber > 0){
            countDownNumber--;
            text.text = countDownNumber.ToString();
            timer = 0;
        }

        if(text.text == "0"){
            anim.SetBool("MarioDead", true);
            Debug.Log("Muerte");
            collider.isTrigger = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 5f);
        }
      
    }

}
