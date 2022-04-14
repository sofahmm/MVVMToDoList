using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MVVMToDoList.Models;

namespace MVVMToDoList.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TasksListViewModel lvm;
        public Task Task { get; private set; }
        public TasksViewModel()
        {
            Task = new Task();
        }
        public TasksListViewModel TasksListViewModel
        {
            get { return lvm; }
            set
            {
                if(lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string NameTask
        {
            get { return Task.NameTask; }
            set
            {
                if(Task.NameTask != value)
                {
                    Task.NameTask = value;
                    OnPropertyChanged("NameTask");
                }
            }
        }
        public string DescriptionTask
        {
            get { return Task.DescriptionTask; }
            set
            {
                if(Task.DescriptionTask != value)
                {
                    Task.DescriptionTask = value;
                    OnPropertyChanged("DescriptionChanged");
                }
            }
        }
        public DateTime AddDateTask
        {
            get { return Task.AddDateTask; }
            set
            {
                if(Task.AddDateTask != value)
                {
                    Task.AddDateTask = value;
                    OnPropertyChanged("AddDateTask");
                }
            }
        }
        public DateTime EndDateTask
        {
            get { return Task.EndDateTask; }
            set
            {
                if(Task.EndDateTask != value)
                {
                    Task.EndDateTask = value;
                    OnPropertyChanged("EndDateTask");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public bool IsValid
        {
            
            get
            {
                return ((!string.IsNullOrEmpty(NameTask.Trim())) || (!string.IsNullOrEmpty(DescriptionTask.Trim())) ||
                    (!string.IsNullOrEmpty(AddDateTask.ToString().Trim())) || (!string.IsNullOrEmpty(EndDateTask.ToString().Trim())));
            }
        }
    }
}
