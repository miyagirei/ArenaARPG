using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]GameObject _damageEffect;
    public static GameObject damageEffect;

    [SerializeField] List<GameObject> _enemyList;
    private void Start()
    {
        damageEffect = _damageEffect;
    }
}
