using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo1 : Combos
{
    public float MinWaitTimeToCombo2;
    public float MaxWaitTimeToCombo2;
    public float denemeSüresi;
    public override void Attack(float time)
    {
        anim.SetBool("Idle", false);
        switch(attackIndex)
        {
            case 0:
                anim.SetBool(comboAnimHashes[attackIndex], true);
                print("Combo 1 : 1");
                break;
            case 1:
                anim.SetBool(comboAnimHashes[attackIndex], true);
                print("Combo 1 : 2");
                StopCoroutine(resetCoroutine);
                break;
            case 2:
                denemeSüresi = time - lastAttackTime;
                if (denemeSüresi > MinWaitTimeToCombo2 )
                {
                    if (denemeSüresi > MaxWaitTimeToCombo2)
                    {
                        print("Resetledim");
                        ResetCombo();
                        Attack(Time.time);
                        return;
                    }
                    playerComboSystem.ChangeCurrentCombo(ComboNames.Combo2);
                    playerComboSystem.CurrentCombo.Attack(Time.time);
                    return;
                }

                anim.SetBool(comboAnimHashes[attackIndex], true);
                print("Combo 1 : 3");
                break;
        }

        base.Attack(Time.time);
    }

  
}
