using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AstreoidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] astreoid;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private SpaceshipController shipManager;
    private int index;
    //
    [SerializeField] private float spawnPosY;
    [Tooltip("Random Spawn=-spawnX,spawnX")] [SerializeField] private float spawnPosX;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        while(!shipManager.IsDead)
        {
            index = Random.Range(0, astreoid.Length);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(astreoid[index], new Vector2(Random.Range(-spawnPosX, spawnPosX), spawnPosY), Quaternion.identity);
        }
    }
}
