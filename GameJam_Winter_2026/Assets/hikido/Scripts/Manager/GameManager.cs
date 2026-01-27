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
        _gameSO.GetComponent<GamaManagerSO>();
    }

    private void Update()
    {
        if(_gameSO != null) { return; }

        if(_gameSO.gameTime <= _gameSO.gameTimeEnd) 
        {
            _gameSO.gameflg = true;
            //ƒV[ƒ“‘JˆÚ
            SceneManager.LoadScene("RankingScene");
        }
       
    }
}
