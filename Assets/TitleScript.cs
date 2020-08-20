using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameStart()
    {
        SceneManager.LoadScene("Game Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
