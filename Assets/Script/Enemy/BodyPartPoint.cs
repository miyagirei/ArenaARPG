using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartPoint : MonoBehaviour
{
    [SerializeField] EnemyController myBase;
    [SerializeField] float _reductionRate;
    enum Type
    {
        Cut,
        Reduction
    }
    [SerializeField] Type type;

    void Update()
    {

    }

    public void DamageReduction(float damage)
    {
        switch (type) {
            case Type.Cut:
                float cutResult = 0;
                if (damage - _reductionRate >= 0)
                {
                    cutResult = damage - _reductionRate;
                }
                else if (damage - _reductionRate < 0)
                {
                    cutResult = 0;
                }
                myBase.HitDamege(cutResult);
            break;
            case Type.Reduction:
                float ReductionResult = damage * (1 - (_reductionRate / 100));
                myBase.HitDamege(ReductionResult);
            break;
        }
    }
}
