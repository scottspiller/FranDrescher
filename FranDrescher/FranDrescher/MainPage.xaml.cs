﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace FranDrescher
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer player;
        public MainPage()
        {
            InitializeComponent();
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            //BackgroundImageSource = ImageSource.FromFile("FranBackground.png");
        }
        async void OnFrameTapped(object sender, EventArgs args)
        {
            try
            {
                Frame frame = (Frame)sender;


                var fileName = frame.ClassId;             
                PlayClip(fileName);
                //await frame.RotateTo(360, 2000);
                await Task.WhenAny<bool>
                (
                  frame.ScaleTo(2, 300)
                );
                await frame.ScaleTo(1, 300);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PlayClip(string fileName)
        {
            if (player.IsPlaying)
            {
                player.Stop();
            }
            
            var stream = GetStreamFromFile($"Audio.{fileName}.mp3");
            player.Load(stream);
            player.Play();     
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("FranDrescher." + filename);
            return stream;
        }
    }
}
