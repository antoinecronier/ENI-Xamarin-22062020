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
using ENI_Xamarin_30032020.Droid.Services;
using ENI_Xamarin_30032020.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperImpl))]
namespace ENI_Xamarin_30032020.Droid.Services
{
        public class FileHelperImpl : IFileHelper
        {
            public FileHelperImpl()
            { }

            public string GetLocalFilePath(string filePath)
            {
                return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filePath);
            }
        }
}