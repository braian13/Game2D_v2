using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colgar : MonoBehaviour
{
    [SerializeField] private LayerMask areaLayer;
    [SerializeField] private Transform poloAlto;
    [SerializeField] private float velColgado =1f;
    [SerializeField] private float Vel_antiGravedad=0.195f;

    protected Rigidbody2D _rigidbody2D;
    protected Animator _animator;


    protected float v;
    protected float h;
    private bool c;

    private Vector2 _move;
    private float hvel;
    private bool zonaColgante;
    public bool Colgado;

    private float radius= 0.02f;

    void Start()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();
        _animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LocalInput();
        Iniciar_Colgar();
        SetAnimation();
    }

    void FixedUpdate(){
        horizontalMove();
    }
    private void LocalInput()
    {
        v=Input.GetAxisRaw("Vertical");
        c=Input.GetKey(KeyCode.Space);
        h=Input.GetAxisRaw("Horizontal");
    }

    private void AreaCollision(){
        zonaColgante= Physics2D.OverlapCircle(poloAlto.position,radius,areaLayer);
    }

    public void Iniciar_Colgar(){
        AreaCollision();
        if(zonaColgante && c){
            Colgado=true;
        }
        if(!zonaColgante){
            Colgado=false;
        }
    }

    protected void horizontalMove(){
        _move = new Vector2(h,0.0f);
        if(Colgado){
            if(h==0.0f){
                _rigidbody2D.velocity=new Vector2(0f,Vel_antiGravedad);
            }
            if(h!=0.0f){
                _rigidbody2D.velocity=new Vector2(_move.normalized.x*velColgado,Vel_antiGravedad);
            }
            if(c && v<0.0f){
                Colgado=false;
            }
        }
    }

    public void SetAnimation(){
        _animator.SetBool("Colgado",h==0 && Colgado);
        _animator.SetBool("MovimientoColgado",h!=0 && Colgado);
    }
    
}
