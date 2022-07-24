using UnityEngine;
using TMPro;

public class MessageBox : MonoBehaviour
{
    public static MessageBox Instance { get; private set; }

    [SerializeField] private GameObject _messageBox;
    [SerializeField] TMP_Text _textMessage;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void ShowMessage(string text)
    {
        if (_messageBox.activeSelf == false)
            _messageBox.SetActive(true);
        _textMessage.text = text;
    }
}
