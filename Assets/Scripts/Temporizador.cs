using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Temporizador : MonoBehaviour
{
    public float tiempoMaximo;
    public float tiempoActual;
    private bool tiempoActivado = false;
    private Vida vida;
    public Slider slider;
    public MeterScript meterScript;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        ActivarTemporizador();
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoActivado){
            CambiarContador();
        }
    }

    private void CambiarContador(){
        //Debug.Log("tiempoActual");
        //Debug.Log(tiempoActual);
        tiempoActual -= Time.deltaTime;
        if(tiempoActual >= 0){
            slider.value = tiempoActual;
            meterScript.SetHealth(tiempoActual);
        }

        if(tiempoActual <= 0)
        {
            //Debug.Log("Derrota");
            vida.TomarVida(vida.maximoVida);
            CambiarTemporizador(false);
        } 
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    private void ActivarTemporizador(){
        tiempoActual = tiempoMaximo;
        slider.value = tiempoMaximo;
        meterScript.SetMaxHealth(tiempoMaximo);
        CambiarTemporizador(true);
    }

    private void DesactivarTemporizador()
    {
        
        CambiarTemporizador(false);
    }

}
