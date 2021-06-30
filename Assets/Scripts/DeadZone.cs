using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// skrypt obsługujący wypadnięcie kulki z planszy
[RequireComponent(typeof(Collider2D))] // klasa macierzysta koliderów 
public class DeadZone : MonoBehaviour

{
    [SerializeField]
    string SceneName = "MenuScene"; // zmienna przechowująca scene do przełączenia po wypadnięciu piłeczki
    private void OnTriggerEnter2D(Collider2D collision) // funkcja wywołujaca w momencie zderzenia
    {
        if (collision.gameObject.GetComponent<Ball>() != null) // jeśli obiekt wpadający na komponent nie jest kulą to pomijamy to zdarzenie
        {
            SceneManager.LoadScene(SceneName); // zmiana sceny w momencie zderzenia
        }
    }
}
