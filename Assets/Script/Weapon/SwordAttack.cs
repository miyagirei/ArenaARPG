using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    string enemy = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == enemy)
        {
            print("Damege");
        }
    }
}
