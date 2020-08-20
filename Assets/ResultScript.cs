using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetunToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
