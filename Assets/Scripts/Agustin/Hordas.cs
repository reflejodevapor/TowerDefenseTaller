using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hordas : MonoBehaviour
{
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
	int ContadorHorda = 0;

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
			ContadorHorda++;

			if (ContadorHorda < NumeroHordas) {
				// Aumentamos los enemigos y los volvemos a generar
				NumeroEnemigos++;

                // Vaciamos la lista
                Enemy.Clear();

				StartCoroutine ("GenerarEnemigos");
			} else 
			{
                // Escena en la que estamos actualmente
                int EscenaActual = SceneManager.GetActiveScene().buildIndex;
                
                //Carga el siguiente nivel
                SceneManager.LoadScene(EscenaActual + 1);
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

            // Lo añadimos a la lista de enemigos
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