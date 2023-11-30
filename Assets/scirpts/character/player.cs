using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class player : MonoBehaviour
{
    [Header("camera")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;
    
    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    [SerializeField] private Transform lookAtPoint;
    
    [Header("shooting")]
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Rigidbody bulletPrefabBeeg;
    [SerializeField] private Rigidbody bulletPrefabSmol;
    [SerializeField] private float bulletForce;
    public int currentAmmo; ////////////////////////

    [Header("player UI")] 

    [SerializeField] public TextMeshProUGUI ammo;
    [SerializeField] private Image healthBar;

    [SerializeField] private float maxhealth;
    [SerializeField] public int ammoCounter;
    private float _health;

    [Header("weapons")] 
    [SerializeField] private WeaponBase myWeapon;
    private bool weaponShootToggle;
    [SerializeField] public int gunNumber;
    


    private Vector2 currentRotation;

    private bool isGrounded; //yes or no for for if player is grounded

    private Vector3 _moveDirection;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        ammo.text = currentAmmo.ToString();
        
        InputManager.Init(this); //calls back to this player
        InputManager.GameMode();

        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
{
    transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection); // Move the player
    checkGround();

    
}

    public void SetMoveDirection(Vector3 newDirection) //function for moving
    {
        _moveDirection = newDirection; //sets direction 
    }

    public void Jump()
    {
        Debug.Log("jomp called");
        if (isGrounded)
        {
            Debug.Log("jomped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void checkGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.green, 0, false);
    }
    

    public void SetLookDirection(Vector2 readValue)
    {
        //controls rotation angles
        currentRotation.x += readValue.x * Time.deltaTime * mouseSensX;
        currentRotation.y += readValue.y * Time.deltaTime * mouseSensY;
        
        //rotates left and right
        transform.rotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        
        //clamp rotation angle so you can go above 180
        currentRotation.y = Mathf.Clamp(currentRotation.y, minViewAngle, maxViewAngle);
        
        //rotates up and down
        lookAtPoint.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.right);
        
        
    }

    public void Shoot()
    {
        if (gunNumber == 1)
        {
            const int projectilesToShoot = 1;

            for (int i = 0; i < projectilesToShoot; i++)
            {
                if (currentAmmo > 0)
                {
                    Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                    currentProjectile.AddForce(lookAtPoint.forward * bulletForce, ForceMode.Impulse);

                    Destroy(currentProjectile.gameObject, 3);

                    --currentAmmo;

                    ammo.text = currentAmmo.ToString();
                }
            }
        }
        else if (gunNumber == 2)
        {
            const int projectilesToShoot = 5;

            for (int i = 0; i < projectilesToShoot; i++)
            {
                if (currentAmmo > 0)
                {
                    Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                    currentProjectile.AddForce(lookAtPoint.forward * bulletForce, ForceMode.Impulse);

                    Destroy(currentProjectile.gameObject, 3);

                    --currentAmmo;

                    ammo.text = currentAmmo.ToString();
                }
            }
        }
        else if (gunNumber == 3)
        {
            const int projectilesToShoot = 1;

            for (int i = 0; i < projectilesToShoot; i++)
            {
                if (currentAmmo > 0)
                {
                    Rigidbody currentProjectile = Instantiate(bulletPrefabBeeg, transform.position, Quaternion.identity);

                    currentProjectile.AddForce(lookAtPoint.forward * bulletForce, ForceMode.Impulse);

                    Destroy(currentProjectile.gameObject, 3);

                    currentAmmo -= 5;

                    ammo.text = currentAmmo.ToString();
                }
            }
        }
        else if (gunNumber == 4)
        {
            const int projectilesToShoot = 1;

            for (int i = 0; i < projectilesToShoot; i++)
            {
                if (currentAmmo > 0)
                {
                    Rigidbody currentProjectile = Instantiate(bulletPrefabBeeg, transform.position, Quaternion.identity);

                    currentProjectile.AddForce(lookAtPoint.forward * bulletForce, ForceMode.Impulse);

                    Destroy(currentProjectile.gameObject, 3);

                    currentAmmo -= 5;

                    ammo.text = currentAmmo.ToString();
                }
            }
        }
    }

    /*public void Shoot()
    {
        weaponShootToggle = !weaponShootToggle;
        if(weaponShootToggle) myWeapon.StartShooting();
        else myWeapon.StopShooting();
    }*/
    
    
    public void Reload()
    {
        currentAmmo += 10;
        ammo.text = currentAmmo.ToString();
    }

    public void GunSwap1()
    {
        gunNumber = 1;
    }
    
    public void GunSwap2()
    {
        gunNumber = 2;
    }
    
    public void GunSwap3()
    {
        gunNumber = 3;
    }
    
    public void GunSwap4()
    {
        gunNumber = 4;
    }
}
