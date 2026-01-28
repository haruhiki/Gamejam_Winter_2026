using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] GamaManagerSO _gameSO;
    private float randomStatus = 0;
    WaitForSeconds onesec;

    void Start()
    {
        _gameSO.eventTime = 10.0f;
        onesec = new WaitForSeconds(1);
    }

    void Update()
    {
        EventAction();
    }

    private void EventAction()
    {
        if (_gameSO == null) { return; }

        if (_gameSO.eventTime < 3)
        {
            StartCoroutine(PlaySoundOneSec());
           //InvokeRepeating("PlaySound", 0.0f, 1.0f);
        }

        //10秒ごとにランダムなイベント
        if (_gameSO.eventTime < 0)
        {
            AudioManager.Instance.PlayspecificSE("Event", 1);
            EventPlayer();
            //タイムリセット
            _gameSO.eventTime = 10.0f;
        }
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlayspecificSE("Event", 0);
    }

    IEnumerator PlaySoundOneSec() 
    {
        AudioManager.Instance.PlayspecificSE("Event", 0);
        yield return onesec;
    }

    public void EventPlayer()
    {
        _gameSO.value = Random.Range(0, _gameSO.randomValue);
        switch (_gameSO.value)
        {
            case 0:
                //各種イベント処理
                StatusSpeedEvent();
                Debug.Log("スピードステータスイベント");
                break;
            case 1:
                StatusGravityEvent();
                Debug.Log("ジャンプステータスイベント");
                break;
            case 2:
                SpeedStatusDownEvent();
                Debug.Log("スピードステータスダウンイベント");
                break;
            case 3:
                JumpStatusDownEvent();
                Debug.Log("ジャンプステータスダウンイベント");
                break;

        }
    }

    //ランダムな値を取得するだけ
    private void StatusRandom(int min ,int max) { randomStatus = Random.Range(min, max); }

    private void StatusSpeedEvent() 
    {
        //TODO:マジックナンバーなくす
        StatusRandom(20,100);
        float status = _gameSO.statusMoveSpeed;
        _gameSO.statusMoveSpeed = randomStatus;
        //10秒後に元の数値
        Debug.Log(_gameSO.eventTime);
        if(_gameSO.eventTime < 0) { _gameSO.statusMoveSpeed = status + (_gameSO.statusMoveSpeed / 2); }

    }

    private void StatusGravityEvent() 
    {
        StatusRandom(200,400);
        float status = _gameSO.statusMoveJump;
        _gameSO.statusMoveJump = randomStatus;
        if(_gameSO.eventTime < 0) { _gameSO.statusMoveJump = status + (_gameSO.statusMoveJump / 2); }
    }

    //速度低下イベント
    private void SpeedStatusDownEvent() 
    {
        StatusRandom(0, 19);
        float status = _gameSO.statusMoveSpeed;
        _gameSO.statusMoveSpeed = randomStatus;
        if(_gameSO.eventTime  < 0) { _gameSO.statusMoveSpeed = status; }
    }

    //ジャンプパワー低下イベント
    private void JumpStatusDownEvent()
    {
        StatusRandom(0, 199);
        float status = _gameSO.statusMoveJump;
        _gameSO.statusMoveJump = randomStatus;
        if (_gameSO.eventTime < 0) { _gameSO.statusMoveJump = status; }
    }



}