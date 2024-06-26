using ClientSocket.Models;
using ClientSocket.ViewModels;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using XExten.Advance.EventFramework;
using XExten.Advance.EventFramework.EventSources;
using XExten.Advance.EventFramework.PublishEvent;
using XExten.Advance.EventFramework.SubscriptEvent;
using XExten.Advance.IocFramework;
using XExten.Advance.JsonDbFramework;
using XExten.Advance.LinqFramework;
using XExten.Advance.ThreadFramework;

namespace ClientSocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEventSubscriber
    {
        private MainViewModel VM;
        private int Invet;
        private int Fix;
        private JsonDbHandle<DeviceModelDTO> JsonDbHandle;
        private bool IsStartAuto = false;
        public MainWindow()
        {
            VM = IocDependency.Resolve<MainViewModel>();
            VM.Device = new();
            JsonDbHandle = new JsonDbContext(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Device.json")).LoadInMemory<DeviceModelDTO>();
            JsonDbHandle.GetAll().ForEach(item =>
            {
                var Model = item.ToMapest<DeviceModel>();
                Model.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(item.Colors));
                VM.Device.Add(Model);
            });
            Fix = ConfigurationManager.AppSettings["Num"].AsInt();
            Invet = ConfigurationManager.AppSettings["Invet"].AsInt() * 1000;
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
            if (target == 1)
            {
                var win = new Add() { Title = "添加设备" };
                if (win.ShowDialog().Value)
                    if (target == 1)
                    {
                        var Ck = bool.Parse((win.AutoDevice.SelectedItem as ComboBoxItem).Content.ToString());
                        var No = VM.Device.Count == 0 ? 0 : (VM.Device.FirstOrDefault(t => t.No != -1)==null?0: VM.Device.Where(t => t.No != -1).Max(t => t.No));
                        var Model = new DeviceModel
                        {
                            IsBegin = false,
                            Id = Guid.NewGuid(),
                            Ip = win.IP.Text,
                            Name = win.Device.Text,
                            Width = 0,
                            CycleTime = 0d,
                            TotalTime = 0d,
                            IsAuto = false,
                            No = Ck ? No + 1 : -1,
                            IsSame = false,
                        };
                        Model.Color = Model.No <= 0 ? Brushes.White : (Model.No % 2 == 0 ? Brushes.LightBlue : Brushes.OrangeRed);
                        VM.Device.Add(Model);
                    }
            }
            else
            {
                JsonDbHandle.Delete(t => t.Id != Guid.Empty).ExcuteDelete().SaveChange();
                var param = VM.Device.ToList().ToMapest<List<DeviceModelDTO>>();
                param.ForEach(item =>
                {
                    item.Colors = VM.Device.First(t => t.Id == item.Id).Color.ToString();
                });
                JsonDbHandle.Insert(param).ExuteInsert().SaveChange();
            }
        }

        private async void InEvent(object sender, RoutedEventArgs e)
        {
            var btn = (sender as Button);
            var target = int.Parse(btn.Tag.ToString());
            var model = (DeviceModel)btn.CommandParameter;
            if (target == 4)
            {
                if (model.IsAuto == false)
                {
                    model.IsAuto = true;
                    btn.Content = "取消自动";
                }
                else
                {
                    model.IsAuto = false;
                    btn.Content = "自动";
                }
            }
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
                if (!model.IsAuto)
                    model.CycleTime = 0;
                model.IsBegin = true;
                var len = Math.Ceiling(575d / (15 * Fix));
                for (int i = 1; i <= len; i++)
                {
                    if (model.IsBegin)
                    {
                        await Task.Run(async () =>
                        {
                            model.CycleTime++;
                            model.TotalTime++;
                            model.Width = i * Fix * 15;
                            await Task.Delay(1000);
                        });
                        if (i == len)
                        {
                            model.IsBegin = false;
                            model.Count++;
                            model.TodayCountLimit++;
                            if (model.TodayCountLimit >= model.TodayCountLimit && model.TodayCountLimit > 0)
                                model.IsAuto = false;
                            if (model.IsAuto)
                            {
                                await Task.Run(async () =>
                                 {
                                     await Task.Delay(Invet);
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

        private void AutoEvent(object sender, RoutedEventArgs e)
        {
            if (!IsStartAuto)
            {
                var Len = Math.Ceiling(575d / (15 * Fix));
                List<DeviceModel> NoSameDevice = VM.Device.Where(t => t.No != -1).Where(t => t.IsSame == false).ToList();

                foreach (var device in NoSameDevice)
                {
                    ThreadFactory.Instance.StartWithRestart(() =>
                    {
                        device.IsBegin = true;
                        for (int no = 1; no <= Len; no++)
                        {
                            if (device.IsBegin)
                            {
                                device.CycleTime++;
                                device.TotalTime++;
                                device.Width = no * Fix * 15;
                                if(device.Invet<2)
                                  Thread.Sleep(device.No * 200);
                                else
                                    Thread.Sleep(device.Invet * 200);
                            }
                            if (no == Len)
                            {
                                device.IsBegin = false;
                                device.Count++;
                                device.TodayCount++;
                                if(device.TodayCount>= device.TodayCountLimit&& device.TodayCountLimit>0)
                                    ThreadFactory.Instance.StopTask(device.Id.ToString());
                                Thread.Sleep((device.Invet<3? Invet: device.Invet )* (device.No/10+device.No));
                            }
                        }
                    }, device.Id.ToString(),null,false);
                }

                //相同工序
                var SameDevice = VM.Device.Where(t => t.No != -1).Where(t => t.IsSame == true).ToList();
                int Seed = GetSeed(SameDevice.Count);
                ThreadFactory.Instance.StartWithRestart(() =>
                {
                    var device = SameDevice[Seed];
                    device.IsBegin = true;
                    for (int no = 1; no <= Len; no++)
                    {
                        if (device.IsBegin)
                        {
                            device.CycleTime++;
                            device.TotalTime++;
                            device.Width = no * Fix * 15;
                            if (device.Invet < 2)
                                Thread.Sleep(device.No * 200);
                            else
                                Thread.Sleep(device.Invet * 200);
                        }
                        if (no == Len)
                        {
                            device.IsBegin = false;
                            device.Count++;
                            device.TodayCount++;
                            Seed = GetSeed(SameDevice.Count);
                            if (SameDevice.Sum(t => t.TodayCount) >= device.TodayCountLimit && device.TodayCountLimit > 0) 
                                ThreadFactory.Instance.StopTask("Same");
                            Thread.Sleep((device.Invet < 3 ? Invet : device.Invet) * (device.No / 10 + device.No));
                        }
                    }
                }, "Same", null, false);

                AutoBtn.Content = "自动化停止";
                IsStartAuto = true;
            }
            else
            {
                IsStartAuto = false;
                AutoBtn.Content = "自动化启动";
                ThreadFactory.Instance.Dispose();
            }
        }

        private int GetSeed(int len) =>  new Random(Guid.NewGuid().GetHashCode()).Next(0, len);

        private void ClearEvent(object sender, RoutedEventArgs e)
        {
            ((sender as Button).CommandParameter as DeviceModel).TodayCount = 0;
        }
    }
}