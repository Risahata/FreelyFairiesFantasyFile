using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleour : MonoBehaviour {
    //自動で消えるパーティクル
    float nowTime;
    float endTime;
	// Use this for initialization
	void Start () {
        nowTime = 0;
        endTime = 2;
	}	
	// Update is called once per frame
	void Update () {
        nowTime += Time.deltaTime;
        if (nowTime > endTime)
        {
            Destroy(gameObject);
        }
	}
}
