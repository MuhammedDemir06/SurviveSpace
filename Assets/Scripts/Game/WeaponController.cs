using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float distance;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject fireEffect;
    public bool IsFire;
    private int fireIndex;

    private void OnEnable()
    {
        GameUIManager.Fire += Fire;
        GameUIManager.DontFire += FireDisable;
    }
    private void OnDisable()
    {
        GameUIManager.Fire -= Fire;
        GameUIManager.DontFire -= FireDisable;
    }
    private void Start()
    {
        fireIndex = 1;
    }
    private void Fire()
    {
        fireIndex = 0;
        fireEffect.SetActive(true);
    }
    private void FireDisable()
    {
        fireIndex = 1;
        lr.gameObject.SetActive(false);
        fireEffect.SetActive(false);
    }
    private void Update()
    {
        if (fireIndex == 0 && IsFire&&!GameManager.Instance.IsPause)
        {
            lr.gameObject.SetActive(true);
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, transform.TransformDirection(Vector2.up), distance);
            if (hit.collider != null)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.point);

                Shoot weaponShoot = hit.collider.GetComponent<Shoot>();
                weaponShoot.Damage(damage);
                print("Damage");
            }
            else if (hit.collider == null)
            {
                Debug.DrawLine(transform.position, firePoint.position + transform.up * distance, Color.red);
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, firePoint.position + transform.up * distance);
                print("No Damage");
            }
        }
    }
}
