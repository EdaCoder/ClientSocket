using ClientSocket.DTO;
using ClientSocket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using XExten.Advance.IocFramework;

namespace ClientSocket.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CNController : ControllerBase
    {
        private MainViewModel VM => IocDependency.Resolve<MainViewModel>();

        [HttpGet]
        public MessageModel<bool> GetStatus(string Ip)
        {
            var model = VM.Device.FirstOrDefault(t => t.Ip == Ip);
            var res = model != null && model.IsBegin;
            return MessageModel<bool>.Success(res);
        }

        [HttpGet]
        public MessageModel<BasicInfoModel> GetBasicData(string Ip)
        {
            var model = VM.Device.FirstOrDefault(t => t.Ip == Ip);
            Random ran = new Random();
            var data = new BasicInfoModel();
            data.CutTotalTime = ran.Next(100, 1000);
            data.CurHours = ran.Next(100, 1000);
            data.Version = "v1.1.1";
            data.Program = $"{Ip}Program";
            data.CycleTime= model==null? 0 : model.CycleTime;
            data.CutTotalTime = model == null ? 0 : model.TotalTime;
            data.PartCount = model==null?0:model.Count;
            data.TotalCount = model == null ? 0 : model.Count;
            data.CNCType = model==null?"随机":model.Name;
            data.PowerON = ran.NextDouble();
            return MessageModel<BasicInfoModel>.Success(data);
        }

        [HttpGet]
        public MessageModel<RunInfoModel>GetRunData(string Ip)
        {
            var model = VM.Device.FirstOrDefault(t => t.Ip == Ip);
            var data = new RunInfoModel();
            if (model != null)
            {
                Random ran = new Random();
                data.FeedRate = ran.Next(100, 1000);
                data.MainAxesRate = ran.Next(100, 1000);
                data.MainAxesSpeed = ran.Next(100, 1000);
                data.FeedSpeed = ran.Next(100, 1000);
                data.X = ran.Next(100, 1000);
                data.Z = ran.Next(100, 1000);
                data.Y = ran.Next(100, 1000);
                data.KeyTime = ran.Next(100, 1000);
                return MessageModel<RunInfoModel>.Success(data);
            }
            return MessageModel<RunInfoModel>.Error(data);
        }

        [HttpGet]
        public MessageModel<AlarmInfoModel> GetAlarmData(string Ip)
        {
            var model = VM.Device.FirstOrDefault(t => t.Ip == Ip);
            var data = new AlarmInfoModel();
            if (model != null)
            {
                data.AlarmContent = $"{Ip}位置错误";
                data.HappenTime = DateTime.Now;
                return MessageModel<AlarmInfoModel>.Success(data);
            }
            return MessageModel<RunInfoModel>.Error(data);
        }
    }
}
