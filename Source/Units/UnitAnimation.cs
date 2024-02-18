using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAnimation : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    public float AnimationTime { get; private set; }

    private const float DELAY_AFTER_ANIMATION = 0.5f;

    private const string ADD_SHIELD = "AddShield";
    private const string TAKE_DAMAGE = "TakeDamage";
    private const string DEATH = "Death";
    private const string START_OFFSET = "StartOffset";

    public void Init()
    {
        _animator.SetFloat(START_OFFSET, Random.Range(0, 1f));
    }

    public void AddShield()
    {
        PlayAnimation(ADD_SHIELD);
    }

    public void TakeDamage()
    {
        PlayAnimation(TAKE_DAMAGE);
    }

    public void Death()
    {
        PlayAnimation(DEATH);
    }

    protected void PlayAnimation(string trigger)
    {
        _animator.SetTrigger(trigger);
        AnimationTime = _animator.GetCurrentAnimatorStateInfo(0).length + DELAY_AFTER_ANIMATION;
    }
}