using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private float movx, movy;
    private bool jump;

    private Vector2 forceVector;
    private Rigidbody2D rb;
    public Animator anim;
    private float forceMultiplayer,jumpMultiplayer;

    //Limitacion de salto
    //Raycas, OverlapCircle
    private bool canjump = false;
    private Collider2D groundcollider;
    private byte stateOfJumps;
    private RaycastHit2D[] raycastHits= new RaycastHit2D[2];
    public bool jumpSelector;
    public Transform[] checkPoint;
    public LayerMask layerMask;
    public float[] checkRadius;
    private byte numOfJumps;


    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        forceMultiplayer = 12;
        jumpMultiplayer = 6;
        numOfJumps = 2;
        stateOfJumps = numOfJumps;
    }

    // Update is called once per frame
    void Update()
    {

        movx = Input.GetAxis("Horizontal");
        movy = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        anim.SetFloat("Speedx", Mathf.Abs(movx+movy));

        //Movimiento
        if(movx < 0f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }else{
            transform.localScale = new Vector3(1f,1f,1f);
        }
        
        //Salto
        if(jumpSelector){
            if(groundcollider != null){
                canjump = true;
                stateOfJumps = numOfJumps;
            }else{
                canjump = false;
            }
        }
        else{
            if(raycastHits[0] || raycastHits[1] ){
                canjump = true;
                stateOfJumps = numOfJumps;
            }else{
                canjump = false;
            }
        }

        if(canjump){
             anim.SetBool("JumpAnim", false);
        }
        
    }

   private void FixedUpdate() {
        forceVector = new Vector2(movx,0f) * forceMultiplayer;
        rb.AddForce(forceVector, ForceMode2D.Force);

        if(jump){
            if(canjump || stateOfJumps > 0){
                anim.SetBool("JumpAnim", true);
                rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);
                stateOfJumps -= 1;
            }
           
        }

        groundcollider = Physics2D.OverlapCircle((Vector2)checkPoint[0].position,checkRadius[0], layerMask);

        raycastHits[0] = Physics2D.Raycast((Vector2)checkPoint[1].position,Vector2.down, checkRadius[1],layerMask);
        raycastHits[1] = Physics2D.Raycast((Vector2)checkPoint[2].position,Vector2.down, checkRadius[1],layerMask);

        //UnityEngine.Debug.Log(collider);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
        }else if(other.gameObject.CompareTag("Finish")){
            other.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
