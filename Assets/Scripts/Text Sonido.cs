using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSonido : MonoBehaviour
{
    private bool sound;
    public TextMeshProUGUI TextSound;

    // Start is called before the first frame update
    void Start()
    {
        sound=false;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SoundState(){
        if(sound){
            
            TextSound.text="Sonido: ON";
        }else{
            TextSound.text="Sonido: OFF";
        }
        AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.ToggleSFX();

        sound=!sound;
    }
}
