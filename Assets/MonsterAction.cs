using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    //最小スケールと最大スケールの宣言
    private float scale;
    private float speed = 1.0f;
    private float minScale = 125;
    private float maxScale = 200;


    //status変数
    private string status;

    // Start is called before the first frame update
    void Start()
    {
        //開始位置のX座標をランダムで作成
        float x = Random.RandomRange(-8, 8);
        //開始位置
        this.gameObject.transform.position = new Vector3(x, 0, 140);

        //現在の状態
        scale = minScale;
        status = "up";
    }

    // Update is called once per frame
    void Update()
    {
        //メインカメラの方向に向かって移動する
        this.gameObject.transform.Translate(0, 0, 1.6f);

        if(status == "up")
        {
            scale += 15;
            //最大になったら小さくする
            if (scale >= maxScale)
                scale = maxScale;
            status = "down";
        }
        else
        {
            scale -= 15;
            //最小になったら大きくする
            if (scale <= minScale)
                scale = minScale;
            status = "up";
        }
        this.gameObject.transform.localScale = new Vector3(scale, scale, scale);

        //Z座標が50より小さくなったらオブジェクトを削除
        if(this.gameObject.transform.position.z < 50)
        {
            Destroy(this.gameObject);
        }
    }
    
}
