using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour
{
    [SerializeField]
    string NameScene = "MenuScene"; // przechowywanie nazwy sceny do której będziemy się przenosić
    void Update()
    {
        if (!Input.GetKey(KeyCode.Escape)) return; // sprawdzanie czy klawisz esc nie został wciśnięty

        if (string.IsNullOrEmpty(NameScene)) // jeśli NameScene będzie pustym 
        {
            Application.Quit(); // stringiem to będziemy zmieniać gre 
        }
        else
        {
            SceneManager.LoadScene(NameScene);// przeniesienie się do innej sceny
        }

    }
}
