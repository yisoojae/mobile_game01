using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip[] audio00;
    byte musicN, tmp_int;
    // Start is called before the first frame update
    void Start()
    {
        musicN = (byte)Random.Range(0, audio00.Length);
        GetComponent<AudioSource>().clip = audio00[musicN];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            tmp_int = (byte)Random.Range(0, audio00.Length);
            if (tmp_int == musicN) tmp_int++;
            musicN = tmp_int;
            GetComponent<AudioSource>().clip = audio00[musicN];
            GetComponent<AudioSource>().Play();
        }
    }
}
