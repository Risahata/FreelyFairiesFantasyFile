using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naibuitem : MonoBehaviour {
    //クローバの内部
    SpriteRenderer sp;
    SphereCollider sco;
    private bool sw;
    public Sprite[] cloversp = new Sprite[2];
    //出現してからの時間
    private float nowTime;
    private float endTime;
    //個体値
    public int ne;
    // Use this for initialization
    void Start () {  
        sp = GetComponent<SpriteRenderer>();
        sco = GetComponent<SphereCollider>();
        //スプライト代入
        sp.sprite = cloversp[0];
        sco.enabled = false;
        sw = false;
        //時間リセット
        nowTime = 0;
        endTime = 5;
    }	
	// Update is called once per frame
	void Update () {
        //発見されたら
        if (raypoint.kirikaeflag == true)
        {
            sp.sprite = cloversp[1];
            sco.enabled = true;
            sw = true;
        }
        //スイッチがオンになった状態で
        swon();
    }
    void swon()
    {
       //発見されてない
        if(sw==false)
        {
            //発見されない状態が続くと自動的に消える
            nowTime += Time.deltaTime;
            //出現してから５秒たったら
            if (nowTime > endTime)
            {
                nowTime = 0;
                //消える
                Destroy(gameObject);
            }
        }
    }
}
