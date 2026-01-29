using Unity.VisualScripting;
using UnityEngine;

public class DamageContorol : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private PlayerHP playerHP;
    
    //ê⁄êGîªíË
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("damege");
            playerHP.HitDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Ç‚ÇÁÇÍÇÈ");
            Destroy(gameObject);
        }
    }
}
