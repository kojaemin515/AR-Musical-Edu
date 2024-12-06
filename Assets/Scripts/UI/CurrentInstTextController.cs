using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CurrentInstTextController : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    private string SnareText = "���� �Ǳ� : ���׾�巳";
    private string TimpaniText = "���� �Ǳ� : ���Ĵ�";
    private string CymbalsText = "���� �Ǳ� : �ɹ���";

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
