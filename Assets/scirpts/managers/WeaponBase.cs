using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("weapon base stats")] 
    [SerializeField] protected float timeBetweenAttacks;
    [SerializeField] protected float chargeUpTime;
    [SerializeField,Range(0, 1)] protected float minChargePercent;
    [SerializeField] protected bool isFullyAuto;

    private Coroutine _currentFireTimer;
    private bool _isOnCooldown;
    private float _currentChargeTime;

    private WaitForSeconds _cooldownWait;
    private WaitUntil _cooldownEnforce;

    private void Start()
    {
        _cooldownWait = new WaitForSeconds(timeBetweenAttacks);
        _cooldownEnforce = new WaitUntil(() => !_isOnCooldown);
    }

    public void StartShooting()
    {
        _currentFireTimer = StartCoroutine(ReFireTimer());
    }
    
    public void StopShooting()
    {
        StopCoroutine(_currentFireTimer);

        float percent = _currentChargeTime / chargeUpTime;
        if(percent != 0) TryAttack(percent);
    }


    

    private IEnumerator CooldownTimer()
    {
        _isOnCooldown = true;
        yield return (timeBetweenAttacks);
        _isOnCooldown = false;
    }

    private IEnumerator ReFireTimer()
    {
        print("waiting for cooldown");
        yield return _cooldownEnforce;
        print("cooldown finished");

        while(_currentChargeTime < chargeUpTime)
        {
            _currentChargeTime += Time.deltaTime;
            yield return null;
        }

        TryAttack(1);
        yield return null;
    }

    private void TryAttack(float percent)
    {
        _currentChargeTime = 0;
        if (!CanAttack(percent)) return;

        Attack(percent);

        StartCoroutine(CooldownTimer());

        if (isFullyAuto && percent >= 1) _currentFireTimer = StartCoroutine(ReFireTimer());
    }
    
    protected virtual bool CanAttack(float percent)
    {

        Vector3 math = 50 * Time.deltaTime * Vector3.one;
        return !_isOnCooldown && percent >= minChargePercent;
    }
    
    protected abstract void Attack(float percent);
}
