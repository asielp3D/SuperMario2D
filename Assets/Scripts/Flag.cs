using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void Touch()
    {
        boxCollider.enabled = false;
        sfxManager.Bandera();
        soundManager.StopBGM();
    }
}
