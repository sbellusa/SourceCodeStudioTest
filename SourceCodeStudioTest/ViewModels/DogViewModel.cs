using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SourceCodeStudioTest.Models;

namespace SourceCodeStudioTest.ViewModels
{
    public partial class DogViewModel : ObservableObject
    {
        public DogViewModel(DogResponse dog)
        {
            if (dog == null) throw new ArgumentNullException();

            if(!string.IsNullOrWhiteSpace(dog?.Url))
            {
                DogUrl = new Uri(dog.Url);
                DogBreed = ParseDogBreed(DogUrl);
            }
        }

        [ObservableProperty]
        Uri dogUrl;

        [ObservableProperty]
        string dogBreed;

        private string ParseDogBreed(Uri url)
        {
            string breed = string.Empty;

            string path = url.AbsolutePath;
            string[] splitted = path.Split('/');

            if (splitted.Length > 2)
            {
                string value = splitted[2].Replace('-', ' ');
                breed = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            }

            return breed;
        }
    }
}
