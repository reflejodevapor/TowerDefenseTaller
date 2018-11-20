/*
 * Clase base del enemigo, de aqui deberan heredar todos los tipos de enemigo
 * solo para modificar sus atributos descritos mas abajo y sobrecargar métodos
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour {

    protected NavMeshAgent nav; // necesita el navmesh para hacer el pathfinding en automático
    [Header("Atributos del enemigo base")]
    [SerializeField] protected Transform meta; // la posicion a donde se va a mover
    protected float velocidad; //Velocidad a la que se mueve
    protected float vida; //la cantidad de vida que puede recibir
    protected float danio; // Daño que causa con cada ataque

	void Start () {
        nav = GetComponent<NavMeshAgent>();
        if (meta != null)
        {
            nav.SetDestination(meta.position);
        }
        
	}
}
