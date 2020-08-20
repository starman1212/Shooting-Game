using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    //アウトレット接続
    public GameObject BulletPrefab;

    //Rayの宣言
    private Ray ray;

    //弾の飛ぶ強さ
    private float power = 80f;

    //発射フラグ
    private bool shoot;

    //弾消滅時間
    private float timeLimit = 3;

    //弾のオブジェクト
    GameObject Bullet;

    //敵を倒した数
    public float Defeat = 0;

    //敵を倒した総数
    public float totalDefeat = 0;

    //スコア
    public int score = 0;

    //総スコア
    public int totalscore = 0;

    //撃った弾数
    public float bulletCount = 0;



    //制限時間
    public float totalTime = 180;
    GameObject timeText;
    Text time_text;

    GameObject ResultPanel;

    Text result_text;

    void Awake()
    {
        ResultPanel = GameObject.Find("ResultPanel");
        ResultPanel.SetActive(false);

    }


    // Start is called before the first frame update
    void Start()
    {
        //シーン中にtimeTextオブジェクト取得
        timeText = GameObject.Find("Time");
        time_text = timeText.GetComponent<Text>();

        gameOverFlg = false;
    }

    //ゲームオーバーフラグ
    bool gameOverFlg;



    // Update is called once per frame
    void Update()
    {
        //左クリックを押された時の処理(Timeが0になったら弾が出なくなる)
        if (Input.GetMouseButtonDown (0) && totalTime !=0)
        {
            //弾のオブジェクトを作成
            Bullet = GameObject.Instantiate(BulletPrefab);

            //スクリーンの点を通してカメラRayを通す
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //FixedUpdateで弾を発射するフラグをたてる
            shoot = true;
        }
        else
        {
            //FixedUpdateで弾を発射するフラグをおろす
            shoot = false;

        }

        //弾消滅時間がきたらBulletオブジェクトを削除
        Destroy(Bullet, timeLimit);

        //totalTime減算
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            time_text.text = "TIME: " + totalTime.ToString("F2");
        }
        //時間が0になりゲームオーバ^フラグが偽の場合は真に変える
        else if (gameOverFlg == false)
        {
            gameOverFlg = true;

            totalTime = 0;
            time_text.text = "TIME: 0";

            ResultPanel.SetActive(true);
            result_text = GameObject.Find("ResultText").GetComponent<Text>();

            if (bulletCount > 0)
            {
                //スコアx命中率x1000加算
                float bonus = Defeat * (Defeat / bulletCount) * 1000;


                totalDefeat = (Defeat * 1000 + bonus);
            }

            result_text.text = "Total Score: " + Mathf.RoundToInt(totalDefeat).ToString("D9");

        }

    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            if(Bullet != null)
            {
                //弾のRigidbodyに力を加える
                Bullet.GetComponent<Rigidbody>().AddForce(ray.direction * power, ForceMode.Impulse);



                bulletCount++;
                shoot = false;
            }
        }
    }
}
