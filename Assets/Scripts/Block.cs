using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt odpowiedzialny za usuwanie klocka po jego dotknięciu kulą 

[RequireComponent(typeof(Collider2D))] // klasa macierzysta koliderów
public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // funkcja wywołujaca w momencie zderzenia
    {
        Destroy(gameObject); // usuwanie klocka w momencie zderzenia 
    }
}
