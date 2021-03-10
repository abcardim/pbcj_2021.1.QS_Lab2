using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCartas : MonoBehaviour
{
    public GameObject carta;        // A carta a ser descartada

    // Start is called before the first frame update
    void Start()
    {
        MostraCartas();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MostraCartas()
    {
        int[] arrayEmbaralhado = criaArrayEmbaralhado();
        int[] arrayEmbaralhado2 = criaArrayEmbaralhado();

        for (int i=0; i<13; i++)
        {
            AddUmaCarta(0, i, arrayEmbaralhado[i]);
            AddUmaCarta(1, i, arrayEmbaralhado2[i]);
        }

        {
            //Códigos utilizados anteiormente
            //Instantiate(carta, new Vector3(0, 0, 0), Quaternion.identity);
            //AddUmaCarta();
            //AddUmaCarta(i);
            //AddUmaCarta(i, arrayEmbaralhado[i]);
        }
    }

    void AddUmaCarta(int linha, int rank, int valor)
    {
        GameObject centro = GameObject.Find("centroDaTela");
        float escalaCartaOriginal = carta.transform.localScale.x;
        float fatorEscalaX = (650 * escalaCartaOriginal) / 110.0f;
        float fatorEscalaY = (945 * escalaCartaOriginal) / 110.0f;

        Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y + ((linha - 2 / 2) * fatorEscalaY), centro.transform.position.z);
        GameObject c = (GameObject)(Instantiate(carta, novaPosicao, Quaternion.identity));
        c.tag = "" + (valor+1);
        c.name = "" + linha + "_" + valor;
        string nomeDaCarta = "";
        string numeroCarta = "";
        

        if (valor == 0)
            numeroCarta = "ace";
        else if (valor == 10)
            numeroCarta = "jack";
        else if (valor == 11)
            numeroCarta = "queen";
        else if (valor == 12)
            numeroCarta = "king";
        else
            numeroCarta = "" + (valor + 1);
       
        if (linha == 1)
            nomeDaCarta = numeroCarta + "_of_clubs";
        else
            nomeDaCarta = numeroCarta + "_of_diamonds";

        Sprite s1 = (Sprite)(Resources.Load<Sprite>(nomeDaCarta));
        print("S1: " + s1);
        
        GameObject.Find("" + linha + "_" + valor).GetComponent<Tile>().SetCartaOriginal(s1);

        {
            //Códigos utilizados anteriormente
            //GameObject c = (GameObject)(Instantiate(carta, new Vector3(0, 0, 0), Quaternion.identity));
            //Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((rank - 13 / 2) * 1.3f), centro.transform.position.y, centro.transform.position.z);
            //GameObject c = (GameObject)(Instantiate(carta, new Vector3(rank*1.5f, 0, 0), Quaternion.identity));
            /*if (rank == 0)
                numeroCarta = "ace";
            else if (rank == 10)
                numeroCarta = "jack";
            else if (rank == 11)
                numeroCarta = "queen";
            else if (rank == 12)
                numeroCarta = "king";
            else
                numeroCarta = "" + (rank + 1);*/   // else if para array ordenado no deck
                                                   // GameObject.Find("" + rank).GetComponent<Tile>().SetCartaOriginal(s1);
            //Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y, centro.transform.position.z);
            // c.name = "" + valor;
        }
    }

    public int[] criaArrayEmbaralhado()
    {
        int[] novoArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int temp;
        for(int t=0; t<13; t++)
        {
            temp = novoArray[t];
            int r = Random.Range(t, 13);
            novoArray[t] = novoArray[r];
            novoArray[r] = temp;
        }
        return novoArray;
    }
}
