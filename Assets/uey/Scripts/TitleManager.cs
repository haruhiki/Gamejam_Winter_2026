using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GamaManagerSO _gameSO;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        AudioManager.Instance.PlayBGM(AudioManager.BGMSoundData.BGMDATA.TITLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameSO.gameflg) 
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
