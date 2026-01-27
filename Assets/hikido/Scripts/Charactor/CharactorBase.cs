using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactorBase : MonoBehaviour
{
    [SerializeField] protected GamaManagerSO gameManegerSO;
    [SerializeField] protected Animator animator;

    protected float currentHP = 0;
    protected float currentmoveSpeed = 0;
    protected float currentmoveJump = 0;
    protected float currentdrayAttackSpeed = 0;
   
    protected virtual void Start()
    {
        //コンポーネント取得
        gameObject.GetComponent<GameObject>();
        currentHP = gameManegerSO.statusHP;
        currentmoveSpeed = gameManegerSO.statusMoveSpeed;
        currentmoveJump = gameManegerSO.statusMoveJump;
        currentdrayAttackSpeed = gameManegerSO.statusAttackDelay;
    }

}
