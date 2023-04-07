using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    public Keycodes Keycodes;
    public static UnityEvent MeleeAttack = new UnityEvent();
    public static UnityEvent<bool> SetCanMove= new UnityEvent<bool>();
    void Update()
    {

        if (Input.GetKeyDown(Keycodes.MeleeAttack))
        {
            MeleeAttack.Invoke();
            SetCanMove.Invoke(false);
        }
        else
            SetCanMove.Invoke(true);

    }
}
