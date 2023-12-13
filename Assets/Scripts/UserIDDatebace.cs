using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIDDatebace : MonoBehaviour
{    
    public int userlistCount;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("userlistCount"))
        {
            PlayerPrefs.SetInt("userlistCount", 0);
        }       
        userlistCount = PlayerPrefs.GetInt("userlistCount");

    }
    public void UpdateUserIDDatebace(string _userName)
    {
        userlistCount++;
        PlayerPrefs.SetInt("userlistCount", userlistCount);
        PlayerPrefs.SetString(_userName, _userName+userlistCount);
    }
}
