using DataOffsets.Dto;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DataOffsets
{
    public class Request
    {
        private static string Token = "";
        private static string UId = "";
        private static async Task<string> Post(string url, object data, bool IsLogin = false)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://47.109.145.77:5002")
            };
            if (!IsLogin)
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

            HttpContent content = new StringContent(JsonSerializer.Serialize(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync($"/api/{url}", content);

            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> Get(string url)
        {
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://47.109.145.77:5002")
                };

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");

                var response = await client.GetAsync($"/api/{url}");

                return await response.Content.ReadAsStringAsync();
            }
        }


        public static async Task Login(string u, string p)
        {
            var json = await Post("Sys/PasswordLogin", new { Name = u, Password = p }, true);
            var data = JsonSerializer.Deserialize<Result<JsonObject>>(json).Data;
            Token = data["Token"].ToString();
            UId = data["UserId"].ToString();
        }


        public static async Task<AutoDto> BasicInfo()
        {
            var json = await Get("Sys/GetAllClientAuth");
            return JsonSerializer.Deserialize<Result<List<AutoDto>>>(json).Data[0];
        }

        public static async Task<string> GetDeviceId(string ProcessId, string Ip)
        {
            var json = await Get($"Eq/GetProcessEqList?processFlowId={ProcessId}&ipAddr={Ip}");
            var data = JsonSerializer.Deserialize<Result<JsonObject>>(json).Data;
            return data["ProductionEqList"][0]["Id"].ToString();
        }

        public static async Task<string> GetToken(string ProcessId)
        {
            var vali = await Post("Flow/SecondValidate", new { ProcessFlowId = ProcessId, Password = "666666" });
            return JsonSerializer.Deserialize<Result<JsonObject>>(vali).Data["Token"].ToString();
        }

        public static async Task<string> Start(string Tcode, string Pid, string Ip, string Proid, string code, string Pcoid)
        {
            var json = await Post("Flow/NormalStart", new
            {
                ProductId = Pid,
                ProcessIds = new[] { Pcoid },
                IpAddr = Ip,
                UserId = UId,
                ProLineId = Proid,
                FlowCode = code,
                SecondValidateToken = Tcode
            });
            var data = JsonSerializer.Deserialize<Result<JsonObject>>(json).Data;
            return data["ProcessRunStatus"][0]["FlowRecordId"].ToString();
        }

        public static async Task<bool> Submit(string DId, string PcId, string Fid, string Proid)
        {
            RootGatherModel model = new RootGatherModel
            {
                Alarms = new List<AlarmInfos>(),
                Cutters = new List<KnifeInfos>(),
                EqBase = new BasicInfos(),
                Runs = new List<RunInfos>()
            };
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(model));
            var BASE64Data = Convert.ToBase64String(bytes);
            var json = await Post("Run/CompleteOne", new
            {
                EquipmentId = DId,
                ProcessId = PcId,
                FlowRecordId = Fid,
                ProLineId = Proid,
                ProcessType = 1,
                StartUpMode = 1,
                CollectData = BASE64Data
            });
            return JsonSerializer.Deserialize<Result<JsonObject>>(json).Success;
        }
    }
}
