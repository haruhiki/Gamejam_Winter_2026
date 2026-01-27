using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] GamaManagerSO _gameSO;

    void Start()
    {
        _gameSO = GetComponent<GamaManagerSO>();
    }

    void Update()
    {
        
    }

    public void EventAction() 
    {
        if (_gameSO != null) { return; }

        _gameSO.eventTime = (int)Time.deltaTime;

        //タイムリセット
        if(_gameSO.eventTime > 10)
        {
            
            _gameSO.eventTime = 0; 
        }

        //10秒ごとにランダムなイベント
        if( _gameSO.eventTime <= 10) 
        {
            EventPlayer();
        }

    }

    public void EventPlayer()
    {
        //int value = Random.Range(0, _gameSO.randomValue);
        int value = 0;
        switch (value) 
        {
            case 0:
                //各種イベント処理
                _gameSO.statusMoveSpeed = 15;
                break;
            case 1:
                //イベント2
                break;
            case 2:
                //イベント3
                break;
        }   
    }

   
}
