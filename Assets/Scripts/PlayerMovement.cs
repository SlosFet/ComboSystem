using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private AnimationControl animController;
    private bool canMove = true;
    Vector3 direction;

    private void OnEnable()
    {
        PlayerInputHandler.SetCanMove.AddListener(SetCanMove);
    }

    private void OnDisable()
    {
        PlayerInputHandler.SetCanMove.RemoveListener(SetCanMove);
    }
    public void Update()
    {
        if (!canMove)
            return;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animController.SetInputValues(new Vector3(horizontalInput, 0, verticalInput));
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
    }

    private void SetCanMove(bool state)
    {
        if (canMove == state)
            return;

        canMove = state;
        if (!canMove)
        {
            animController.SetInputValues(Vector3.zero);
        }
    }
}

