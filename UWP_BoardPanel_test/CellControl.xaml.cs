using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_BoardPanel_test {
    public enum Img {
        Q = -3, Flag, Bomb, Empty, One, Two, Three, Four, Five, Six, Seven, Eight, Nine
    }
    public sealed partial class CellControl : UserControl, INotifyPropertyChanged {
        public CellControl() {
            this.InitializeComponent();
            ImgSource = "Images\\Bomb.png";
            DataContext = this;
            
        }

        public event EventHandler ButtonClick;

        protected void Button1_Click(object sender, EventArgs e) {
            //bubble the event up to the parent
            if (this.ButtonClick != null)
                ButtonClick(this, e);       
        }


        #region Set Image
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void SetValue(Img value) {
            switch (value) {
                case Img.Q:
                ImgSource = "Images\\Q.png";
                break;
                case Img.Flag:
                ImgSource = "Images\\Flag.png";
                break;
                case Img.Bomb:
                ImgSource = "Images\\Bomb.png";
                break;
                case Img.Empty:
                ImgSource = "Images\\Empty.png";
                break;
                case Img.One:
                ImgSource = "Images\\1.png";
                break;
                case Img.Two:
                ImgSource = "Images\\2.png";
                break;
                case Img.Three:
                ImgSource = "Images\\3.png";
                break;
                case Img.Four:
                ImgSource = "Images\\4.png";
                break;
                case Img.Five:
                ImgSource = "Images\\5.png";
                break;
                case Img.Six:
                ImgSource = "Images\\6.png";
                break;
                case Img.Seven:
                ImgSource = "Images\\7.png";
                break;
                case Img.Eight:
                ImgSource = "Images\\8.png";
                break;
                case Img.Nine:
                ImgSource = "Images\\9.png";
                break;
                default:
                break;
            }
        }
        private string imgSource;
        public string ImgSource {
            get { return imgSource; }
            set {
                imgSource = value;
                OnPropertyChanged("ImgSource");
            }
        }

        #endregion


        private void UserControl_PointerPressed(object sender, PointerRoutedEventArgs e) {
            
            var a = e;
            var b = e.Pointer;
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsLeftButtonPressed) {
                    SetValue(Img.Bomb);
                } else if (properties.IsRightButtonPressed) {
                    SetValue(Img.Flag);
                }
            }
        }

        private void UserControl_PointerMoved_1(object sender, PointerRoutedEventArgs e) {
            SetValue(Img.Q);       
        }
    }
}
