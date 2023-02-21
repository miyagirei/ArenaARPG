using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    string enemy = "Enemy";
    [SerializeField] float weaponDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == enemy)
        {
            print("Damege");
            if (other.GetComponent<EnemyController>())
            {
                other.GetComponent<EnemyController>().HitDamege(weaponDamage);
            }
            else if (other.GetComponent<BodyPartPoint>())
            {
                other.GetComponent<BodyPartPoint>().DamageReduction(weaponDamage);
            }

        }
    }
}
