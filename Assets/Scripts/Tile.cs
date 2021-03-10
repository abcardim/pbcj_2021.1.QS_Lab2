using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool tileRevealed = false;  //indicador da carta virada ou não
    public Sprite originalCarta;        // Sprite da carta desejada
    public Sprite backCarta;            // Sprite do verso da carta
    // Start is called before the first frame update
    void Start()
    {
        EscondeCarta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        print("Voce pressionou num Tile");
        if (tileRevealed)
            EscondeCarta();
        else
            RevelaCarta();
    }

    public void EscondeCarta()
    {
        GetComponent<SpriteRenderer>().sprite = backCarta;
        tileRevealed = false;
    }

    public void RevelaCarta()
    {
        GetComponent<SpriteRenderer>().sprite = originalCarta;
        tileRevealed = true;
    }

    public void SetCartaOriginal(Sprite novaCarta)
    {
        originalCarta = novaCarta;
    }


}
