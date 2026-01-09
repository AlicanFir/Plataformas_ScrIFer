using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Patron Singleton
    // 1. Que solo exista uno.
    // 2. Accesible desde cualquier punto del programa.
        
    //los singletons se usan cuando quieras guardar datos.
        
    public static AudioManager instance; //Trono
    // algo "static" pertenece a la clase y no a las instancias
        
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
        

    private void Start()
    {
        //si el trono esta vacio, yo reclamo el trono y vivo entre escenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //vive entre las escenas. No se destruye.
        }
        else //si llego tarde al trono me da depresion y me autodestruyo
        {
            Destroy(gameObject);
        }

        musicSource = GetComponent<AudioSource>();
    }
    
    public void PlaySFX(AudioClip jumpSound)
    {
        sfxSource.PlayOneShot(jumpSound);
    }
}