using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    // Prefab del Enemigo
    public GameObject Caja;

    // Numero de enemigos que hay en una sola horda
    public int NumeroEnemigos;

    // Lista de los enemigos a generar
    public List<GameObject> Enemy = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < NumeroEnemigos; i++)
        {
            // Añade el GameObject a la Lista
            Enemy.Add(Caja);

            // Instancia a todos los enemigos empezando el juego
            Enemy[i] = Instantiate(Caja, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Mate a un enemigo");
            MatarEnemigo();
        }
    }

    void GenerarEnemigos()
    {

    }

    void MatarEnemigo()
    {
        for(int i = 0; i < Enemy.Capacity; i++)
        {
            if(Enemy[i].activeSelf == true)
            {
                Enemy[i].SetActive(false);
                return;
            }
        }
    }
}
