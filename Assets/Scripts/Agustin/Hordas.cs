using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    public Vector3 spawnPoint;

    // Booleano del estado de los enemigos
    bool TodosMuertos;

    // Prefab del Enemigo
    public GameObject Enemigo;

    // Numero de enemigos que hay en una sola horda
    public int NumeroEnemigos;

    // Lista de los enemigos a generar
    public List<GameObject> Enemy = new List<GameObject>();

    // Cuantas hordas habra por nivel
    public int NumeroHordas;

    // Contador que te dice en que horda estas
    int ContadorHorda;

    // Use this for initialization
    void Start()
    {
        TodosMuertos = false;

        StartCoroutine("GenerarEnemigos");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MatarEnemigo();
        }

        // Suponemos que todos los enemigos ya murieron
        TodosMuertos = true;
        for (int i = 0; i < Enemy.Count; i++)
        {
            // Checamos que asi sea
            if (Enemy[i].activeSelf == true)
            {
                // En caso de que no esten todos muertos regresamos la variable a falso
                TodosMuertos = false;
            }
        }

        // Si todos estan muertos...
        if (TodosMuertos == true)
        {
            // Aumentamos los enemigos y los volvemos a generar
            NumeroEnemigos++;

            // Vaciamos la lista
            Enemy.Clear();

            //GenerarEnemigos();

            StartCoroutine("GenerarEnemigos");
        }
    }

    IEnumerator GenerarEnemigos()
    {
        // Esto esta poco optimizado, vere la manera de hacerlo mejor pero por el momento esto fue lo unico que se me ocurrio 

        for(int i = 0; i < NumeroEnemigos; i++)
        {
            Enemy.Add(Enemigo);

            // Los genera
            Enemy[i] = Instantiate(Enemigo, spawnPoint, Quaternion.identity);

            yield return new WaitForSeconds(2.0f);
        }
    }

    void MatarEnemigo()
    {
        for (int i = 0; i < Enemy.Capacity; i++)
        {
            if (Enemy[i].activeSelf == true)
            {

                Enemy[i].SetActive(false);
                return;
            }
        }
    }
}