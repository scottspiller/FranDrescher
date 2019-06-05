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
        }
        async void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                await PlayClip();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task PlayClip()
        {
            var stream = GetStreamFromFile("Audio.HeyStuddly.mp3");
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