using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Skrypt odpowiedzialny za logikę aktualnego poziomu, sprawdza poziom, zlicza punkty czy żyć, przenosi do następnej sceny. 


public class GameManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<LevelGenerator>().GenerateLevel("test_level"); // odszukanie skryptu LevelGenerator i wywołanie funkcji generującej poziom
        StartCoroutine(CheckIfLevelendCoroutine()); // uruchamianie korutyny


    }

    IEnumerator CheckIfLevelendCoroutine()// funkcja wywołująca jako korutyna czyli co jakiś czas, musi coś zwracać
    {
        // będzie w pętli uruchamiać funkcję checkIfLevelEnd co sekundę
        while (true)
        {
            CheckIfLevelEnd();
            yield return new WaitForSeconds(1f);
        }
    }

    void CheckIfLevelEnd() // funkcja sprawdzająca koniec rozgrywki
    {
        var numbersOfBlocks = FindObjectsOfType<Block>().Length;//sprawdzenie czy ilość bloków na scenie wynosi zero

        if (numbersOfBlocks == 0)
        {
            SceneManager.LoadScene("MenuScene");// przenoszenie gracza na scene menu
        }
    }

}
