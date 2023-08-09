using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecionNivel : MonoBehaviour
{

    public void CambiarNivel(String nombreNivel){
        SceneManager.LoadScene(nombreNivel);
    }
    public void CambiarNivel(int numeroNivel){
        AudioManager.Instance.PlaySFX("Select");
        SceneManager.LoadScene(numeroNivel);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
