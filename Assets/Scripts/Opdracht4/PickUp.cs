using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int points;
    public static event Action<int> OnPickUp;

    private void OnTriggerEnter(Collider other)
    {
        OnPickUp?.Invoke(points);
        Destroy(gameObject);
    }



}