namespace ClientSocket.DTO
{
    public class MessageModel<T>
    {
        public string? Message { get; set; }
        public bool? Status { get; set; }
        public string? Code { get; set; }
        public new T Data { get; set; }

        public static MessageModel<T> Success<T>(T data)
        {
            return new MessageModel<T>()
            {
                Status = true,
                Message = "操作成功",
                Data = data
            };
        }
        public static MessageModel<T> Error<T>(T data)
        {
            return new MessageModel<T>()
            {
                Status = false,
                Message = "操作失败",
                Data = data
            };
        }
    }
}
