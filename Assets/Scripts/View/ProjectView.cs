using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectView : MonoBehaviour, IExitDialogWindowHandler
{
    [SerializeField] private TMP_InputField _projectNameInputField;
    [SerializeField] private Image[] _formatButtons;

    [SerializeField] ColorsHolder _colorsHolder;

    [SerializeField] private GameObject _projectPanel;

    [SerializeField] private ModelInit _modelInit;

    private ProjectPresenter _projectPresenter;

    public void InitModel(GameObject model)
    {
        _modelInit.SetModel(model);
        _modelInit.Initialize();
    }

    public void SetPresenter(ProjectPresenter presenter) => _projectPresenter = presenter;

    public string GetProjectID() => _projectPresenter.GetProjectID();

    public void SetFileFormatOnClick(int index)
    {
        _projectPresenter.SetFileFormat((FileFormat)index);
    }

    public void ResetAllButtons()
    {
        foreach (var image in _formatButtons)
        {
            image.color = _colorsHolder.StayButtonFormat;
        }
    }

    public void SetButtonColor(int index)
    {
        ResetAllButtons();
        _formatButtons[index].color = _colorsHolder.PressedButtonFormat;
        _projectPresenter.SetFileFormat((FileFormat)index);
    }

    private void SetProjectID()
    {
        _projectPresenter.SetProjectID(_projectNameInputField.text);
    }

    public void SetFilePathOnClick()
    {
        DialogWindow dialogWindow = new DialogWindow(this, "BrowserDialogApp\\bin\\Debug\\BrowserDialogApp.exe", DialogWindowType.Open);
    }

    public void CreateProjectOnClick()
    {
        if (string.IsNullOrEmpty(_projectNameInputField.text) == true)
        {
            MessageBox.Instance.ShowMessage("The field 'Project name' is empty");
            return;
        }
        SetProjectID();
        _projectPresenter.CreateProject();
        _projectPanel.SetActive(false);
    }

    public void SetPathData(string path)
    {
        _projectPresenter.SetFilePath(path);
    }
}
