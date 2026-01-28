using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class UiLabel : MonoBehaviour
{
    [SerializeField] public Text _timeText;
    public Image _image;
    public Sprite[] _spriteImage;
    [SerializeField] GamaManagerSO _gameSO;
    float counttime = 10;

    private void Start()
    {
      
    }

    private void Update() 
    {
       CountDownTime();
    }


    //イメージ切り替え
    //private void ImageActive() 
    //{
    //    switch(_gameSO.value) 
    //    {
    //        case 0:
    //            _image.sprite = _spriteImage[0];
    //            break;
    //        case 1:
    //            _image.sprite = _spriteImage[1];
    //            break;
    //        case 2:
    //            _image.sprite = _spriteImage[2];
    //            break;
    //        case 3:
    //            _image.sprite = _spriteImage[3];
    //            break;
    //        case 4:
    //            _image.sprite = _spriteImage[4];
    //            break;
    //    }
    //}

    private IEnumerator DelayUI() 
    {
        int delaytime = 3;
        yield return new WaitForSeconds(delaytime);
    }


    //10秒カウントダウンUI用
    private void CountDownTime()
    {
        _timeText.text =  _gameSO.eventTime.ToString("F0");
    }


}
