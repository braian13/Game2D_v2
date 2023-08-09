using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                    Debug.Log("DañoEspinas");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Debug.Log("Daño");
        }
    }
}
