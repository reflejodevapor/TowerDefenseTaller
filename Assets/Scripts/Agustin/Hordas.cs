using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hordas : MonoBehaviour
{
    public GameObject[] spawnObjects;

    public Text hordasTexto;


    // Prefab del Enemigo
    public GameObject Enemigo;

    // Numero de enemigos que hay en una sola horda
    public int NumeroEnemigos;
    public int numeroHordas;


    public int contadorHorda;

    public Transform enemigoContainer;
    bool generandoEnemigos;



    void Start()
    {
        //generandoEnemigos = true;

        //StartCoroutine(GenerarEnemigos(2));
        
    }

    void Update()
    {
        hordasTexto.text = contadorHorda.ToString() + "/" + numeroHordas.ToString(); 
        if(enemigoContainer.childCount <= 0 && !generandoEnemigos)
        {
            print("Traga sables");
            generandoEnemigos = true;
            StartCoroutine(GenerarEnemigos(0));
        }
    }

    
    IEnumerator GenerarEnemigos(float _tiempo)
    {
        print("Daniel traga mecos");
        if (generandoEnemigos)
        {
            yield return new WaitForSeconds(_tiempo);

            for (int i = 0; i < NumeroEnemigos; i++)
            {
                Instantiate(Enemigo, spawnObjects[Random.Range(0, spawnObjects.Length -1)].transform.position, Quaternion.identity, enemigoContainer);
                yield return new WaitForSeconds(1.0f);
            }
            generandoEnemigos = false;
            contadorHorda++;
        }
    }
    
}