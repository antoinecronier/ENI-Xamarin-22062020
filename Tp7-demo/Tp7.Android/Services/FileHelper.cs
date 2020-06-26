using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tp7.Droid.Services;
using Tp7.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Tp7.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public FileHelper()
        { }

        public string GetLocalFilePath(string filePath)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filePath);
        }
    }
}