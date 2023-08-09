using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float JumpForce;
    public float Speed;
    private bool Grounded;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;


    [Header("Animator")]
    private Animator animator;

    void Start()
    {
        animator=GetComponent<Animator>();

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Console.Write("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        
        if(Horizontal < 0.0f){
            transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        }else{
            transform.localScale=new Vector3(1.0f,1.0f,1.0f);

        }

        Debug.DrawRay(transform.position,Vector3.down*0.1f,Color.red);
        if(Physics2D.Raycast(transform.position,Vector3.down,0.1f)){
            Grounded=true;
        }else{
            Grounded=false;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded){
            Jump();
        }

        //animator.SetFloat("moveSpeed",Mathf.Abss());
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity =  new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
}
