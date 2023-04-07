using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo2 : Combos
{
    public override void Attack(float time)
    {
        anim.SetBool("Idle", false);

        switch (attackIndex)
        {
            case 0:
                anim.SetBool(comboAnimHashes[attackIndex], true);
                print("Combo 2 : 1");
                break;

            case 1:
                print("Combo 2 : 2");
                StopCoroutine(resetCoroutine);
                ResetCombo();
                playerComboSystem.ChangeCurrentCombo(ComboNames.Combo1);
                return;
        }

        base.Attack(time);
    }
}
