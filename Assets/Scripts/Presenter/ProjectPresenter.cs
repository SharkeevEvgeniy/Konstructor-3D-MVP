using Dummiesman;

public class ProjectPresenter
{
    private ProjectModel _projectModel;
    private ProjectView _projectView;

    public ProjectPresenter(ProjectModel projectModel, ProjectView projectView)
    {
        _projectModel = projectModel;
        _projectView = projectView;
    }

    public void SetFileFormat(FileFormat format)
    {
        _projectModel.FileFormat = format;
    }

    public void SetProjectID(string id)
    {
        _projectModel.ProjectID = id;
    }

    public void SetFilePath(string path)
    {
        _projectModel.FilePath = path;
    }
    
    public string GetProjectID()
    {
        return _projectModel.ProjectID;
    }

    public void CreateProject()
    {
        IFileImporter fileImporter;
        switch(_projectModel.FileFormat)
        {
            case FileFormat.OBJ:
                fileImporter = new OBJLoader();
                break;
            case FileFormat.FBX:
                throw new System.NotImplementedException();
                break;
            default:
                fileImporter = new OBJLoader();
                break;
        }
        _projectView.InitModel(fileImporter.Load(_projectModel.FilePath));
    }
}
