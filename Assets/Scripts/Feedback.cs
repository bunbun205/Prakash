using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class Feedback : MonoBehaviour
{
    private string formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScLlfEcrP-8UQnb094OhnABrsGmn1b4atdvH6fmcHZ-RSxfvA/formResponse";
    public void SubmitFeedback(string sceneName, string distance, string firstHit)
    {
        StartCoroutine(Post(sceneName, distance, firstHit));
    }

    private IEnumerator Post(string sceneName, string distance, string firstHit) {
        WWWForm form = new WWWForm();
        form.AddField("entry.1758088246", sceneName);
        form.AddField("entry.628239878", distance);
        form.AddField("entry.986201344", firstHit);

        using(UnityWebRequest www = UnityWebRequest.Post(formURL, form))
        {

            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Feedback Submitted Successfully");
            } else
            {
                Debug.LogError("Error in feedback submission: " + www.error);
            }
        }
    }
}