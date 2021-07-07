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
        var finished = PlayerPrefs.GetInt(levelName + "_finished", 0) !=0; // odczytanie czy poziom został ukończony, 0 oznacza, że poziom nie został ukomczony 
                                                                           // PlayerPrefs nie przechowuje wartości logicznych
                                                                           // !=0 jeśłi pod tym kluczem będzie jakakolwiek inna wartość różna od zera to znaczy, że poziom został ukończony
        GetComponent<Image>().color = finished ? Color.green : Color.white; // zmiana koloru przycisku gdy poziom zostanie ukończony 
        GetComponentInChildren<Text>().text = levelName; // ustawienie odpowiedniego tekstu na przycisku
        GetComponent<Button>().onClick.AddListener(ChangeScene); // odszukanie komponentu przycisku i odwołamy się do zdarzenia onClick, nastepnie odwołamy się do subskrybenta, która przyjmuje inną funkcję
       
    }

    void ChangeScene()// metoda wykonywania w trakcie kliknięcia
    {
        SceneManager.LoadScene("GameScene"); // ładowanie sceny z grą
        PlayerPrefs.SetString("current_level", levelName); // zapisanie nazwy poziomu do załadowania
    }
}
