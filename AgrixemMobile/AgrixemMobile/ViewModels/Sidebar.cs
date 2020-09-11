using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgrixemMobile.ViewModels
{
    public class Sidebar : INotifyPropertyChanged
    {
        public Sidebar()
        {
            FarmAsync();
            FarmImagesAsyc();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        public string Name => Settings.Name + " " + Settings.Surname;

        public string FarmName { get; private set; }
        public string FarmImage { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void FarmAsync()
        {
            var g = await App.AgrixemManager.GetFarmAsync();
            FarmName = g.Name;
            OnPropertyChanged("FarmName");
        }

        private async void FarmImagesAsyc()
        {
            var images = await App.AgrixemManager.FarmImages();


            string ImageName = null;

            System.Diagnostics.Debug.WriteLine($"\n\n\n\\n Images: {images.Count}");

            if (images.Count == 1)
            {
                //get first element if only one image is available
                ImageName = images[0];

            }
            else if (images.Count > 1)
            {
                //get random farm image if multiple images are available
                Random random = new Random();
                var myrand = random.Next(0, images.Count);
                ImageName = images[myrand];
            }

            //use image name to call actual image

            if (ImageName != null)
            {
                FarmImage = Constants.MediaCaller + $"{Settings.FarmId}/farm/{ImageName}";
                OnPropertyChanged("FarmImage");
            }
            else
            {
                FarmImage = null;
                OnPropertyChanged("FarmImage");
            }


        }
    }
}
