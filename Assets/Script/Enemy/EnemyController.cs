using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] float _hp;
    [SerializeField] float _armor;
    enum Type
    {
        Cut,
        Reduction
    }
    [SerializeField] Type type;

    [SerializeField] float damageTextPos = 1;
    private Vector3 AdjPos;

    EnemyManager enemyMng;


    enum Tribe
    {
        None,
        Human,
        Slime
    }
    [SerializeField] Tribe _tribe;
    private void Start()
    {
        enemyMng = GetComponent<EnemyManager>();
        AdjPos = new Vector3(0, damageTextPos, 0);
    }
    public void HitDamege(float damage)
    {
        switch (type)
        {
            case Type.Cut:
                float cutResult = 0;
                if (damage - _armor >= 0)
                {
                    cutResult = damage - _armor;
                }
                else if (damage - _armor < 0)
                {
                    cutResult = 0;
                }
                _hp -= cutResult;
                ViewDamage(cutResult);
            break;
            case Type.Reduction:
                float ReductionResult = damage * (1 - (_armor / 100));
                _hp -= ReductionResult;
                ViewDamage(ReductionResult);
            break;
        }
        print(_hp);
    }

    public void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ViewDamage(float damage)
    {
        GameObject _damageObj = Instantiate(EnemyManager.damageEffect);
        _damageObj.GetComponent<TextMesh>().text = damage.ToString();
        _damageObj.transform.position = this.transform.position + AdjPos;
    }
}
