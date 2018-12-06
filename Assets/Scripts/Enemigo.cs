/*
 * Clase base del enemigo, de aqui deberan heredar todos los tipos de enemigo
 * solo para modificar sus atributos descritos mas abajo y sobrecargar métodos
 * 
 * Todo está en pocho. Siéntanse libres de renombrar lo que sea.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemigo : MonoBehaviour {

    protected NavMeshAgent nav; // necesita el navmesh para hacer el pathfinding en automático
    [Header("Atributos del enemigo base")]
    [SerializeField] protected GameObject meta; // la posicion a donde se va a mover y también para reducir el daño al golpear
    [SerializeField] protected float velocidad; //Velocidad a la que se mueve
    private float v_velocidad; // esto se usa solo para calcular los deltas de velocidad
    [SerializeField] protected float vida; //la cantidad de vida que puede recibir
    [SerializeField] protected float danio; // Daño que causa con cada ataque
    [SerializeField] protected float dinero; // El dinero que suelta al morir



	void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = velocidad; //Setteamos la velocidad a la que se mueve
        v_velocidad = velocidad;

		
		if (meta == null)
		{
			meta = GameObject.FindGameObjectWithTag ("Meta").gameObject;
		} 

		nav.SetDestination (meta.transform.position);

        
	}

    void Update()
    {
        if (v_velocidad != velocidad)
        {
            nav.speed = velocidad;
            v_velocidad = velocidad;
        }
    }

    /// <summary>
    /// Se llama este metodo cuando se recibe daño. se recibe el daño como argumento dado que cada torreta hace daño disinto
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            vida = 0;
            //TO DO : handle enemy death properly

           
			this.gameObject.SetActive(false);
        }
    }
}
