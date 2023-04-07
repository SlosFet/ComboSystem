using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combos : MonoBehaviour
{
    [field: SerializeField] protected float maxWaitTime;
    [field: SerializeField] protected PlayerComboSystem playerComboSystem;
    [field: SerializeField] protected Animator anim;
    [field: SerializeField] protected List<string> comboAnimHashes;

    protected float lastAttackTime;
    protected int attackIndex;
    protected IEnumerator resetCoroutine;
    private void Start()
    {
        resetCoroutine = ResetCoroutine();
    }
    public virtual void Attack(float time)
    {
        lastAttackTime = time;
        attackIndex++;
    }

    public void StopCoroutine()
    {
        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);
    }

    public void ResetCombo()
    {
        attackIndex = 0;
        foreach (string hash in comboAnimHashes)
        {
            anim.SetBool(hash, false);
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Idle", true);
        playerComboSystem.SetCanHitTrue();
        playerComboSystem.ChangeCurrentCombo(ComboNames.Combo1);
    }
    protected IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(maxWaitTime);
        ResetCombo();
        ReturnToIdle();
    }

    public void ResetCoroutineReset()
    {
        StopCoroutine();
        resetCoroutine = ResetCoroutine();
        StartCoroutine(resetCoroutine);
    }
}
