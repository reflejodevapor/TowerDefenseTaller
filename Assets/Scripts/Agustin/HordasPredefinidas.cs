using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HordasPredefinidas : MonoBehaviour {

    // Posicion del cual apareceran los enemigos
    public Vector3 spawnPoint;

    // Booleano del estado de los enemigos
    bool TodosMuertos;

    public GameObject[] Prefabs_Enemigos;

    // Numero de enemigos que hay en una sola horda
    public int NumeroEnemigos;

    // Cuantas hordas habra por nivel
    public int NumeroHordas;

    // Contador que te dice en que horda estas
    int ContadorHorda = 0;

    // Pool de los enemigos
    public List<GameObject> Enemigos = new List<GameObject>();
    // Funcion para generar a los enemigos
    GameObject GenerateEnemy()
    {
        for (int i = 0; i < Enemigos.Count; i++)
        {
            // Checamos si todos los enemigos estan apagados
            if (Enemigos[i].activeSelf == false)
            {
                // Lo volvemos a activar
                Enemigos[i].SetActive(true);
                // Reseteamos su posicion
                Enemigos[i].transform.position = spawnPoint;
                return Enemigos[i];
            }
        }

        // Si no hay ningun enemigo en el pool, agarramos un prefab al azar
        int PrefabSeleccionado = Random.Range(0, Prefabs_Enemigos.Length);

        // Generamos el enemigo nuevo
        GameObject go = Instantiate(Prefabs_Enemigos[PrefabSeleccionado], spawnPoint, Quaternion.identity);
        // Lo agregamos al pool
        Enemigos.Add(go);
        return go;
    }


    // Use this for initialization
    void Start ()
    {
        TodosMuertos = false;

        StartCoroutine("GenerarEnemigos");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MatarEnemigo();
        }

        // Suponemos que todos los enemigos ya murieron
        TodosMuertos = true;
        for (int i = 0; i < Enemigos.Count; i++)
        {
            // Checamos que asi sea
            if (Enemigos[i].activeSelf == true)
            {
                // En caso de que no esten todos muertos regresamos la variable a falso
                TodosMuertos = false;
            }
        }

        // Si todos estan muertos...
        if (TodosMuertos == true)
        {
            ContadorHorda++;

            if (ContadorHorda < NumeroHordas)
            {
                // Aumentamos los enemigos y los volvemos a generar
                NumeroEnemigos++;

                // Vaciamos la lista
                //Enemy.Clear();

                StartCoroutine("GenerarEnemigos");
            }
            else
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

        for (int i = 0; i < NumeroEnemigos; i++)
        {

            GameObject Enemigo = GenerateEnemy();

            yield return new WaitForSeconds(2.0f);
        }
    }

    void MatarEnemigo()
    {
        for (int i = 0; i < Enemigos.Capacity; i++)
        {
            if (Enemigos[i].activeSelf == true)
            {

                Enemigos[i].SetActive(false);
                return;
            }
        }
    }
}
