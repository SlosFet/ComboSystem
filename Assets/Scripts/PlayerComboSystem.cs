using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboSystem : MonoBehaviour
{
    public List<Combos> Combos;
    [field : SerializeField] public Combos CurrentCombo { get; private set; }
    private bool canHit = true;
    private void Start()
    {
        CurrentCombo = Combos[0];
    }
    private void OnEnable()
    {
        PlayerInputHandler.MeleeAttack.AddListener(Combo);
    }

    private void OnDisable()
    {
        PlayerInputHandler.MeleeAttack.RemoveListener(Combo);
    }

    private void Combo()
    {
        if (!canHit)
            return;

        canHit = false;
        CurrentCombo.Attack(Time.time);
    }

    public void ChangeCurrentCombo(ComboNames comboName)
    {
        CurrentCombo.StopCoroutine();
        CurrentCombo.ResetCombo();
        switch (comboName)
        {
            case ComboNames.Combo1:
                CurrentCombo = Combos[0];
                break;

            case ComboNames.Combo2:
                CurrentCombo = Combos[1];
                break;
        }
    }

    public void SetComboContinue()
    {
        canHit = true;
        CurrentCombo.ResetCoroutineReset();
    }

    public void SetCanHitTrue()
    {
        canHit = true;
    }
}

public enum ComboNames
{
    Combo1,
    Combo2
}

