using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Player : CharactorBase
{
    [SerializeField] GameObject _camera;
    [SerializeField] private float sensitivity = 30;
    [SerializeField] private float clampAngle = 80f;
    private float xRotation = 0f;
    private float yRotation = 0f;   

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
        //攻撃
        Attack();

        //移動
        HandleMove();

        //マウスでのカメラ
        CameraControl();
    }

    private void CameraControl()
    {
        float mx = UnityEngine.Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float my = UnityEngine.Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation += mx;
        yRotation -= my;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
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
        else {　animator.SetBool("Right", false); }
    }

    //攻撃
    private void Attack() 
    {
        const string AttackParam = "Attack";
        if (UnityEngine.Input.GetMouseButton(0)) 
        {
            animator.SetTrigger(AttackParam);
        }
    }

    private void DamageHP()
    {

    }

}
