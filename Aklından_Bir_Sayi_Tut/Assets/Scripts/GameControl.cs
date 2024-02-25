using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    int minNumber = 1;
    int maxNumber = 100;
    int guess;
    bool isBegin = false;
    bool isGameOver = false;

    [SerializeField] private TextMeshProUGUI gameText;

    void SetGuess()
    {
        guess = (minNumber + maxNumber) / 2;    // tahmin edilen say�
    }

    void PrintCheck()
    {
        gameText.text = "Is the number you keep in mind " + guess + " ? If it is larger, press the up arrow key; if it is smaller, press the down arrow key; If the guess is correct, press the space bar.";
    }

    void NextStep()     // tek bir fonksiyonda toparlanm�� hali
    {
        SetGuess();
        PrintCheck();
    }

    void Start()
    {
        gameText.text = "Do you want to start the game? (Y/N)";
    }

    void Update()
    {
        if (!isBegin)
        {
            if (Input.GetKeyDown(KeyCode.Y))     // klavyeden E tu�una bas�l�rsa
            {
                gameText.text = "Great! Make a mental note of a number between 1-100 and press Enter.";
            }
            else if (Input.GetKeyDown(KeyCode.N))    // h tu�una bas�lm��sa
            {
                gameText.text = "You know best :(";
            }

            if (Input.GetKeyDown(KeyCode.Return))    // enter tu�una bas�ld�ysa
            {
                NextStep();
                isBegin = true;
            }

        }
        else if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))      // yukar� y�n tu�una bas�ld�ysa
            {
                minNumber = guess;
                NextStep();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))   // a�a�� y�n tu�una basarsa
            {
                maxNumber = guess;
                NextStep();
            }
            else if (Input.GetKeyDown(KeyCode.Space))    // bo�luk tu�una basarsa
            {
                gameText.text = "Hooray! I found the number you had in mind.";
                isGameOver = true;
            }
        }

    }

}