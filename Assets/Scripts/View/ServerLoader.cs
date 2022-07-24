using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ServerLoader : MonoBehaviour
{
    public void Upload(string pathToFile)
    {
        StartCoroutine(UploadFileData(pathToFile));
    }

    private IEnumerator UploadFileData(string path)
    {
        using (var www = new UnityWebRequest("http://h100516.hostru07.fornex.host/diplomkonstructor3d.com/upload", UnityWebRequest.kHttpVerbPOST))
        {
            www.certificateHandler = new CertificateWhore();
            www.uploadHandler = new UploadHandlerFile(path);
            www.SetRequestHeader("Content-Type", "text/plane");
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                MessageBox.Instance.ShowMessage("The model has not been uploaded to the server");
            }
            else
            {
                MessageBox.Instance.ShowMessage("The model was successfully uploaded to the server");
            }
        }
    }

}
