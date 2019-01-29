using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hordas : MonoBehaviour
{
    public GameObject Panel;

    // Posicion del cual apareceran los enemigos
    public Vector3 spawnPoint;

    // Booleano del estado de los enemigos
    bool TodosMuertos;

    public GameObject[] Prefabs_Enemigos;

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

        ContadorHorda = 1;

        Panel = GameObject.Find("Panel");

        Panel.SetActive(false);
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
            // Vaciamos la lista
            Enemy.Clear();

            if (ContadorHorda < NumeroHordas)
            {
                // Aumentamos los enemigos y los volvemos a generar
                NumeroEnemigos++;

                StartCoroutine("GenerarEnemigos");

                ContadorHorda++;
            }
            else
            {
                Panel.SetActive(true);
            }
        }
    }

    IEnumerator GenerarEnemigos()
    {
        // Esto esta poco optimizado, vere la manera de hacerlo mejor pero por el momento esto fue lo unico que se me ocurrio 

        for(int i = 0; i < NumeroEnemigos; i++)
        {

            // Agarra uno de los prefabs al azar
            int PosPrefab = Random.Range(0, Prefabs_Enemigos.Length);

            // Lo a�adimos a la lista de enemigos
            Enemy.Add(Prefabs_Enemigos[PosPrefab]);

            // Los genera
            Enemy[i] = Instantiate(Prefabs_Enemigos[PosPrefab], spawnPoint, Quaternion.identity);

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