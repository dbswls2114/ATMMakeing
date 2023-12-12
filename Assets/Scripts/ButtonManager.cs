using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    public event Action DepositButton; //�Ա�
    public event Action WithdrawalButton; //���
    public event Action RemittanceButton; //�۱�
    public event Action ArrangementPassbookButton; //��������

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
