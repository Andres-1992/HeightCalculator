using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public MainPageViewModel()
        {
            StartWatch = new Command(OnStart);
            PauseWatch = new Command(OnStop);
            ResetWatch = new Command(OnReset);
            timer = new Stopwatch();
        }
        Stopwatch timer;

        string stopwatch = "Start!";
        public string Stopwatch
        {
            get => stopwatch;
            set
            {
                stopwatch = value;
                OnPropertyChanged();
            }
        }

        string ftHeight = "feet";
        public string FtHeight
        {
            get => ftHeight;
            set
            {
                ftHeight = value;
                OnPropertyChanged();
            }
        }

        string meterHeight = "meter";
        public string MeterHeight
        {
            get => meterHeight;
            set
            {
                meterHeight = value;
                OnPropertyChanged();
            }
        }

        void OnStart()
        {
            timer.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Stopwatch = $" {Math.Round( timer.Elapsed.TotalSeconds,2)} s";
                FtHeight = $"{ Math.Round(CalculateHeight(timer.Elapsed.TotalSeconds), 2)} feet";
                MeterHeight = $"{ Math.Round(CalculateHeight(timer.Elapsed.TotalSeconds) * 0.3048, 2)} meter";
                return true;
            });
        }
        void OnStop()
        {
            timer.Stop();
        }
        void OnReset()
        {
            timer.Reset();
        }
        public ICommand StartWatch { get; }
        public ICommand PauseWatch { get; }
        public ICommand ResetWatch { get; }
        private double CalculateHeight(double time)
        {
            return Math.Pow(time, 2) * 16; ;
        }



    }
}

