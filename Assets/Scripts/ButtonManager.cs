using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    public event Action DepositButton; //입금
    public event Action WithdrawalButton; //출금
    public event Action RemittanceButton; //송금
    public event Action ArrangementPassbookButton; //통장정리

    private void Awake()
    {
        instance = this; 
    }

    public void CallDepositButton()
    {
        DepositButton?.Invoke();
    }
    public void CallWithdrawalButton()
    {
        WithdrawalButton?.Invoke();
    }
    public void CallRemittanceButton()
    {
        RemittanceButton?.Invoke();
    }
    public void CallArrangementPassbookButton()
    {
        ArrangementPassbookButton?.Invoke();
    }
}
