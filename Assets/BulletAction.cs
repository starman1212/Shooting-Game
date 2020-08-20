using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAction : MonoBehaviour
{
    GameObject scoreText;

    Text score_text;

    //敵を倒した数
    private float point = 1;

    //スコアの初期数値
    private int score_point = 0;



    // スコアの最大値を999999999に設定
    private const int maxscore_point = 999999999;

    //平均UI
    GameObject averageText;

    Text average_text;

    //精度UI
    GameObject accuracyText;

    Text accuracy_text;



    //BulletScript
    GameObject BulletScript;

    //BulletScriptオブジェクトのbulletScript
    BulletScript bulletScript;


    // Start is called before the first frame update
    void Start()
    {

        //シーン中にscoreTextオブジェクト取得
        scoreText = GameObject.Find("Score");
        score_text = scoreText.GetComponent<Text>();

        //シーン中にBulletScriptオブジェクトを取得
        BulletScript = GameObject.Find("BulletScript");
        bulletScript = BulletScript.GetComponent<BulletScript>();

        // ScoreTextに0で初期化したスコア変数を表示する
        // スコアをToString()メゾットの引数をD9で指定し、9桁で0埋めする
        scoreText.GetComponent<Text>().text = "Score: " + bulletScript.score.ToString("D9");


        //シーン中にaverageTextオブジェクト取得
        averageText = GameObject.Find("Average");
        average_text = averageText.GetComponent<Text>();

        average_text.text = "Average: " + bulletScript.Defeat + "/" + bulletScript.bulletCount;

        //シーン中にaccuracyTextオブジェクト取得
        accuracyText = GameObject.Find("Accuracy");
        accuracy_text = accuracyText.GetComponent<Text>();

        accuracy_text.text = "Accuracy:" + (bulletScript.Defeat / bulletScript.bulletCount).ToString("0.00%");


    }

    // Update is called once per frame
    void Update()
    {
        average_text.text = "Average: " + bulletScript.Defeat + "/" + bulletScript.bulletCount;

        accuracy_text.text = "Accuracy:" + (bulletScript.Defeat / bulletScript.bulletCount).ToString("0.00%");


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        //タグで指定
        {


            Destroy(collision.gameObject);

            //ぶつかった場所で固定
            this.GetComponent<Rigidbody>().isKinematic = true;

            //パーティクルの再生
            this.GetComponent<ParticleSystem>().Play();

            //透明にする
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

            //1秒したら消滅させる
            Destroy(this.gameObject, 1);

            //敵を倒した数加算
            bulletScript.Defeat += point;
      
            bulletScript.totalDefeat = bulletScript.Defeat;

            // 各タグに加算する点数を設定する
            //bulletScriptのscoreとBulletActionのscore_pointを足し、更に数値をランダム化させる
            bulletScript.score += score_point += (Random.Range(150, 255));

            bulletScript.totalscore = bulletScript.score;


        }
        else if (bulletScript.totalscore < bulletScript.score)
        {
            bulletScript.score = bulletScript.totalscore;

        }
        // ScoreTextに衝突により加算された合計スコア変数を表示する
        // if文を使用してスコアが最大値に達した時に数値を振り切らないようにする
        // スコアをToString()メゾットの引数をD9で指定し、9桁で0埋めする
        scoreText.GetComponent<Text>().text = "Score: " + bulletScript.score.ToString("D9");
        if (score_point > maxscore_point)
        {
            scoreText.GetComponent<Text>().text = "Score: " + bulletScript.totalscore.ToString("D9");
        }

    }
}
