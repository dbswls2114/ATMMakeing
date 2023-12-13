using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{

    public static ButtonManager instance;

    public event Action DepositButton; //입금
    public event Action WithdrawalButton; //출금
    public event Action RemittanceButton; //송금
    public event Action ArrangementPassbookButton; //통장정리

    [SerializeField] private bool[] ButtonsClickBools = new bool[4] { false,false,false,false};

    [SerializeField] private Button[] buttons = new Button[4];
    //private Button[] allButtons;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        
        for (int i = 0; i < this.transform.childCount; i++)
        {           
            buttons[i] = instance.transform.GetChild(i).GetComponent<Button>();
        }
    }

    public void CallDepositButton()
    {
        DepositButton?.Invoke();
        ClearButtonBool();
        ButtonsClickBools[0] = true;
        ClickButtonColor(0);
    }
    public void CallWithdrawalButton()
    {
        WithdrawalButton?.Invoke();
        ClearButtonBool();
        ButtonsClickBools[1] = true;
        ClickButtonColor(1);
    }
    public void CallRemittanceButton()
    {
        RemittanceButton?.Invoke();
        ClearButtonBool();
        ButtonsClickBools[2] = true;
        ClickButtonColor(2);
    }
    public void CallArrangementPassbookButton()
    {
        ArrangementPassbookButton?.Invoke();
        ClearButtonBool();
        ButtonsClickBools[3] = true;
        ClickButtonColor(3);
    }

    private void ClearButtonBool()
    {
        for (int i = 0; i < ButtonsClickBools.Length; i++)
        {
            ButtonsClickBools[i] = false;
            ColorBlock colorBlock = buttons[i].colors;
            colorBlock.normalColor = Color.white;
            colorBlock.selectedColor = Color.white;
            buttons[i].colors = colorBlock;

        }
    }
    private void ClickButtonColor(int a)
    {
        ColorBlock colorBlock = buttons[a].colors;
        colorBlock.normalColor = ButtonsClickBools[a] ? new Color(0, 1f, 0, 1f) : Color.white;
        colorBlock.selectedColor = ButtonsClickBools[a] ? new Color(0, 1f, 0, 1f) : Color.white;

        buttons[a].colors = colorBlock;
    }
}
