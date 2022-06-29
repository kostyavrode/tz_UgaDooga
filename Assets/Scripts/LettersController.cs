using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LettersController : MonoBehaviour
{
    private char[] letters = "ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß".ToCharArray();
    public void SetLetters(TMP_Text text)
    {
        text.text = letters[Random.Range(0, letters.Length)].ToString();
    }
}
