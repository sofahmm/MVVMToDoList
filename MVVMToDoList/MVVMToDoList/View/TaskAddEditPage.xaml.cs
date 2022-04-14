using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMToDoList.ViewModels;

namespace MVVMToDoList.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskAddEditPage : ContentPage
    {
        public TasksViewModel ViewModel { get; private set; }
        public TaskAddEditPage(TasksViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}