using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAmbiance : MonoBehaviour
{
    //Variables for holding audio
    private AudioSource audioSource;
    public AudioClip ambianceMenuSound;

    private void Start()
    {
        //Sets and plays the audiosource component
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambianceMenuSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("menuAmbiance");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
