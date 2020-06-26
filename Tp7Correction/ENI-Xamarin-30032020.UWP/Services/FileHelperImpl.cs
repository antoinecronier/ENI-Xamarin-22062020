using ENI_Xamarin_30032020.Services;
using ENI_Xamarin_30032020.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperImpl))]
namespace ENI_Xamarin_30032020.UWP.Services
{
    public class FileHelperImpl : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
