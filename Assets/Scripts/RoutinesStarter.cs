using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RoutinesStarter : MonoBehaviour
{
    public static RoutinesStarter Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void TryToLogin(AuthorizationModel model, AuthorizationView view, Action<string> onSuccessEvent)
    {
        StartCoroutine(TryToLoginRoutine(model, view, onSuccessEvent));
    }

    private IEnumerator TryToLoginRoutine(AuthorizationModel model, AuthorizationView view, Action<string> onSuccessEvent)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", model.Login);
        form.AddField("password", model.Password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://h100516.hostru07.fornex.host/diplomkonstructor3d.com/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                MessageBox.Instance.ShowMessage("Invalid login or password. Please try again");
            }
            else
            {
                view.DisablePanel();
                onSuccessEvent.Invoke(www.downloadHandler.text);
            }
        }
    }
}
