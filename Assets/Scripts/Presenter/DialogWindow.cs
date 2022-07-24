using System;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;

public class DialogWindow
{
    private MemoryMappedFile _memoryMappedFile;

    private IExitDialogWindowHandler _handler;

    public DialogWindow(IExitDialogWindowHandler handler, string dialogWindowPath, DialogWindowType type)
    {
        _handler = handler;

        _memoryMappedFile = MemoryMappedFile.CreateOrOpen("Result", 256, MemoryMappedFileAccess.ReadWrite);
        using (StreamWriter streamWritter = new StreamWriter(_memoryMappedFile.CreateViewStream(), System.Text.Encoding.Default))
        {
            streamWritter.BaseStream.Seek(0, SeekOrigin.Begin);
            streamWritter.Write(type);
            streamWritter.Close();
        }

        try
        {
            var dialogWindowApp = Process.Start(dialogWindowPath);
            dialogWindowApp.EnableRaisingEvents = true;
            dialogWindowApp.Exited += new EventHandler(Exit);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }
    }

    private void Exit(object sender, EventArgs e)
    {
        using (StreamReader streamReader = new StreamReader(_memoryMappedFile.CreateViewStream(), System.Text.Encoding.Default))
        {
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            var filePath = streamReader.ReadLine().Trim('\0', '\r', '\n');
            _handler.SetPathData(filePath);
            streamReader.Close();
        }
        _memoryMappedFile.Dispose();
    }
}
