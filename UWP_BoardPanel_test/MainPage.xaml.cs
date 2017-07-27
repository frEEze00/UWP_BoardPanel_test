﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWP_BoardPanel_test {
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();

            board.Rows = 20;
            board.Columns = 20;
            for (int i = 0; i < 400; i++) {
                //board.Children.Add(new Button() {
                //    Content = "sda",
                //    Background = new SolidColorBrush(Colors.Red),
                //    HorizontalAlignment = HorizontalAlignment.Left,
                //    VerticalAlignment = VerticalAlignment.Top
                //});
                board.Children.Add(new CellControl());
            }

        }
    }
}
