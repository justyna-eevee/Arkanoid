using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Skrypt odpowiedzialny za logikę aktualnego poziomu, sprawdza poziom, zlicza punkty czy żyć, przenosi do następnej sceny. 


public class GameManager : MonoBehaviour
{
    string levelName; // zmianna odpowiedzialna za aktualny poziom
    void Start()
    {
        levelName = PlayerPrefs.GetString("current_level"); // załadowanie aktualnego poziomu
        FindObjectOfType<LevelGenerator>().GenerateLevel(levelName); // odszukanie skryptu LevelGenerator i wywołanie funkcji generującej poziom
        StartCoroutine(LevelendCoroutine()); // uruchamianie korutyny
    }

    IEnumerator LevelendCoroutine()// funkcja wywołująca jako korutyna czyli co jakiś czas, musi coś zwracać
    {
        // będzie w pętli uruchamiać funkcję checkIfLevelEnd co sekundę
        while (true)
        {
            if (CheckIfLevelEnd())
            {
                ChangeScene(); 
            }
            yield return new WaitForSeconds(1f);
        }
    }

    bool CheckIfLevelEnd() // funkcja sprawdzająca koniec rozgrywki
    {
        return FindObjectsOfType<Block>().Length == 0;//sprawdzenie czy ilość bloków na scenie wynosi zero

    }

    void ChangeScene() // funkcja zmieniająca scene i zmienianie ukonczenie poziomu
    {
        PlayerPrefs.SetInt(levelName + "_finished", 1); // zmiana koloru guzika jak poziom został ukończony
        SceneManager.LoadScene("MenuScene");// przenoszenie gracza na scene menu
    }

}
