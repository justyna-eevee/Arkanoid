using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// generator plansz

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject BlockPrefab; //pobierany prefam ze sceny
    
    void Start()
    {
        LoadLevel("first_level");
        GenerateLevel(3, 5);
    }

    void LoadLevel(string name) // wczytywanie pliku do stworzenia poziomu
    {

        // posługujemy się bazą danych asetów aby odczytać wartość wewnątrz podanego pliku
        var text = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>("Asets/Levels" + name + ".txt").text;


    }

    void GenerateLevel(int width, int height) // funkcja generująca plansze, która będzie przyjmowała wysokość i szerokość planszy 
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var position = new Vector2(j - height/2, -i + width/2); // pozycja każdego z bloku, dzielona na pół aby generowały się na środku planszy a nie od środka
                GenerateBlock(position);
            }
        }
    }

    void GenerateBlock(Vector2 position)// funkcja odpowiedzialna za wygerenowanie pojedynczej instancji prefaba i ustawienie go w odpowiedniej pozycji
    {
        var block = Instantiate(BlockPrefab); // instancja prefaba na scenie
        block.transform.parent = transform; // ustawienie odpowiednie położenie bloku, nasz blok będzie dzieckiem obiektu generującego czyli LevelGenerator
        block.transform.localPosition = position; // przypisanie pozycji względem obiektu rodzica czyli posłużymy się pozycją względną
    }
}
