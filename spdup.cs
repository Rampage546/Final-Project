using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spdup : MonoBehaviour
{
    private ParticleSystem ps;

    public GameController gc;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        var main = ps.main;

        if (gc.checker == 1)
        {
            main.simulationSpeed = 10;
        }

    }
}
