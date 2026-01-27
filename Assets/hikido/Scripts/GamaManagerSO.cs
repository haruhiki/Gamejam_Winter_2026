using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameManagerSO")]
public class GamaManagerSO : ScriptableObject 
{
    [Header("受け渡しステータス")]
   [SerializeField] public float statusHP = 100.0f;
   [SerializeField] public float statusMoveSpeed = 10.0f;
   [SerializeField]  public float statusMoveJump = 10.0f;
   [SerializeField]  public float statusAttackDelay = 0.5f;

    [Header("タイム関連")]
    public int eventTime = 10;
    public int gameTime = 0;
    public int gameTimeEnd = 300; //5分間で

    [Header("管理用フラグ")]
    public bool gameflg = false; //ゲームフラグ　ー＞クリア判定
    public bool damageFlg = false;

    [SerializeField] public int randomValue = 9; //イベントの数

    Action GameEventPlayer;
    Action GameEventEnemy;

    /// <summary> /// フラグリセット  /// </summary>
    private void Reset()
    {
        gameflg = false;
        damageFlg = false;
    }

}
