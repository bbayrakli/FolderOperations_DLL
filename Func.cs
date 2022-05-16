using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace FileOrganizer_DLL
{
    public class Func
    {
        string sourceFile;

        public void DragOver(object sender, DragEventArgs e)
        {
            e.Effect = !e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.None : DragDropEffects.Link;
        }
        public string DragFile(object sender, DragEventArgs e, TextBox t, PictureBox p)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())

                sourceFile = files.First();
            //t.Text = Path.GetFileName(sourceFile);
            t.Text = sourceFile;
            p.Image = System.Drawing.Icon.ExtractAssociatedIcon(sourceFile).ToBitmap();

            return sourceFile;
        }
        public void CopyFile(string sourceFile, string destinationFolder, string FileSpecificString) // sourceFile is created in DragDrop Event
        {
            FileSpecificString = DateTime.Now.ToString("yyMMdd-HHmmss");
            string Extension = Path.GetExtension(sourceFile);
            string destinationFile = destinationFolder + FileSpecificString + Extension;

            if (File.Exists(destinationFile))
            {
                MessageBox.Show("File Already Exists.");
            }
            File.Copy(sourceFile, destinationFile, true);
        }

        public void OpenFile(string sourceFileName)
        {
            Process.Start(sourceFileName);
        }

    }
}
