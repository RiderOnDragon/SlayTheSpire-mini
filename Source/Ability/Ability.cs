using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public abstract class Ability
{
    public enum Target
    {
        SINGLE_ENEMY,
        CHARACTER,
        ALL_ENEMY,
        ALL_UNIT
    }

    private Target _target;
    private int _value;
    private int _numberTriggering;

    protected Ability(Target target, int value, int numberTriggering)
    {
        _target = target;
        _value = value;
        _numberTriggering = numberTriggering;
    }

    public Target AbilityTarget { get => _target; }
    public int Value { get => _value; }
    public int NumberTriggering { get => _numberTriggering; }

    public bool CheckTarget(ref Unit targetUnit)
    {
        switch (_target)
        { 
            case Target.SINGLE_ENEMY:
                if (targetUnit is Enemy enemy)
                {
                    targetUnit = enemy;
                    return true;
                }
                else
                {
                    return false;
                }
            case Target.CHARACTER:
                targetUnit = Character.Singleton;
                return true;
            case Target.ALL_ENEMY:
                return true;
            case Target.ALL_UNIT:
                return true;
            default:
                throw new System.Exception("The raw type of ability");
        }
    }

    public void UseAbility(Unit targetUnit)
    {
        int cycle = 0;
        while (cycle < _numberTriggering)
        {
            switch (_target)
            {
                case Target.SINGLE_ENEMY:
                    UseChieldAbility(targetUnit);
                    break;

                case Target.CHARACTER:
                    UseChieldAbility(targetUnit);
                    break;

                case Target.ALL_ENEMY:
                    foreach (var enemy in EnemySquad.Singleton.CurrentEnemies)
                        UseChieldAbility(enemy);
                    break;

                case Target.ALL_UNIT:
                    List<Unit> targets = new List<Unit>();
                    targets.AddRange(EnemySquad.Singleton.CurrentEnemies);
                    targets.Add(Character.Singleton);
                    foreach (var target in targets)
                        UseChieldAbility(target);
                    break;
            }

            cycle++;
        }
    }

    protected abstract void UseChieldAbility(Unit target);
}
