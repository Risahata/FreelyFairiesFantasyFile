using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class rezaltMs : MonoBehaviour {
    //リザルトマネージャー
    //スコアによるimage変動
    public Image rezaltIm;
    public Sprite[] rI = new Sprite[2];
    //スコアを入れる箱
    private int sch;
    public Text scoreT;
    //0 un,1 very
    public GameObject[] unvery;
	// Use this for initialization
	void Start () {
        //メインシーンのスコアを持ってくる
        sch = score.scoresu;
        //スコアによってセットするimage判別
        if (sch >= 500)
        {
            //超ハッピー
            rezaltIm.sprite = rI[0];
            unvery[0].SetActive(false);
            unvery[1].SetActive(true);
        }
        else if(sch>0)
        {
            //普通       
            rezaltIm.sprite = rI[1];
            unvery[0].SetActive(false);
            unvery[1].SetActive(false);
        }
        else
        {
            //unhappy
            rezaltIm.sprite = rI[1];
            unvery[0].SetActive(true);
            unvery[1].SetActive(false);
        }
	}	
	// Update is called once per frame
	void Update () {
        //スコア反映
        scoreT.text = "" + sch;
	}
    //モウイチドボタン
    public void againb()
    {
        globalm.state = 1;
        SceneManager.LoadScene("main");        
    }
    //オワルボタン
    public void endb()
    {
        globalm.state = 0;
        SceneManager.LoadScene("main");        
    }
}
