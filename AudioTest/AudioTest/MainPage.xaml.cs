using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AudioTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        
        public MainPage()
        {
            InitializeComponent();
        }

        public void PlayClicked(object sender, EventArgs args)
        {
          
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

      
            player.Load(GetStreamFromFile("Sleep.mp3"));

            player.Play();
        }

        public void StopClicked(object sender, EventArgs args)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Stop();
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Music." + filename);
            return stream;
        }
    }
}
