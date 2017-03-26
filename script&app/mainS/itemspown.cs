using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspown : MonoBehaviour {
    //クローバーオブジェクト
    // 0 三つ葉　１ 四葉　2 いつつば
    public GameObject[] clover;
    //一秒ごとに出現判定
    private int syuturan;
    //出現するクローバーの倍率
    private int kurobai;
    //秒数
    private float nowTime;
    private float endTime;
    //個体別name
    private int suu;
    //ランダムな場所
    private Vector2 ranpos;
	// Use this for initialization
	void Start () {
        nowTime =0;
        endTime = 1;
        suu = 0;
	}	
	// Update is called once per frame
	void Update () {
        //アイテムが３個以下だったら出現するかどうかの判定へ
        if (tagc() < 3)
        {
            nowTime += Time.deltaTime;
            if (nowTime > endTime)
            {
                syuturan = Random.Range(1, 100);
                //出現確率は１０分の３
                if (syuturan > 70)
                {
                    //出現
                    spown();
                }
                nowTime = 0;
            }
        }
	}
    //タグチェックアイテムが何個あるか
    int tagc()
    { 
        GameObject[] tagcount = GameObject.FindGameObjectsWithTag("item");   
        return tagcount.Length;
    }
    void spown()
    {
        //ランダムな出現ポイントの取得
        ranpos = new Vector2(Random.Range(gameObject.transform.position.x - 2, gameObject.transform.position.x + 2), Random.Range(gameObject.transform.position.y - 2, gameObject.transform.position.y + 2));
        kurobai = Random.Range(1, 100);
        GameObject kara;
        if (kurobai > 70)
        {
            //四葉　ポイントゲット
            kara = (GameObject)Instantiate(clover[1], ranpos, transform.rotation);
            kara.name = "clover1ver" + suu;
        }
        else if (kurobai > 20)
        {
            //三つ葉　秒数引き伸ばし
            kara = (GameObject)Instantiate(clover[0], ranpos, transform.rotation);
            kara.name = "clover0ver" + suu;
        }
        else
        {
            //いつつば　ポイントマイナス
            kara = (GameObject)Instantiate(clover[2], ranpos, transform.rotation);
            kara.name = "clover2ver" + suu;
        }
        suu++;
    }
}
