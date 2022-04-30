using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int aplles;

    public AudioSource effectSource;
    public AudioSource musicSource;
    public AudioClip[] effectClip;
    public AudioClip[] musics;

    // Start is called before the first frame update
    void Start()
    {
        MusicPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Music manager
    void MusicPlay()
    {
        musicSource.PlayOneShot(musics[0]);
    }
}
