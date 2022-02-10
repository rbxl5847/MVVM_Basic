using MVVM_Basic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Basic.Model
{
    class MainModel : ViewModelBase
    {
        public string @string { get => GetValue<string>(); set => SetValue(value); }
        public int @int { get => GetValue<int>(); set => SetValue(value); }
    }
}
