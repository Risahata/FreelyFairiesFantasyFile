using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naibusosa : MonoBehaviour {
    //妖精一体一体の内部
    [SerializeField]
    raypoint raypo;
    MotionY1 mon;
    SpriteRenderer sp;
    SphereCollider sco;
    private bool sw;

    //出現してからの時間
    private float nowTime;
    private float endTime;
    Vector3 seiseipos;
    Vector3 mokuhyopos;
    //個体値
    public int ne;
    //動きの切り替える時間
    private float[] kiri = new float[2];
	// Use this for initialization
	void Start () {
        //妖精のモーション
        mon =GetComponent<MotionY1>();
        sp = GetComponent<SpriteRenderer>();
        sco = GetComponent<SphereCollider>();
        //初期状態のフラグ
        mon.enabled = false;
        sp.enabled = true;
        sco.enabled = false;
        sw = false;
        nowTime = 0;
        endTime = 5;
        //妖精のランダムな動き
        seiseipos = gameObject.transform.position;
        mokuhyopos = new Vector3(Random.Range(seiseipos.x - 1, seiseipos.x + 1), Random.Range(seiseipos.y - 1, seiseipos.y + 1), gameObject.transform.position.z);
        kiri[0] = 0;
        kiri[1] = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //発見された
        if (raypoint.kirikaeflag == true)
        {
            mon.enabled = true;
            sp.enabled = false;
            sco.enabled = true;
            //発見されたsw
            sw = true;
        }   
        //スイッチがオンになった状態で
        swon();
        if (sw == true)
        {
            ugoki();
        }
	}
    //妖精のランダムな動き
    void ugoki()
    {
        kiri[0] += Time.deltaTime;
        //滑らかに動く
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mokuhyopos, 1 * Time.deltaTime);
        //時間ごとに場所の更新
        if (kiri[0] > kiri[1])
        {
            //場所をランダムで更新
            mokuhyopos = new Vector3(Random.Range(seiseipos.x - 1, seiseipos.x + 1), Random.Range(seiseipos.y - 1, seiseipos.y + 1), gameObject.transform.position.z);
            kiri[0] = 0;
        }
    }
    void swon()
    {  
        //発見されてなかったら 
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
