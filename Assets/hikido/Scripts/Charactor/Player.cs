using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : CharactorBase
{
    
    protected override void Start() 
    {
        base.Start();
        //_playertransform = GetComponent<Transform>();
    }

    private void Update()
    {
        //常に更新
        currentmoveSpeed = gameManegerSO.statusMoveSpeed;
        currentmoveJump = gameManegerSO.statusMoveJump;
    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    //playerの移動
    private void HandleMove() 
    {
        if (UnityEngine.Input.GetKey("w"))
        {
            transform.position += transform.forward * currentmoveSpeed * Time.deltaTime; //前移動
            animator.SetBool("Walk", true);                                                              
        }
        else { animator.SetBool("Walk", false); }
        if (UnityEngine.Input.GetKey("s"))
        {
            transform.position -= transform.forward * currentmoveSpeed * Time.deltaTime; //後ろ移動
            animator.SetBool("back", true);
        }
        else { animator.SetBool("back", false); }
        if (UnityEngine.Input.GetKey("a"))
        {
            transform.position -= transform.right * currentmoveSpeed * Time.deltaTime;   //左移動
            animator.SetBool("Left",true);
        }
        else { animator.SetBool("Left", false); }
        if (UnityEngine.Input.GetKey("d"))
        {
            transform.position += transform.right * currentmoveSpeed * Time.deltaTime;   //右移動
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
    }

    private void DamageHP()
    {

    }

}
