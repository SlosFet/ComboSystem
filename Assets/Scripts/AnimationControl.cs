using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int animHash_Vertical = Animator.StringToHash("Vertical");
    private static readonly int animHash_Horizontal = Animator.StringToHash("Horizontal");

    public void SetInputValues(Vector3 Input)
    {
        _animator.SetFloat(animHash_Vertical, Input.z);
        _animator.SetFloat(animHash_Horizontal, Input.x);
    }
    
}
