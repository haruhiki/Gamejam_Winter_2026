using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool isResult = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BGMSoundData.BGMDATA.TITLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (isResult) 
        {
            Result();
        }
    }

    public void GoGame()
    { 
        SceneManager.LoadScene("Game");
        AudioManager.Instance.BGMStop();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    private void Result() 
    {
        //タイトルシーンに戻る
        if (Input.GetKey(KeyCode.Return))
        {
            AudioManager.Instance.BGMStop();
            SceneManager.LoadScene("title");
        }
    }

  
   
}
