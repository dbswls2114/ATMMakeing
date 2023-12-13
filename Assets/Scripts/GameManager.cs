using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EventName
{
    Deposit,
    Withdrawal,
    Remittance,
    ArrangementPassbook
}

public class GameManager : MonoBehaviour
{
    public ButtonManager buttonManager;

    private static long passBookCash = 0;
    private static long walletCash = 100000;

    public TMP_Text PassbookTxt;
    public TMP_Text WalletTxt;

    public event Action ChackButton;

    private void Start()
    {
        buttonManager = ButtonManager.instance;
        PassbookTxt.text = passBookCash.ToString();
        WalletTxt.text = walletCash.ToString();

        buttonManager.DepositButton += () => ChackButtonEvent(EventName.Deposit);
        buttonManager.WithdrawalButton += () => ChackButtonEvent(EventName.Withdrawal);
        buttonManager.RemittanceButton += () => ChackButtonEvent(EventName.Remittance);
        buttonManager.ArrangementPassbookButton += () => ChackButtonEvent(EventName.ArrangementPassbook);

    }

    public void ChackButtonEvent(EventName eventName)
    {
        ChackButton = null;
        switch (eventName)
        {
            case EventName.Deposit:
                ChackButton += Deposit;                
                break; //여기서 chackbutton이벤트를 능동적으로 구독,구독해제
            case EventName.Withdrawal:
                ChackButton += Withdrawal;
                break;
            case EventName.Remittance:
                ChackButton += Remittance;
                break;
            case EventName.ArrangementPassbook:
                ChackButton += ArrangementPassbook;
                break;
        }
    }

    public void CallChackButton() //버튼에 넣을것
    {
        ChackButton?.Invoke();
    }

    private void Deposit()
    {
        // 입금로직
        Debug.Log("Deposit");
    }

    private void Withdrawal()
    {
        //출금로직
        Debug.Log("Withdrawal");
    }

    private void Remittance()
    {
        //송금로직
        Debug.Log("Remittance");
    }

    private void ArrangementPassbook()
    {
        //통장정리 로직
        Debug.Log("ArrangementPassbook");
    }




}
