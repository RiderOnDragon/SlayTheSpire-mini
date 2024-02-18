using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAbility : CardAbility
{
    public override Type AbilityType { get; } = Type.HEALING;
    public override string Description
    {
        get
        {
            string description = $"����� {_value} ��������";

            if (_numberTriggering > 1)
                description = description.Replace(" ��������", $"x{_numberTriggering} ��������");

            return description;
        }
    }

    public HealingAbility(int value, int numberTriggering) : base(value, numberTriggering)
    {
    }

    protected override void UseChieldAbility(Unit target)
    {
        target.Healing(_value);
    }
}
