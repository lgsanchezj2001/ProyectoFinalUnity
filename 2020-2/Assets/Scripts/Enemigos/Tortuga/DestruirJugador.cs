using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirJugador : MonoBehaviour
{
    public Animator anim;

    public Rigidbody2D rigidbody;

    public GameObject Mario;
    private float countDown = 0.5f;

    private Collider2D collider;

    void Start() {
        collider = Mario.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Death();
            /*countDown -= Time.deltaTime;

            if(countDown > 0f){
                Invoke("Death",0f);
            }*/
        }
    }

    void Death(){
        anim.SetBool("MarioDead", true);
        Debug.Log("Muerte");
        collider.isTrigger = true;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 5f);
    }
}
