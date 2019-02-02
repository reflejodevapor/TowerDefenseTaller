/*
 * Clase base del enemigo, de aqui deberan heredar todos los tipos de enemigo
 * solo para modificar sus atributos descritos mas abajo y sobrecargar métodos
 * 
 * Todo está en pocho. Siéntanse libres de renombrar lo que sea.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace turretGame{
    public class Enemigo : MonoBehaviour {

    
        [Header("Atributos del enemigo base")]
        [SerializeField] protected GameObject meta; // la posicion a donde se va a mover y también para reducir el daño al golpear
        [SerializeField] protected float velocidad; //Velocidad a la que se mueve
    
        [SerializeField] protected float vida; //la cantidad de vida que puede recibir
        [SerializeField] protected float danio; // Daño que causa con cada ataque
        [SerializeField] protected int dinero; // El dinero que suelta al morir
        [Tooltip("Distancia necesaria para contar que llegó a la meta")]
        [SerializeField] protected float WinOffset; // Distancia necesaria para contar que llegó a la meta

        public bool hit = false;


	void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = velocidad; //Setteamos la velocidad a la que se mueve
        v_velocidad = velocidad;
        DevelopTorretasGameplay

        void Update()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate() //Esta base existe para poder ser sobrecargada en los objetos que de aqui hereden
        {
            //Para verificar cuando llegó a la meta
            if (Vector3.Distance(transform.position, meta.transform.position) < WinOffset)
            {
                UIManager.RecibeDanio(danio);
                gameObject.SetActive(false);
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
                UIManager.dinero += dinero;
                this.gameObject.SetActive(false);
            
            }
        }
    }
}