using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance;
    public AudioClip[] clips;
    AudioSource source;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            source = this.GetComponent<AudioSource>();
            source.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this);
    }

}
