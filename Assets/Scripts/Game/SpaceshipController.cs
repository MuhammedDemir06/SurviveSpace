using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipController : MonoBehaviour,PlayerDamage
{
    [Header("Spaceship Controller")]
    [Range(2, 16)][SerializeField] private float speed = 8f;
    [SerializeField] private float horizontalBoundary = 5f;
    public int HealthValue = 100;
    public bool IsDead;
    private float inputX;
    [SerializeField] private GameUIManager UIManager;
    [Header("Damage Shake")]
    [SerializeField] private CameraShake damageShake;
    [SerializeField] private float duration;
    [SerializeField] private float magnitude;
    [Header("Sound")]
    [SerializeField] private AudioSource soundLost;
    [SerializeField] private AudioSource soundDamage;
    public void GetInput(float index)
    {
        switch (index)
        {
            case 0:
                inputX = 1f;
                break;
            case 1:
                inputX = -1f;
                break;
            case 2:
                inputX = 0f;
                break;
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.right * inputX * speed * Time.deltaTime);
    }
    private void Boundary()
    {
        //Horizontal 
        var newBoundary = Mathf.Clamp(transform.position.x, -horizontalBoundary, horizontalBoundary);
        transform.position = new Vector2(newBoundary, transform.position.y);
    }
    public void PlayerTakeDamage(int damageAmount)
    {
        HealthValue -= damageAmount;
        UIManager.HealthValue = HealthValue;
        if (HealthValue <= 0)
        {
            IsDead = true;
            HealthValue = 0;
            soundLost.Play();
        }  
        UIManager.HealthUpdate();
    }
    private void Update()
    {
        Boundary();
    }
    private void LateUpdate()
    {
        if (!GameManager.Instance.IsPause)
            Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Astreoid")
        {
            print("Damage");
            StartCoroutine(damageShake.Shake(0.5f, 0.3f));
            soundDamage.Play();
        }
    }
}