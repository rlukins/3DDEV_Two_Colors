using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health;
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        
    }

    public void Damage(int amount) {
        health -= amount;
    }
}
