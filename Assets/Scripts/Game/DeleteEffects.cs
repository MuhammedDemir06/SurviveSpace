using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEffects : MonoBehaviour
{
    [SerializeField] private float deleteTime = 0.417f;
    private void Start()
    {
        Destroy(gameObject, deleteTime);
    }
}
