using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidController : MonoBehaviour,Shoot
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float healthValue;
    [SerializeField] private int scoreValue;
    [SerializeField] private int damage = 15;
    private GameUIManager managerUI;
    [SerializeField] private GameObject explosionEffect;
    private void Start()
    {
        managerUI = GameObject.Find("Canvas").gameObject.GetComponent<GameUIManager>();

        Destroy(gameObject, 8f);
    }
    public void Damage(float damageAmount)
    {
        healthValue -= damageAmount * Time.deltaTime;
        if (healthValue <= 0)
        {
            managerUI.Score += scoreValue;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if(GameManager.Instance.IsPause)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDamage newDamage = collision.GetComponent<PlayerDamage>();
            newDamage.PlayerTakeDamage(damage);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
