using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Linq; 


//przechowywanie informacji o pojedynczym bloku
[System.Serializable] // atrybut związany z serializowalnością klasy
public class BlockType
{
    public char ColorCharacter; // litera reprezentująca kolor pojedynczego bloku
    public Sprite sprite; // plik graficzny wyświetlony na scenie
}


// generator plansz
public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject BlockPrefab; //pobierany prefam ze sceny

    [SerializeField]
    BlockType[] BlockTypes; // miejsce na wszystkie rodzaje pojedynczych  bloków

    public void GenerateLevel(string LevelName) // funkcja generująca poizom
    {
        var level = LoadLevel(LevelName);
        GeneratorBlocks(level); 
    }

    BlockType[][] LoadLevel(string name) // wczytywanie pliku do stworzenia poziomu, będzie zwracała tablicę dwuwymiarową obiektów typu BlockType
    {
        var path = "Assets/Levels/" + name + ".txt"; // plik do wczytania 
        var text = AssetDatabase.LoadAssetAtPath<TextAsset>(path).text; // posługujemy się bazą danych asetów aby odczytać wartość wewnątrz podanego pliku

        var lines = Regex.Split(text, System.Environment.NewLine); // podzielenie łańcucha znaków na osobne linie
                                                                   // Regex.Split dzieli tekst na kawałki według wzorca, my dzielimy ze względu na nową linie
                                                                   // System.Environment.NewLine do odczytywania znaków nowej lini na systemie operacyjnym

        return ParseLines(lines);
    }

    void GeneratorBlocks(BlockType[][] blocks) // funkcja generująca plansze, która będzie przyjmowała tablice komponentów tekstowych
    {
        var height = blocks.Length; // wysokością będzie długość tablicy
        var width = blocks[0].Length; // długością będzie długość pojedynczego komponentu tekstowego

        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < height; j++)
            {
                var block = blocks[j][i]; // pojedynczy znak
                if (block == null)
                {
                    continue;
                }
                var position = new Vector2(i - width / 2, -j + height / 2); // pozycja każdego z bloku, dzielona na pół aby generowały się na środku planszy a nie od środka
                GenerateBlock(block.sprite, position);
            }
        }
    }

    BlockType ParseCharacter(char character) // funkcja do parsowania znaków
        // dla każdego znaku przeszukamy tablicę bloków i odnajdujemy ten któremu odpowiada dany znak
    {
        return BlockTypes.FirstOrDefault(block => block.ColorCharacter == character); // zwraca null gdy nie znajdzie takiego znaku zamiast zwracać wyjątek
    }

    BlockType[] ParseLine(string text) // funkcja do parsowania pojedynczej lini
    {
        // każdy znak należy przekonwertować na blok 
        return text.Select(ParseCharacter).ToArray(); // funkcja Select zwraca obiekt IEnumerable, który określa wszystkie kolekcje znakowe, aby przekonwertować ten typ do tablicy należy go przekpnwertować do tablicy  
    }

    BlockType[][] ParseLines(string[] text) // funkcja do parsowania wszystkich lini
    {
        return text.Select(ParseLine).ToArray();
    }

    void GenerateBlock(Sprite sprite, Vector2 position)// funkcja odpowiedzialna za wygerenowanie pojedynczej instancji prefaba i ustawienie go w odpowiedniej pozycji
    {
        var block = Instantiate(BlockPrefab); // instancja prefaba na scenie
        block.transform.parent = transform; // ustawienie odpowiednie położenie bloku, nasz blok będzie dzieckiem obiektu generującego czyli LevelGenerator
        block.transform.localPosition = position; // przypisanie pozycji względem obiektu rodzica czyli posłużymy się pozycją względną
        block.GetComponent<SpriteRenderer>().sprite = sprite; // dopisanie grafiki do bloku
    }
}
