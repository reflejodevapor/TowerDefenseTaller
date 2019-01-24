using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace turretGame { 
[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoTerrestre : Enemigo {

    protected NavMeshAgent nav; // necesita el navmesh para hacer el pathfinding en automático
    private float v_velocidad; // esto se usa solo para calcular los deltas de velocidad

    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = velocidad; //Setteamos la velocidad a la que se mueve
        v_velocidad = velocidad;


        if (meta == null)
        {
            meta = GameObject.FindGameObjectWithTag("Meta").gameObject;
        }

        nav.SetDestination(meta.transform.position);
    }

    protected override void OnUpdate() //La base lo llama en cada frame de Update()
    {
        base.OnUpdate();
        if (v_velocidad != velocidad)
        {
            nav.speed = velocidad;
            v_velocidad = velocidad;
        }
    }
}
}