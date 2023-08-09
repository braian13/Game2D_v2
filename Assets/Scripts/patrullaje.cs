using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class patrullaje : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float TiempoEspera = 2f;
    public float Velocidad = 1f;
    private float EVelocidad = 1f;
    private GameObject lugarObjetivo;

    public GameObject BulletPrefab;
    public GameObject john;
    private Animator animator;
    

    private float lastShoot;


    // Start is called before the first frame update
    void Start()
    {
        EVelocidad = Velocidad;
        UpdateObjetivo();
        StartCoroutine("Patrullar");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (john != null)
        {
            float distancia = math.abs(john.transform.position.x - transform.position.x);
            if (distancia < 0.5f)
            {
                animator.SetBool("Patrullaje",false);
                Vector3 direccion = john.transform.position - transform.position;
                Velocidad = 0;
                if (direccion.x >= 0f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                if (Time.time > lastShoot + 1f)
                {
                    shoot();
                    lastShoot = Time.time;
                }
            }
            else
            {
                animator.SetBool("Patrullaje",true);
                Velocidad = EVelocidad;
            }
        }
    }

    private void shoot()
    {
        Vector3 direccionBala;
        if (transform.localScale.x == 1f)
        {
            direccionBala = Vector3.right;
        }
        else
        {
            direccionBala = Vector3.left;
        }
        AudioManager.Instance.PlaySFX("shoot");
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direccionBala * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direccionBala);

    }

    private void UpdateObjetivo()
    {
        if (lugarObjetivo == null)
        {
            lugarObjetivo = new GameObject("Sitio_objetivo");
            lugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            //transform.localScale = new Vector3(-1,1,1);
            return;
        }

        if (lugarObjetivo.transform.position.x <= minX)
        {
            lugarObjetivo.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (lugarObjetivo.transform.position.x >= maxX)
        {
            lugarObjetivo.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator Patrullar()
    {
        while (Vector2.Distance(transform.position, lugarObjetivo.transform.position) > 0.05f)
        {
            Vector2 direction = lugarObjetivo.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * Velocidad * Time.deltaTime);

            yield return null;
        }

        //Debug.Log("Se alcanzo el Objetivo");
        transform.position = new Vector2(lugarObjetivo.transform.position.x, transform.position.y);

        //Debug.Log("Esperando " + TiempoEspera + " Segundos");
        yield return new WaitForSeconds(TiempoEspera);

        //Debug.Log("Se espera lo que necesario para que termine y vuelva a empezar movimiento");
        UpdateObjetivo();
        StartCoroutine("Patrullar");

    }

    public void Destroy(){
        Destroy(gameObject);
    }

}
