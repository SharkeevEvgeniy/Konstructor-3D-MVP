using System;
using System.IO;
using UnityEngine;

public class SavePNGStrategy : IFileSaveable
{
    public void Save(Texture2D texture, string path)
    {
        var bytes = texture.EncodeToPNG();
        try
        {
            File.WriteAllBytes(path, bytes);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
