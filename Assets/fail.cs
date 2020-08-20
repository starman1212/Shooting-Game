using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fail : MonoBehaviour
{

    //ミス数
    public float Miss_shot = 1;

    //ミス初期値
    public int Miss_count = 0;

    //MISS UI
    GameObject missText;

    Text miss_text;


    // Start is called before the first frame update
    void Start()
    {
        //シーン中にmissTextオブジェクト取得
        missText = GameObject.Find("Miss");
        miss_text = missText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Miss_shot += Miss_count += 1;

            missText.GetComponent<Text>().text = "MISS: " + Miss_count;
        }

    }
}
