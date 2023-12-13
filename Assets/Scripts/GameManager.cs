using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    public event Action ChackButton;

    private static long passBookCash = 0;
    private static long walletCash = 150000;
    public long inputFieldCash = 0;

    public TMP_Text PassbookTxt;
    public TMP_Text WalletTxt;

    public TMP_Text logText;
    public Scrollbar Scrollbar;

    private void Start()
    {
        buttonManager = ButtonManager.instance;
        UpdateCashText();

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

    public void InputFieldStringtoLong(string _input)
    {
        bool inputtolong = long.TryParse(_input,out long inputlong);
        if(inputtolong)
        {
            inputFieldCash = inputlong;
        }     
    }

    public void UpdateCashText()
    {
        PassbookTxt.text = $"잔액 : {passBookCash.ToString("N0")} 원";
        WalletTxt.text = $"잔액 : {walletCash.ToString("N0")} 원";
    }

    private void Deposit()
    {
        // 입금로직
        if(inputFieldCash > walletCash)
        {
            logText.text += $"잔액이 부족합니다.\n";
            Scrollbar.value = 0.0f;
            return; // 로그판에 띄우기
        }
        walletCash -= inputFieldCash;
        passBookCash += inputFieldCash;
        UpdateCashText();
        logText.text += $"{inputFieldCash}원 입금\n";
        Scrollbar.value = 0.0f;
    }

    private void Withdrawal()
    {
        if (inputFieldCash > passBookCash)
        {
            logText.text += $"잔액이 부족합니다.\n";
            Scrollbar.value = 0.0f;
            return; // 로그판에 띄우기
        }
        passBookCash -= inputFieldCash;
        walletCash += inputFieldCash;
        UpdateCashText();
        logText.text += $"{inputFieldCash}원 출금\n";
        Scrollbar.value = 0.0f;
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
