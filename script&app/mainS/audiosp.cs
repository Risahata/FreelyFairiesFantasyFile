using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosp : MonoBehaviour {
    //オーディオ関係
    public GameObject[] Aud;
    private AudioSource[] aus;
	// Use this for initialization
	void Start () {
        aus = new AudioSource[Aud.Length];
		for(int i = 0; i < Aud.Length; i++)
        {            
            aus[i] = Aud[i].GetComponent<AudioSource>();
        }
	}
    //オーディオを鳴らす場所
    public void auplay(int suu)
    {
        if (Aud[suu] != null)
        {
            aus[suu].PlayOneShot(aus[suu].clip);
        }
    }
}
