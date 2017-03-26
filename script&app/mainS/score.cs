using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {
    //UI関係
    //スコア
    public static int scoresu;
    //タイムテキスト
    public Text timeT;
    public float nowTime;
    private float endTime;
    //スコアテキスト
    public Text sc;
	// Use this for initialization
	void Start () {
        scoresu =0;
        endTime = 15;
        nowTime = endTime;
	}	
	// Update is called once per frame
	void Update () {
        //メインシーンの時
        if (globalm.state == 1)
        {
        //スコア表示
           sc.text = "Score:" + scoresu;
        //時間表示
            timeT.text = "Time:" + (int)nowTime;
            nowTime -= Time.deltaTime;
        //時間が無くなったら
            if (nowTime <= 0)
            {
                //リザルトシーンへ
                SceneManager.LoadScene("rezalt");
            }
        }
	}
}
