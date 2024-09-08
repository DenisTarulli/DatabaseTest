using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private string databaseURL = "";
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField nameToRead;
    private User user = new();

    public void SaveData()
    {
        user.UserName = username.text;
        user.Email = email.text;
        user.Password = password.text;
        RestClient.Put(databaseURL + "/" + username.text + ".json", user);
    }

    public void ReadData()
    {
        RestClient.Get<User>(databaseURL + "/" + nameToRead.text + ".json").Then(response =>
        {
            user = response;
            Debug.Log("Username: " + user.UserName);
            Debug.Log("Email: " + user.Email);
            Debug.Log("Password: " + user.Password);
        });
    }

    public void DeleteData()
    {
        RestClient.Delete(databaseURL + ".json");
    }
}
