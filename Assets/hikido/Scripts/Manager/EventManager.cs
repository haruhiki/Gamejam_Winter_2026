using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] GamaManagerSO _gameSO;
    [SerializeField] Player _player;
    [SerializeField] UiLabel _label;
    public Animator animator;
    private int randomStatus = 0;
    private float speed = 1.0f;
    private Vector3 _coliderScale;
    WaitForSeconds onesec;
    private bool isOnce = false;

    void Start()
    {
        isOnce = false;
        _gameSO.eventTime = 10.0f;
       _coliderScale = _player._weapon.GetComponent<BoxCollider>().size = new Vector3(1.5f,1.5f,1.5f);
        onesec = new WaitForSeconds(1);
    }

    void Update()
    {
        EventAction();
    }

    private void EventAction()
    {
        if (_gameSO == null) { return; }

        if (_gameSO.eventTime < 3.5 && !isOnce)
        {
            isOnce = true;
           Invoke("PlaySound", 1.0f);
           Invoke("PlaySound", 2.0f);
           Invoke("PlaySound", 0.0f);
        }

        //10秒ごとにランダムなイベント
        if (_gameSO.eventTime < 0)
        {
            AudioManager.Instance.PlayspecificSE("Event", 1);
            EventPlayer();
            //タイムリセット
            isOnce = false;
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

        _gameSO.value = Random.Range(1, _gameSO.randomValue);
        Debug.Log("_gameSO.randomValue" + _gameSO.randomValue);
        Debug.Log("ランダムな値" + _gameSO.value);
        switch (_gameSO.value)
        {
            case 1:
                //各種イベント処理
                StatusSpeedEvent();
                Debug.Log("スピードステータスイベント");
                break;
            case 2:
                StatusGravityEvent();
                Debug.Log("ジャンプステータスイベント");
                break;
            case 3:
                AnimationSpeed();
                Debug.Log("攻撃速度変化");
                break;
            case 4:
                ColiderRange();
                Debug.Log("コライダー調整");
                break;
            case 5:
                JumpStatusDownEvent();
                Debug.Log("ジャンプステータスダウンイベント");
                break;
            case 6:
                SpeedStatusDownEvent();
                Debug.Log("スピードステータスダウンイベント");
                break;

        }

        _label.ImageActive();
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

    private void AnimationSpeed() 
    {
        StatusRandom(0, 10);
        int statu = (int)speed;
        animator.SetInteger("Speed", randomStatus);
        if (_gameSO.eventTime < 0) { animator.SetInteger("Speed", (int)statu); }
    }

    private void ColiderRange() 
    {
        StatusRandom(3, 10);
        Vector3 status = _coliderScale;
        _player._weapon.GetComponent<BoxCollider>().size = new Vector3(randomStatus, randomStatus, randomStatus);
        if(_gameSO.eventTime < 0) { _player._weapon.GetComponent<BoxCollider>().size = status; }
    }


}