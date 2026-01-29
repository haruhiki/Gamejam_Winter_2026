using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_ : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [Header("スピード設定して")]
    public int MinSpd;
    public int MaxSpd;
    float moveSpeed;

    [Header("飛ぶか飛ばないか設定して")]
    [SerializeField] private bool isGravity = false;
    [SerializeField] public Vector3 spowarnPos = new Vector3(0.0f,0.0f, 0.0f); 
    [SerializeField] private Rigidbody rb;

    private  void Start()
    {
        Init();
    }

    private void Init() 
    {
        moveSpeed = Random.Range(MinSpd, MaxSpd) * 0.2f;
    }

    private void NewEnemyMove()
    {
        Vector3 newpos = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        this.transform.position = newpos;
    }

    // Update is called once per frame
    void Update()
    {
        NewEnemyMove();
        //   Enemyfoward();
        //常にチェック
        //    StateEnemy();
    }

    private void EnemyMove() 
    {
        var _playerPos = GameObject.Find("Player").transform.position;
        var _moveVec = _playerPos - transform.position;
        _moveVec.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(_moveVec),10.0f);
    }

    private void Enemyfoward() 
    {
        if (isGravity) { rb.useGravity = true; }
        else { rb.useGravity = false; }
        target.transform.LookAt(target.transform);
       // target.transform.position += transform.forward * gameManegerSO.statusMoveSpeed;
    }


    //敵の行動パターン
    private void StateEnemy() 
    {
        int value = 0;
        //プレイヤーとの距離で求める。
        float norm = (target.transform.position - gameObject.transform.position).magnitude;
        if(norm < 10.0f) { value = 0; }
        else { value = 1; }
        switch (value) 
        {
            case 0:
                //敵移動処理
                break;
            case 1:
                AttackEnemy();
                break;
        }
    }

    private void AttackEnemy() 
    {
        
    }

    //接触判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("やられる");
            this.gameObject.IsDestroyed();
        }
    }


}
