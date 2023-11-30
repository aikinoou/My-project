using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{

    [SerializeField] private Rigidbody Bullet1;
    [SerializeField] private Rigidbody Bullet2;
    [SerializeField] private float force = 50;

    protected override void Attack(float percent)
    {
        print("my weapon attack : " + percent);
        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(percent > 0.5f ? Bullet1 : Bullet2, camRay.origin, transform.rotation);
        rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
    }
}
