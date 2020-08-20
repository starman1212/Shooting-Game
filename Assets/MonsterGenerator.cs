using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SlimeGreenprefab;
    //秒経過カウント
    private float counter;
    //0.7秒毎にモンスター生成
    private float countLimit = 0.7f;

    //BulletScriptを呼び出す
    GameObject BulletScript;

    //BulletScriptのbulletScript
    BulletScript bulletScript;

    void Start()
    {
        counter = 0;

        BulletScript = GameObject.Find("BulletScript");
        bulletScript = BulletScript.GetComponent<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletScript.totalTime > 0)
        {
            counter += Time.deltaTime;


            //0.7秒経過後、counterを初期化し、モンスターを生成
            if (counter >= countLimit)
            {
                counter = 0;
                GameObject SlimeGreen = Instantiate(SlimeGreenprefab) as GameObject;
            }


        }


    }
}
