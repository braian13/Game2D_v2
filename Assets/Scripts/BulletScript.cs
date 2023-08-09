using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 Direccion;
    private Vida vida;
    public float cantidadDano;

    private patrullaje enemy;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();
        vida=FindObjectOfType<Vida>();
        enemy=FindObjectOfType<patrullaje>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigidbody2D.velocity=Direccion * speed;
    }

    public void SetDirection(Vector2 direction){
        
        Direccion=direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(vida!=null){
            if(other.CompareTag("Player"))
        {
            vida.TomarVida(cantidadDano);
            vida.efectoDano(new Vector2(transform.position.x,transform.position.y), 0f);
            Destroy(gameObject);
        }
        }
        
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemy.Destroy();
        }
    }
}
