using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiLabel : MonoBehaviour
{
    [SerializeField] public Text _timeText;
    [SerializeField] GamaManagerSO _gameSO;
    [SerializeField] public Text _score;

    public GameObject[] _gameimage;
    public Image _image;
    public Image _damageImage;
    public Sprite[] _spriteImage;
   
    float counttime = 10;

    private void Start()
    { 
        _gameimage[1].SetActive(false);
        _damageImage.color = Color.clear;
    }

    private void OnEnable()
    {
        _gameSO.SceneChange += ActiveUIResult;
    }

    private void OnDisable()
    {
        _gameSO.SceneChange -= ActiveUIResult;
    }

    private void Update() 
    {
        CountDownTime();
        //ImageActive();
        if(Input.GetKeyDown(KeyCode.Escape)) {  }
        ScoreCount();
        _damageImage.color = Color.Lerp(_damageImage.color, Color.clear, Time.deltaTime);

    }

    private void ActiveUIResult() 
    {
        //if(_gameSO.gameflg == true) 
        //{
        //    _gameimage[1].SetActive(true);
        //}

        SceneManager.LoadScene("Result");
    }

    private void ScoreCount() 
    {
        _score.text = _gameSO.Score.ToString();
    }

    private IEnumerator scalerImage() 
    {
        _image.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);

//while(){
            
            yield return new WaitForSeconds(1);
    }

    public void DamageImage() 
    {
        _damageImage.color = new Color(0.7f, 0, 0, 0.7f);
    }

    //イメージ切り替え
    //valueの値 = 対応するステータスイベント
    public void ImageActive()
    {
        //StartCoroutine(scalerImage());
        switch (_gameSO.value)
        {
            case 0:
                _image.sprite = _spriteImage[0];
                break;
            case 1:
                _image.sprite = _spriteImage[1];
                break;
            case 2:
                _image.sprite = _spriteImage[2];
                break;
            case 3:
                _image.sprite = _spriteImage[3];
                break;
            case 4:
                _image.sprite = _spriteImage[4];
                break;
            case 5:
                _image.sprite = _spriteImage[5];
                break;
            case 6:
                _image.sprite = _spriteImage[6];
                break;
        }
    }

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
