using UnityEngine;
using System;
using Firebase.Database;

[Serializable]
public class Parameters
{
    public float distanceToTarget;
    public float score;
    public string hit;
}
public class DataManagement : MonoBehaviour
{
    public DataManagement dbmgr;
    public Parameters param;
    public string userID;
    public string mode;
    public int numTarget;
    DatabaseReference dbRef;

    public void Awake()
    {
        dbmgr = this;
        DontDestroyOnLoad(gameObject);
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SendData()
    {
        string json = JsonUtility.ToJson(param);
        DatabaseReference newEntryRef = dbRef
        .Child("users")
        .Child(userID)
        .Child(mode)  // New mode row if it doesn't exist
        .Child("Target " + numTarget.ToString()); // New target under mode

        newEntryRef.SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsFaulted)
            { 
                Debug.LogError("Failed to send data: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Data sent successfully!");
            }
        });
    }

    public void RecieveData() { }
}
