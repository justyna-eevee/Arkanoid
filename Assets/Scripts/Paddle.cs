using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// skrypt odpowiedzialny za obsługę paletki
// jeśli grac będzie naciskał strzałkę w lewo to nadamy paletce ruch w newo, natomiast gdy użytokownik wciśnie strzałkę w prawo to nadamy paletce ruch w prawo
// jeśli grasz nie będzie wciskał przycisku to będziemy zerować aktualną prędkość paletki
// aby wygodnie manipulować prędkością paletki użyjemy elemenu fizycznego Rigidbody2D, ten komponent będzie potrzebny podczas wywołania metody update to
// pobieżemy go w metodzie start i przypiszemy do zmiennej

// jeśli tworzymy skrypty korzystając z jakoś komponentów to bardzo dobrą praktyką jest oznaczanie takich klas poprzez atrybut RequireComponent i w ramach tego atrybutu podajemy jakie komponenty potrzebujemy  

[RequireComponent(typeof(Rigidbody2D))] // takich komponenów może być wiele, po przypisaniu skryptu do obiektu na scenie komponent sam się doda do obiektu oraz nie da się go usuąć 
public class Paddle : MonoBehaviour
{
    [SerializeField]// atrybut pozwalający na widoczność zmiennej z poziomu inspektora
    float Speed = 200f; // zmienna widoczna z inspektora, która umożliwia kontrolę nad prędkością paletki

    Rigidbody2D Rigidbody; // element fizyczny do manipulowania prędkości
    
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // pobieranie elementu fizycznego
    }

    // manipulacja prędkości będzie występowała w funkcji update, dlatego że ta manipulacja będzie związana z fizyką to dodamy słówko Fixed przed Update
    void FixedUpdate()
    {
        var targetSpeed = Vector3.zero; // zmienna przechowująca prędkość, tutaj ma wartość domyślną czyli taką jak się nie porusza

        // wczytujemy czy jakiś klawisz nie został naciśnięty
        // na podstawie tego wyboru będziemy ustawiali odpowiednią wartość prędkości docelowej, która będzie przechowywana w zmiennej 

        if (Input.GetKey(KeyCode.LeftArrow)) // czy nie została naciśnięta strzałka w lewo
        {
            targetSpeed = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // czy nie została naciśnięta strzałka w prawo
        {
            targetSpeed = Vector3.right;
        }

        Rigidbody.velocity = targetSpeed * Speed; // przypisanie nowej wartości prędkości

        // ograniczenie położenia paletk
        var positionX = Mathf.Clamp(transform.position.x, -7.35f, 7.42f); // odczytanie położenia paletki w osi x i ograniczmy tą wartość położenia
        // funkcja Mathf.Clamp przyjmuje 3 argumenty(wartość, wartość minimalna, wartość maksymalna), jeśli zostaną rzekroczone to funkcja ta zwraca albo minimalną albo makcymalną wartość
        transform.position = new Vector3(positionX, transform.position.y); // przypisanie nowego wektora

        
    }
}
