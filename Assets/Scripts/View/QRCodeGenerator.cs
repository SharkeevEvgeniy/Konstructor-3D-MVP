using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;

public class QRCodeGenerator : MonoBehaviour, IExitDialogWindowHandler
{
    [SerializeField] private ProjectView _projectView;

    [SerializeField] private SessionStartup _sessionStartup;

    private string _textToEncode;

    [SerializeField] int _textureSize = 256;
    private Texture2D _texture;
    [SerializeField] RawImage _rawImageQR;

    private IFileSaveable _fileSaveable;

    public void EncodeOnClick()
    {
        string companyName = _sessionStartup.SessionInfo.CompanyName;
        string projectID = _projectView.GetProjectID();
        _textToEncode = $"konstructor/{companyName}/{projectID}";

        _texture = new Texture2D(_textureSize, _textureSize);
        Color32[] _convertPixelToTexture = Encode(_textToEncode, _texture.width, _texture.height);
        _texture.SetPixels32(_convertPixelToTexture);
        _texture.Apply();

        _rawImageQR.texture = _texture;
    }

    private Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writter.Write(textForEncoding);
    }

    public void SaveToPNGOnClick()
    {
        DialogWindow dialogWindow = new DialogWindow(this, "BrowserDialogApp\\bin\\Debug\\BrowserDialogApp.exe", DialogWindowType.Save);
        _fileSaveable = new SavePNGStrategy();
    }

    public void SetPathData(string path)
    {
        Save(_fileSaveable, path);
    }

    private void Save(IFileSaveable format, string path)
    {
        format.Save(_texture, path);
    }
}
