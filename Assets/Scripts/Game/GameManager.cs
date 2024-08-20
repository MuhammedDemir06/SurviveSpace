using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsPause;
    [Header("Astreoid Spawner")]
    [SerializeField] private AstreoidSpawner astreoidSpawner;
    private void Awake()
    {
        Instance = this;
    }
    private void AsSpawnerController()
    {
        if (IsPause)
            astreoidSpawner.enabled = false;
        else
            astreoidSpawner.enabled = false;
    }
    private void Update()
    {
        AsSpawnerController();
    }
}