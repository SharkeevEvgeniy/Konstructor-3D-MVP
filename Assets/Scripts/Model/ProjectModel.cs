public class ProjectModel
{
    private FileFormat _fileFormat;
    private string _projectID;
    private string _filePath;

    public FileFormat FileFormat
    {
        get
        {
            return _fileFormat;
        }
        set
        {
            _fileFormat = value;
        }
    }

    public string ProjectID
    {
        get
        {
            return _projectID;
        }
        set
        {
            _projectID = value;
        }
    }

    public string FilePath
    {
        get
        {
            return _filePath;
        }
        set
        {
            _filePath = value;
        }
    }
} 
