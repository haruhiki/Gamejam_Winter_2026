using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : CharactorBase
{
    [SerializeField] private bool dieEnemy = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void nTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon")) 
        {
            Debug.Log("‚â‚ç‚ê‚é");
            this.gameObject.IsDestroyed();  
        }

    }
}
