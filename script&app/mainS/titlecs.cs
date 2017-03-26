using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class titlecs : MonoBehaviour {
    //タップでタイトルキャンバスフェード
    //タイトルキャンバスオブジェクト
    [SerializeField]
    GameObject titleC;
    //タイトルキャンバスの子供
    private GameObject[] titleCim=new GameObject[3];
    private Image[] titleim = new Image[3];
    private Color[] Cc = new Color[3];
    //透明度
    private float touka;
    private float nowTime;
    private float endTime;
    //タイトル状態
    private int state;
    //タイトルのアニメーション
    //一秒後にボタン押してよい
    private float[] onetime = new float[2];
    public Animator tim;
	// Use this for initialization
	void Start () {      
        //gameobjectを探す
        titleCim[0] = titleC.transform.Find("titleim").gameObject;
        titleCim[1] = titleC.transform.Find("logoim").gameObject;
        titleCim[2] = titleC.transform.Find("tiji").gameObject;
        touka = nowTime / endTime;
        for(int i = 0; i < titleCim.Length; i++)
        {
            titleim[i] = titleCim[i].GetComponent<Image>();
            Cc[i] = titleim[i].color;
            Cc[i].a = touka;
        }
        state = -1;
        onetime[0] = 0;
        onetime[1] = 1;
	}	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case -1:
                //起動後すぐには反応しないように
                onetime[0] += Time.deltaTime;
                if (onetime[0] > onetime[1])
                {
                    state++;
                }        
                break;
            case 0:
                //アニメーションを実行
                tim.SetBool("sw", true);
                if (Input.GetMouseButtonDown(0))
                {             
                    nowTime = 1;
                    endTime = 1;
                    state++;
                }
                break;
            case 1:
                //フェードを実行
                nowTime -= Time.deltaTime;
                touka = nowTime / endTime;
                for(int i = 0; i < titleCim.Length; i++)
                {
                    Cc[i] = titleim[i].color;
                    Cc[i].a = touka;
                    titleim[i].color = Cc[i];
                }
                if (nowTime < 0)
                {
                    state++;
                }
                break;
            case 2:        
                state++;
                //メインモードへ
                globalm.state = 1;           
                break;
            default:
                break;
        }
      
	}
}
