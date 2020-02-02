using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip rotateSound;
    static AudioSource audioSource;
    void Start()
    {
        //rotateSound = Resources.Load<AudioClip>("rotate");

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.PlayOneShot(rotateSound);
        }

    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "rotate":
                audioSource.PlayOneShot(rotateSound);
                break;
        }
    }
}
