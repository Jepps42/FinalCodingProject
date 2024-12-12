using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEditor.Build;

public class ASCIILevel : MonoBehaviour
{
    //Variables
    public float xOffset;

    public float yOffset;

    //prefabs for the gameObjects we want
    public GameObject wall;

    public GameObject floor;

    public GameObject enemy;

    public GameObject key;

    public GameObject newObject;
    //Variables for current player
    public GameObject currentPlayer;

    //Variable for starting position of player
    Vector2 startPos;

    //Name for the level file
    public string fileName;

    //variable for our current level number
    public int currentLevel = 0;

    //empty game object to hold level
    public GameObject level;

    //When the level changes, need to load the level
    //Make currentLevel a property
    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    private void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        //Destroy current level
        Destroy(level);

        //Create a new level gameObject
        level = new GameObject("Level");

        //build a new level path based on the currentLevel
        string current_file_path = Application.dataPath + "/Resources" + fileName.Replace("Num", currentLevel + "");

        //pull the contents of the file into a string array
        //each line of the file will be an item will be an item in the array, pretty much translating into a language for ASCII to read the file
        string[] fileLines = File.ReadAllLines(current_file_path);

        //loop through each character in the file 
        for (int y = 0; y < fileLines.Length; y++)
        {
            //get the current line
            string lineText = fileLines[y];

            //split the line into a char array
            char[] characters = lineText.ToCharArray();

            //loop through each character we made
            for (int x = 0; x < characters.Length; x++)
            {
                //take the current character
                char c = characters[x];

                //Variable for the new object
                GameObject newObject;

                //write a switch statement for the character to determine what it means
                switch (c)
                {
                    //save position to the startPos to use for resetting the player
                    case 'p':
                        startPos = new Vector2(x + xOffset, -y + yOffset);
                        break;
                    //write a case where if the character is w, make a wall
                    case 'w':
                        //make a wall
                        newObject = Instantiate<GameObject>(wall);
                        break;
                    //write a case where if the character is a * make a key
                    case '*':
                        newObject = Instantiate<GameObject>(key);
                        break;
                    //case for floor
                    case '-':
                        newObject = Instantiate<GameObject>(floor);
                        break;
                    //case for enemy
                    case '&':
                        newObject = Instantiate<GameObject>(enemy);
                        break;
                    //if it is any other character go to default and leave the space blank
                    default:
                        newObject = null;
                        break;
                }

            }
        }
    }
}
