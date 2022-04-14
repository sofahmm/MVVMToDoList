using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MVVMToDoList.View;
using MVVMToDoList.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMToDoList.ViewModels
{
    public class TasksListViewModel
    {
        public ObservableCollection<TasksViewModel> Tasks { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateTaskCommand { protected set; get;}
        public ICommand DeleteTaskCommand { protected set; get; }
        public ICommand SaveTaskCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        TasksViewModel selectedTask;
        public INavigation Navigation { get; set; }
        public TasksListViewModel()
        {
            Tasks = new ObservableCollection<TasksViewModel>();
            CreateTaskCommand = new Command(CreateTask);
            DeleteTaskCommand = new Command(DeleteTask);
            SaveTaskCommand = new Command(SaveTask);
            BackCommand = new Command(Back);

        }
        public TasksViewModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    TasksViewModel tempTask = value;
                    selectedTask = null;
                    OnPropertyChanged("SelectedTask");
                    Navigation.PushAsync(new TaskAddEditPage(tempTask));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateTask()
        {
            Navigation.PushAsync(new TaskAddEditPage(new TasksViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveTask(object taskObject)
        {
            TasksViewModel task = taskObject as TasksViewModel;
            if (task != null && task.IsValid && !Tasks.Contains(task))
            {
                Tasks.Add(task);
            }
            Back();
        }
        private void DeleteTask(object taskObject)
        {
            TasksViewModel task = taskObject as TasksViewModel;
            if(task != null)
            {
                Tasks.Remove(task);
            }
            Back();
        }
    }
}
