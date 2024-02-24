using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageAbility : Ability
{
    public override Type AbilityType { get; } = Type.DEAL_DAMAGE;

    public override string Description
    {
        get
        {
            string description = $"������� {Value} �����";

            if (NumberTriggering > 1)
                description = description.Replace(" �����", $"x{NumberTriggering} �����");

            return description;
        }
    }
    
    public DealDamageAbility(Target target, int value, int numberTriggering) : base(target, value, numberTriggering)
    {
    }

    protected override void UseChieldAbility(Unit target)
    {
        target.TakeDamage(Value);
    }
}
