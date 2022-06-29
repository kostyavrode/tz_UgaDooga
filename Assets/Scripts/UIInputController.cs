using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIInputController : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] inputField;
    public static Action<int,int> onGenerateButtonDown;
    public static Action onMixButtonDown;
    private int a = 0;
    public void GenerateButton()
    {
        int num1=0;
        int num2=0;
        for(int i=0;i<inputField.Length;i++)
        {
            switch(i)
            {
                case 0:
                    if (inputField[i].text == "")
                        num1 = 0;
                    else
                    num1 = int.Parse(inputField[i].text);
                    break;
                case 1:
                    if (inputField[i].text == "")
                        num2 = 0;
                    else
                        num2 = int.Parse(inputField[i].text);
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
            if(num1!=0&&num2!=0)
            {
                onGenerateButtonDown?.Invoke(num1, num2);
            }
        }
    }   
    public void SortButton()
    {
        onMixButtonDown?.Invoke();
    }
}
