using ChatApp.DataAccessLayer.Interface;
using ChatApp.Models;
using Newtonsoft.Json;
using static ChatApp.DataAccessLayer.Repositories.SMSSenderService;
using System.Net;

namespace ChatApp.DataAccessLayer.Repositories
{
    public class SMSSenderService : ISMSSender
    {

        private readonly string BASE_URL = "";
        private readonly string API_KEY = "";
        private readonly string SENDER = "";
        private readonly string EMAIL = "";
        private readonly string PASSWORD = "";
        private string TOKEN = "";

        public SMSSenderService(IConfiguration config)
        {
            BASE_URL = "https://notify.eskiz.uz"!;
            SENDER = "4546"!;
            EMAIL = "SamandarbekYR@gmail.com"!;
            PASSWORD = "ECjVrcXajdbPRTRXRGJM7u8jEXcAdHgVVzeJFvHB"!;
        }

        private async Task LoginAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/login");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(EMAIL), "email");
            content.Add(new StringContent(PASSWORD), "password");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                EskizLoginDto dto = JsonConvert.DeserializeObject<EskizLoginDto>(json)!;
                TOKEN = dto.Data.Token;
            }
        }
        public async Task<bool> SendAsync(SMSSenderDto message)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/message/sms/send");
            request.Headers.Add("Authorization", $"Bearer {TOKEN}");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(message.Recipent), "mobile_phone");
            content.Add(new StringContent(message.Title + " " + message.Content), "message");
            content.Add(new StringContent(SENDER), "from");
            content.Add(new StringContent("http://0000.uz/test.php"), "callback_url");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await LoginAsync();
                return await SendAsync(message);
            }
            else if (response.IsSuccessStatusCode)
                return true;
            else
                return true;
        }

        public class EskizLoginDto
        {
            public string Message { get; set; } = string.Empty;

            public EskizToken Data { get; set; }

            public EskizLoginDto()
            {
                Data = new EskizToken();
            }

            public class EskizToken
            {
                public string Token { get; set; } = string.Empty;
            }
        }
    }
}

