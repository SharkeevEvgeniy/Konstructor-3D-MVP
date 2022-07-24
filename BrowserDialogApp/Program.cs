using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Windows.Forms;

namespace BrowserDialogApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static StreamWriter writerMemory;
        static MemoryMappedFile Memory;
        static StreamReader readerMemory;

        [STAThread]
        static void Main()
        {
            Memory = MemoryMappedFile.CreateOrOpen("Result", 256, MemoryMappedFileAccess.ReadWrite);

            readerMemory = new StreamReader(Memory.CreateViewStream(), System.Text.Encoding.Default);
            readerMemory.BaseStream.Seek(0, SeekOrigin.Begin);
            string type = readerMemory.ReadLine().Trim('\0', '\r', '\n');
            readerMemory.Close();

            if (type != null)
            {
                writerMemory = new StreamWriter(Memory.CreateViewStream(), System.Text.Encoding.Default);
                writerMemory.BaseStream.Seek(0, SeekOrigin.Begin);

                if (type == "Save")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PNG|*.png";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        writerMemory.Write(saveFileDialog.FileName);
                    }
                    else
                    {
                        writerMemory.Write("Abort");
                    }
                    saveFileDialog.Dispose();
                }
                else if (type == "Open")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Format Files|*.obj;*.fbx;*.stl";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        writerMemory.Write(openFileDialog.FileName);
                    }
                    else
                    {
                        writerMemory.Write("Abort");
                    }
                    openFileDialog.Dispose();
                }
                else
                {
                    writerMemory.Write("Incorrect type");
                }
            }
            else
            {
                writerMemory.Write("NULL type");
            }
            writerMemory.Close();
            Memory.Dispose();
        }
    }
}
