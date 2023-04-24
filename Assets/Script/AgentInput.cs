using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamera;

    private bool fireButtonDown = false;

    private void Awake()
    {
        mainCamera = Camera.main;



    }

    [field: SerializeField]

    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]

    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    [field: SerializeField]

    public UnityEvent OnFirePressedButton { get; set; }

    [field: SerializeField]

    public UnityEvent OnFirePressedReleased { get; set; }









    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();


    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFirePressedButton?.Invoke();
            }
        }
        else
        {

            if (fireButtonDown)
            {
                fireButtonDown = false;
                OnFirePressedReleased?.Invoke();

            }

        }
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);


    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

    }
}
