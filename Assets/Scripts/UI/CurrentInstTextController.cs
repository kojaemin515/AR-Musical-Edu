using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CurrentInstTextController : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    private string SnareText = "ÇöÀç ¾Ç±â : ½º³×¾îµå·³";
    private string TimpaniText = "ÇöÀç ¾Ç±â : ÆÀÆÄ´Ï";
    private string CymbalsText = "ÇöÀç ¾Ç±â : ½É¹úÁî";

    private int currentInstrument = GamePlayManager.GetInstrument();

    public void ChangeDisplayText()
    {
        switch (currentInstrument)
        {
            case 0:
                DisplayText.text = SnareText;
                break;
            case 1:
                DisplayText.text = TimpaniText;
                break;
            case 2:
                DisplayText.text = CymbalsText;
                break;
        }
    }
}
