using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private float movx, movy, jump;

    private Vector2 forceVector;
    private Rigidbody2D rb;
    public Animator anim;
    private float forceMultiplayer,jumpMultiplayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forceMultiplayer = 12;
        jumpMultiplayer = 1;
    }

    // Update is called once per frame
    void Update()
    {

        movx = Input.GetAxis("Horizontal");
        movy = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        anim.SetFloat("Speedx", Mathf.Abs(movx+movy));


        if(movx < 0f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }else{
            transform.localScale = new Vector3(1f,1f,1f);
        }
        

        forceVector = new Vector2(movx,0f) * forceMultiplayer;
        rb.AddForce(forceVector, ForceMode2D.Force);

        if(jump > 0){
            rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);
        }
    }
}
