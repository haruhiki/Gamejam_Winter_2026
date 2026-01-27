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

    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    //player‚ÌˆÚ“®
    private void HandleMove() 
    {
        if (UnityEngine.Input.GetKey("w"))
        {
            transform.position += transform.forward * currentmoveSpeed * Time.deltaTime; //‘OˆÚ“®
            animator.SetBool("Walk", true);                                                              
        }
        else { animator.SetBool("Walk", false); }
        if (UnityEngine.Input.GetKey("s"))
        {
            transform.position -= transform.forward * currentmoveSpeed * Time.deltaTime; //Œã‚ëˆÚ“®
            animator.SetBool("back", true);
        }
        else { animator.SetBool("back", false); }
        if (UnityEngine.Input.GetKey("a"))
        {
            transform.position -= transform.right * currentmoveSpeed * Time.deltaTime;   //¶ˆÚ“®
            animator.SetBool("Left",true);
        }
        else { animator.SetBool("Left", false); }
        if (UnityEngine.Input.GetKey("d"))
        {
            transform.position += transform.right * currentmoveSpeed * Time.deltaTime;   //‰EˆÚ“®
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
