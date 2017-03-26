using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalm : MonoBehaviour {
    //タイトルとメインの統合のためスクリプトのオンオフ
    public static int state;
    [SerializeField]
    titlecs tc;
    [SerializeField]
    raypoint rp;
    [SerializeField]
    spownsc spown;
    public GameObject titleC;	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case 0:
                tc.enabled = true;
                //タイトルモード
                rp.enabled = false;
                spown.enabled = false;
                break;
            case 1:
                titleC.SetActive(false);
                //メインモード
                tc.enabled = false;
                rp.enabled = true;
                spown.enabled = true;
                break;
            default:
                break;
        }
	}
}
