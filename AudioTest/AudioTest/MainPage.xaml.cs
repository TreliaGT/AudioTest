using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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

        public ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        public MainPage()
        {
            InitializeComponent();
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
            string url = "https://heritage-walks.screencraft.net.au/audio/default.mp3";
            WebClient wc = new WebClient();
            Stream fileStream = wc.OpenRead(url);
            player.Load(fileStream);
           
        }

        public void PlayClicked(object sender, EventArgs args)
        {       

            player.Play();
        }

        public void StopClicked(object sender, EventArgs args)
        {
          
            player.Stop();
        }

        public void PauseClicked(object sender, EventArgs args)
        {

            player.Pause();
            
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("AudioTest." + filename);
            return stream;
        }
    }
}
