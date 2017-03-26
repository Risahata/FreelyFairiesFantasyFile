using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownsc : MonoBehaviour {
    //0 ふつう　1 レア　２　激レア
    public GameObject[] spownobj;
    //1から100までのランダムな値
    private int ransu;
    private float nowTime;
    private float endTime;
    //ランダムなポジション
    private Vector2 ranpos;
    //name判別
    private int suu;
    GameObject kara;
	// Use this for initialization
	void Start () {
        //初期化
        nowTime = 0;
        endTime = 1;
        suu = 0;
	}	
	// Update is called once per frame
	void Update () {
        //妖精の数が10以下ならば
        if (tagc() < 10)
        {
            nowTime += Time.deltaTime;
            //一秒ごとに生成
            if (nowTime > endTime)
            {
                //乱数とって
                ransu = Random.Range(1, 100);   
                //出現する妖精判別   
                ransuck(ransu);
                nowTime = 0;
            }
        }
	}
    //タグ探し何匹いるか？
    int tagc()
    {
        int goukei;
        GameObject[] tagcount0 = GameObject.FindGameObjectsWithTag("enemy0");
        GameObject[] tagcount1 = GameObject.FindGameObjectsWithTag("enemy1");
        GameObject[] tagcount2 = GameObject.FindGameObjectsWithTag("enemy2");
        goukei = tagcount0.Length+tagcount1.Length+tagcount2.Length;
        return goukei;
    }
    //ransuチェック
    void ransuck(int ran)
    {
        //ランダムな出現ポイントの取得
        ranpos = new Vector2(Random.Range(gameObject.transform.position.x - 2, gameObject.transform.position.x + 2), Random.Range(gameObject.transform.position.y - 2, gameObject.transform.position.y + 2));       
        if (ran >= 90)
        {
            //激レア
            kara=(GameObject)Instantiate(spownobj[0],ranpos,transform.rotation);
            kara.name = "fal" + suu;
        }else if (ran >= 60)
        {
            //レア
            kara=(GameObject)Instantiate(spownobj[1], ranpos, transform.rotation);
            kara.name = "fal" + suu;
        }
        else
        {
            //普通
            kara=(GameObject)Instantiate(spownobj[2], ranpos, transform.rotation);
            kara.name = "fal" + suu;
        }
        suu++;
    }
}
