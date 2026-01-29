using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GamaManagerSO _gameSO;

    private void Start()
    {
        _gameSO.Reset();
        AudioManager.Instance.PlayBGM(AudioManager.BGMSoundData.BGMDATA.GAME);
    }

    private void Update()
    {
        if(_gameSO == null) { return; }

        _gameSO.startTime = Time.time;
        _gameSO.eventTime -= Time.deltaTime;
        Debug.Log("_gameSO.gameTime" + _gameSO.startTime);
        Debug.Log("_gameSO.eventTime" + _gameSO.eventTime);

        if(_gameSO.startTime >= _gameSO.gameTimeEnd) 
        {
            _gameSO.gameflg = true;
            //ƒV[ƒ“‘JˆÚ
            SceneManager.LoadScene("RankingScene");
        }
       
    }
}
