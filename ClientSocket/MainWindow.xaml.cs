using ClientSocket.Models;
using ClientSocket.ViewModels;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XExten.Advance.IocFramework;
using XExten.Advance.JsonDbFramework;
using XExten.Advance.LinqFramework;

namespace ClientSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel VM;
        private JsonDbHandle<DeviceModelDTO> JsonDbHandle;
        public MainWindow()
        {
            VM = IocDependency.Resolve<MainViewModel>();
            JsonDbHandle = new JsonDbContext(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Device.json")).LoadInMemory<DeviceModelDTO>();
            VM.Device = new(JsonDbHandle.GetAll().ToMapest<List<DeviceModel>>());
            VM.Fix= ConfigurationManager.AppSettings["Num"];
            InitializeComponent();
            this.DataContext = VM;
        }

        private void Handle(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DownEvent(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HandleEvent(object sender, RoutedEventArgs e)
        {
            var target = int.Parse((sender as Button).CommandParameter.ToString());
            if (target != 3)
            {
                var Title = target == 1 ? "添加机床" : "添加检具";
                var win = new Add() { Title = Title };
                if (win.ShowDialog().Value)
                    VM.Device.Add(new DeviceModel
                    {
                        IsBegin = false,
                        Id = Guid.NewGuid(),
                        Ip = win.IP.Text,
                        Name = win.Device.Text,
                        Width = 0,
                        CycleTime = 0d,
                        TotalTime = 0d,
                        IsAuto = false
                    }) ;
            }
            if (target == 3)
            {
                JsonDbHandle.Delete(t => t.Id != Guid.Empty).ExcuteDelete().SaveChange();
                var param = VM.Device.ToList().ToMapest<List<DeviceModelDTO>>();
                JsonDbHandle.Insert(param).ExuteInsert().SaveChange();
            }
        }

        private async void InEvent(object sender, RoutedEventArgs e)
        {
            var btn = (sender as Button);
            var target = int.Parse(btn.Tag.ToString());
            var model = (DeviceModel)btn.CommandParameter;
            if (target == 4)
                model.IsAuto = true;
            if (target == 3)
                VM.Device.Remove(model);
            if (target == 2)
            {
                model.Width = 0;
                model.IsBegin = false;
                model.IsAuto = false;
            }
            if (target == 1)
            {
                if(!model.IsAuto)
                    model.CycleTime = 0;
                model.IsBegin = true;
                var len = Math.Ceiling(575d / (15 * VM.Fix.AsInt()));
                for (int i = 1; i <= len; i++)
                {
                    if (model.IsBegin)
                    {
                        await Task.Run(async () =>
                        {
                            model.CycleTime++;
                            model.TotalTime++;
                            model.Width = i * VM.Fix.AsInt() * 15;
                            await Task.Delay(1000);
                        });
                        if (i == len)
                        {
                            model.IsBegin = false;
                            model.Count++;
                            if (model.IsAuto)
                            {
                               await  Task.Run(async () =>
                                {
                                    await Task.Delay(5000);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        InEvent(sender, e);
                                    });
                                });
                              
                            }
                        }
                    }
                }
            }
        }
    }
}