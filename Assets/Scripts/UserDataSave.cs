using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataSave : MonoBehaviour
{
    public string userName;
    public string userID;
    public string password;
    public int bankBalance = 0;
    
    public UserDataSave(string _userName, string _userID,string _password)
    { 
        userName = _userName;
        userID = _userID;
        password = _password;
        SetUserDate();
    }

    public void SetUserDate()
    {
        PlayerPrefs.SetString($"{userID}Name", userName);
        PlayerPrefs.SetString($"{userID}Password", password);
        PlayerPrefs.SetInt($"{userID}BankBalance", bankBalance);
    }
}
