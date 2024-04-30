using ClientSocket.DTO;
using ClientSocket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using XExten.Advance.IocFramework;

namespace ClientSocket.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CKController: ControllerBase
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
        public MessageModel<CheckInfoModel> GetBasicData(string Ip)
        {
            int[] salt = {1,2,3,4,5,6,7,8,9,10 };
            var model = VM.Device.FirstOrDefault(t => t.Ip == Ip);
            Random ran = new Random();
            var data = new CheckInfoModel();
            data.HeightStandard = ran.Next(1, 10);
            data.RealityHeight = ran.Next(1, 10);
            data.ApertureStandard = ran.Next(1, 10);
            data.RealityAperture = ran.Next(1, 10);
            data.CheckRes = salt[ran.Next(0, salt.Length)] >= 7 ? 2 : 1;
            data.Count = model.Count;
            return MessageModel<CheckInfoModel>.Success(data);
        }
    }
}
