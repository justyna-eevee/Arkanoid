using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt nadający prędkość początkową kuli

[RequireComponent(typeof(Rigidbody2D))] // komponent fizyczny
public class Ball : MonoBehaviour
{
    [SerializeField]
    float InitialSpeed = 5f;// zmienna odpowiedzialna za nadanie prędkości kuli
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * InitialSpeed; // pobranie komponentu początkowego i  nadanie prędkości początkowej komponentowi
        // Random.insideUnitCircle.normalized generuje wektor dwuwymiarowy, znajdujący się w okręgu jednostkowym, nie zawsze zwraca wektor o długości 1 dlatego należy go znormalizować wektor
        // w ten sposób zawdze długość wektora będzie rowna 1 a kierunek będzie losowy
    }


}
