using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    [SerializeField] private Material bgMaterial;
    [Range(-3, 3)][SerializeField] private float speed = 0.17f;
    private SpaceshipController player;
    private void Start()
    {
        player = GameObject.Find("Spaceship").GetComponent<SpaceshipController>();
    }
    private void Update()
    {
        if (!player.IsDead&&!GameManager.Instance.IsPause)
        {
            var newPos = bgMaterial.mainTextureOffset;
            newPos.y += speed * Time.deltaTime;
            bgMaterial.mainTextureOffset = newPos;
        }
    }
}