using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : CharactorBase
{
    [SerializeField] PlayerHP _plaerHP;
    [SerializeField] GameObject _camera;
    [SerializeField]  public GameObject _weapon;
    [SerializeField] Rigidbody _rb;
    [SerializeField] private float sensitivity = 3;
    [SerializeField] private float clampAngle = 80f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    bool isJumping = false;

    protected override void Start() 
    {
        Vector3 currentRot = transform.localRotation.eulerAngles;
        yRotation = currentRot.y;
        xRotation = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        base.Start();
        isJumping = false;
        _plaerHP.GetComponent<PlayerHP>();   
        _rb.GetComponent<Rigidbody>();
        //_playertransform = GetComponent<Transform>();
    }

    private void Update()
    {
        //常に更新
        currentmoveSpeed = gameManegerSO.statusMoveSpeed;
        currentmoveJump = gameManegerSO.statusMoveJump;

        //TODO：テストコードで後で削除
        //if (Input.GetKey("p")) { TestTeakeDamage(); }
    }

    private void FixedUpdate()
    {
        //攻撃
        Attack();

        //移動
        HandleMove();

        //ジャンプ
        HandleJump();

        //マウスでのカメラ
        CameraControl();

    }

    //カメラコントロール
    private void CameraControl()
    {
        float mx = UnityEngine.Input.GetAxisRaw("Mouse X") * sensitivity;
        float my = UnityEngine.Input.GetAxisRaw("Mouse Y") * sensitivity;

        yRotation += mx;
        xRotation -= my;
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
            transform.position -= transform.right * currentmoveSpeed * Time.deltaTime;
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

    private void HandleJump()
    {
        if (Input.GetKeyDown("space"))
        {
            if(isJumping == false) 
            {
                _rb.AddForce(transform.up * currentmoveJump);
                animator.SetBool("Jump", true);
            }
            AudioManager.Instance.PlayspecificSE("Player", 3);
            isJumping = true;
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    //攻撃
    private void Attack() 
    {
        const string AttackParam = "Attack";
        if (Input.GetMouseButtonDown(0)) 
        {
            AudioManager.Instance.PlayspecificSE("Player", 0);
            animator.SetTrigger(AttackParam);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy")) 
        {
            //if (other.gameObject.TryGetComponent<Enemy>(out var enemy)) return;
            int _hitDamage = (int)enemyDamage;
            StartCoroutine(_plaerHP.HitDamage(_hitDamage));
            //if (!enemy.IsDead())
            //{
               
            //}
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground") 
        {
            isJumping = false;
        }
    }

    //testcode
    private void TestTeakeDamage() 
    {
        int _hitDamage = (int)enemyDamage;
        StartCoroutine(_plaerHP.HitDamage(_hitDamage));
    }



}
