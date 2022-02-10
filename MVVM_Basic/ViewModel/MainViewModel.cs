using MVVM_Basic.Model;
using MVVM_Basic.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace MVVM_Basic.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public DateTime NowTime { get => GetValue<DateTime>(); set => SetValue(value); }
        public MainModel Model { get => GetValue<MainModel>(); set => SetValue(value); }
        public Brush Background { get => GetValue<Brush>(); set => SetValue(value); }
        public RelayCommand ChangeColorCommand { get; set; }

        // 생성자
        public MainViewModel()
        {
            // Background 초기값
            Background = new SolidColorBrush(Colors.White);
            // Model 생성
            Model = new MainModel() { @string = "MVVM 기본 패턴", @int = 100 };
            // 타이머 생성 및 시간 업데이트 함수
            Setting_Timer();
            // Background Color 변환 함수 등록
            ChangeColorCommand = new RelayCommand(ChangeColor);
        }

        // 타이머 생성 및 시간 업데이트 함수
        private void Setting_Timer()
        {
            var timer = new DispatcherTimer() { Interval = new TimeSpan(1000) };
            timer.Tick += (sender, e) => NowTime = DateTime.Now;
            timer.Start();
        }

        // 색깔 바꾸는 함수
        private void ChangeColor()
            => Background = new SolidColorBrush(RandomColor());

        // 색을 랜덤으로 바꿔주는 함수
        private Color RandomColor()
        {
            var colors = typeof(Colors).GetProperties();
            var random = new Random().Next(0, colors.Count()-1);

            return (Color)colors[random].GetValue(null);
        }
    }
}
