using DataOffsets.Dto;

namespace DataOffsets
{



    public partial class DataOffset : Form
    {
        public DataOffset()
        {
            InitializeComponent();

        }

        private async void b1_Click(object sender, EventArgs e)
        {
            await Request.Login(t1.Text, t2.Text);
            var datas = await Request.BasicInfo();

            var c1data = new List<Temp>();
            var c2data = new List<Temp>();
            var c3data = new List<Temp>();


            datas.ForEach(data =>
            {
                if (c1data.FirstOrDefault(t => t.Value == data.ProLineId) == null)
                    c1data.Add(new Temp { Key = data.ProLineName, Value = data.ProLineId });

                if (c2data.FirstOrDefault(t => t.Value == data.ProductList[0].ProductId) == null)
                    c2data.Add(new Temp { Key = data.ProductList[0].ProductName, Value = data.ProductList[0].ProductId });

                if (c3data.FirstOrDefault(t => t.Value == data.ProcessList[0].ProcessId) == null)
                    c3data.Add(new Temp { Key = data.ProcessList[0].ProcessName, Value = data.ProcessList[0].ProcessId });
            });

            c1.DataSource = c1data;
            c2.DataSource = c2data;
            c3.DataSource = c3data;

            c1.DisplayMember = c2.DisplayMember = c3.DisplayMember = "Key";
            c1.ValueMember = c2.ValueMember = c3.ValueMember = "Value";
        }

        private async void b2_Click(object sender, EventArgs e)
        {

            var deviceId = await Request.GetDeviceId(c3.SelectedValue.ToString(), t4.Text);
            var VToken = await Request.GetToken(c3.SelectedValue.ToString());
            var FlowId = await Request.Start(VToken, c2.SelectedValue.ToString(), t4.Text, c1.SelectedValue.ToString(), t3.Text, c3.SelectedValue.ToString());
            for (int index = 0; index < int.Parse(t5.Text); index++)
            {
                var res = await Request.Submit(deviceId, c3.SelectedValue.ToString(), FlowId, c1.SelectedValue.ToString());
                lb.Items.Add($"是否完成：{(res ? "是" : "否")}");
                lb.Items.Add(" ");
                if (res)
                    break;
            }
        }
    }
}
