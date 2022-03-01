using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] public FixedJoystick joystick;
    [SerializeField] Transform center;

    public bool isShooting;

    private void Awake()
    {
        _camera = Camera.main;
        isShooting = false;
    }

    private void Update()
    {
        if (Time.timeScale > 0f)
        {
            if (joystick.Direction != Vector2.zero) isShooting = true;
            else isShooting = false;

            if (isShooting)
            {
                transform.rotation = Quaternion.LookRotation(center.position, joystick.Direction);
                transform.rotation *= Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
