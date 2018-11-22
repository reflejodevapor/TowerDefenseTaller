using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    // Booleano del estado de los enemigos
    bool TodosMuertos;

    // Prefab del Enemigo
    public GameObject Enemigo;

    // Numero de enemigos que hay en una sola horda
    public int NumeroEnemigos;

    // Lista de los enemigos a generar
    public List<GameObject> Enemy = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        TodosMuertos = false;

        for(int i = 0; i < NumeroEnemigos; i++)
        {
            // Añade el GameObject a la Lista
            Enemy.Add(Enemigo);

            // Instancia a todos los enemigos empezando el juego
            Enemy[i] = Instantiate(Enemigo, new Vector3(0, 0, 0), Quaternion.identity);
        }
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
        for (int i = 0; i < NumeroEnemigos; i++)
        {
            // Checamos que asi sea
            if(Enemy[i].activeSelf == true)
            {
                // En caso de que no esten todos muertos regresamos la variable a falso
                TodosMuertos = false;
            }
        }

        // Si todos estan muertos...
        if(TodosMuertos == true)
        {
            // Aumentamos los enemigos y los volvemos a generar
            NumeroEnemigos++;
            GenerarEnemigos();
        }
    }

    void GenerarEnemigos()
    {
        Enemy.Clear();

        for(int i = 0; i < NumeroEnemigos; i++)
        {
            Enemy.Add(Enemigo);

            Enemy[i] = Instantiate(Enemigo, new Vector3(0, 0, 0), Quaternion.identity);
        }

        /*for (int i = 0; i < NumeroEnemigos; i++)
        {
            if(Enemy[i] == null)
            {
                Enemy.Add(Caja);
            }
            else if (Enemy[i].activeSelf == false)
            {
                Enemy[i].SetActive(true);
            }
        }*/
    }

    void MatarEnemigo()
    {
        for(int i = 0; i < Enemy.Capacity; i++)
        {
            if (Enemy[i].activeSelf == true)
            {
                
                Enemy[i].SetActive(false);
                return;
            }
        }
    }
}
