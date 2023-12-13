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
                break; //���⼭ chackbutton�̺�Ʈ�� �ɵ������� ����,��������
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

    public void CallChackButton() //��ư�� ������
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
        PassbookTxt.text = $"�ܾ� : {passBookCash.ToString("N0")} ��";
        WalletTxt.text = $"�ܾ� : {walletCash.ToString("N0")} ��";
    }

    private void Deposit()
    {
        // �Աݷ���
        if(inputFieldCash > walletCash)
        {
            logText.text += $"�ܾ��� �����մϴ�.\n";
            Scrollbar.value = 0.0f;
            return; // �α��ǿ� ����
        }
        walletCash -= inputFieldCash;
        passBookCash += inputFieldCash;
        UpdateCashText();
        logText.text += $"{inputFieldCash}�� �Ա�\n";
        Scrollbar.value = 0.0f;
    }

    private void Withdrawal()
    {
        if (inputFieldCash > passBookCash)
        {
            logText.text += $"�ܾ��� �����մϴ�.\n";
            Scrollbar.value = 0.0f;
            return; // �α��ǿ� ����
        }
        passBookCash -= inputFieldCash;
        walletCash += inputFieldCash;
        UpdateCashText();
        logText.text += $"{inputFieldCash}�� ���\n";
        Scrollbar.value = 0.0f;
    }

    private void Remittance()
    {
        //�۱ݷ���
        Debug.Log("Remittance");
    }

    private void ArrangementPassbook()
    {
        //�������� ����
        Debug.Log("ArrangementPassbook");
    }




}
