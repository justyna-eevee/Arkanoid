using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    string levelName; // nazwa poziomu do którego pędzie przekierowywał nasz przycisk
    void Start()
    {
        GetComponentInChildren<Text>().text = levelName; // ustawienie odpowiedniego tekstu na przycisku
        GetComponent<Button>().onClick.AddListener(ChangeScene); // odszukanie komponentu przycisku i odwołamy się do zdarzenia onClick, nastepnie odwołamy się do subskrybenta, która przyjmuje inną funkcję
       
    }

    void ChangeScene()// metoda wykonywania w trakcie kliknięcia
    {
        SceneManager.LoadScene("GameScene"); // ładowanie sceny z grą
    }
}
