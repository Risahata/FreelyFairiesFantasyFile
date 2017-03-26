using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raypoint : MonoBehaviour {
    [SerializeField]
    score Sc;
    //public GameObject obname;
    //おしたオブジェクトごとの処理分割
    //0 何もしない　1　player
    private int syu;
    //切り替えフラグ
    public static bool kirikaeflag;
    //秒カウンター
    private float nowTime;
    private float endTime;
    private bool kirikae;
    [SerializeField]
    audiosp aud;
    public GameObject[] seiseipar = new GameObject[5];
	// Use this for initialization
	void Start () {
        kirikae = false;
        nowTime = 0;
        //２秒間探索する
        endTime = 2;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obname = GetCurrentHitCollider();
            if (obname != null)
            {
                namehan(obname);
            }          
        }       
        jikanc();     
	}
    //あたったオブジェクトnameがplayerだったとき
    void nameplayer()
    {
        kirikaeflag = true;
       kirikae=true;
    }
    //kirikaeからの時間カウンター
    void jikanc()
    {
        if (kirikae == true)
        {
            nowTime += Time.deltaTime;
            if (nowTime > endTime)
            {
                nowTime = 0;
                kirikaeflag = false;
                kirikae = false;
            }
        }
    }
    //名前判定
    void namehan(GameObject obname)
    {
        switch (obname.name)
        {
            case "player":
                if (kirikae == false)
                {
                    aud.auplay(1);
                    //サーチパーティクル発生
                    Instantiate(seiseipar[4], new Vector3(obname.transform.position.x-0.5f,obname.transform.position.y,obname.transform.position.z-4), obname.transform.rotation);
                }
                nameplayer();
                break;
            case "null":
                break;
            default:
                aud.auplay(0);
                if (obname.name.Contains("clover0ver"))
                {
                    //三つ葉
                    Instantiate(seiseipar[3], obname.transform.position, obname.transform.rotation);
                    //時間プラス
                    Sc.nowTime =Sc.nowTime+5;
                }else if (obname.name.Contains("clover"))
                {
                    //４つばor５つば
                    Instantiate(seiseipar[3], obname.transform.position, obname.transform.rotation);
                    naibuitem nn = obname.GetComponent<naibuitem>();
                    //スコア反映
                    score.scoresu = nn.ne + score.scoresu;
                }         
                else {
                    //オブジェクトのタグによって生成するパーティクルに違い
                    //妖精
                    switch (obname.tag)
                    {
                        case "enemy0":
                            Instantiate(seiseipar[0], obname.transform.position, obname.transform.rotation);
                            break;
                        case "enemy1":
                            Instantiate(seiseipar[1], obname.transform.position, obname.transform.rotation);
                            break;
                        case "enemy2":
                            Instantiate(seiseipar[2], obname.transform.position, obname.transform.rotation);
                            break;
                    }
                    //ポイント関係
                    naibusosa nn = obname.GetComponent<naibusosa>();
                    score.scoresu = nn.ne + score.scoresu;
                }
                Destroy(obname);
                break;
        }
    }
    public static GameObject GetCurrentHitCollider()
    {
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject s = hit.collider.gameObject;
            return s;
        }
        else
        {
            return null;
        }
    }
}
