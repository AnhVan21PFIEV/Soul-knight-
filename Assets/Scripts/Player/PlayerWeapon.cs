using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform weaponPos;

    private PlayerActions actions;
    private PlayerMovement playerMovement;
    private Weapon currentWeapon;

    private void Awake()
    {
        actions = new PlayerActions();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        actions.Weapon.Shoot.performed += ctx => ShootWeapon();
        CreateWeapon(initialWeapon);
    }


    private void Update()
    {
        if (playerMovement.MoveDirection != Vector2.zero)
        {
            RotateWeapon(playerMovement.MoveDirection);
        }
    }

    private void CreateWeapon(Weapon weaponPrefab)
    {
        currentWeapon = Instantiate(weaponPrefab, weaponPos.position,
            Quaternion.identity, weaponPos);
    }

    private void ShootWeapon()
    {
        if (currentWeapon == null)
        {
            return;
        }

        currentWeapon.UseWeapon();
    }

    private void RotateWeapon(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.x >0f)
        {
            weaponPos.localScale = Vector3.one;
            currentWeapon.transform.localScale = Vector3.one;
        }
        else
        {
            weaponPos.localScale = new Vector3(-1, 1, 1);
            currentWeapon.transform.localScale = new Vector3(-1, -1, 1);
        }


        currentWeapon.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

}
