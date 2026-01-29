using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackConotorol : MonoBehaviour
{
    [SerializeField] private WeaponColision currentCollision;
    private void Start()
    {
        //currentCollision = GetComponent<WeaponColision>();
    }

    //アニメーションイベントでの呼び出し
    public void EnableHitBox()
    { 
        if (currentCollision) 
        {
            currentCollision.SetCollisionActive(true); 
        }
    }

    public void DisableHitBox() 
    {
        if (currentCollision)
        { 
            currentCollision.SetCollisionActive(false); 
        }
    }
}
