using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApplicantPortal.Application.Common.Interfaces;
using ApplicantPortal.Domain.Entities;

namespace ApplicantPortal.Infrastructure.SMS
{
    public class SmsService : ISmsSender
    {
        private readonly IApplicationDbContext _context;
        private readonly IApplicantRepository _applicantRepository;
        private readonly HttpClient _httpClient;

        public SmsService(IApplicationDbContext context, IApplicantRepository applicantRepository)
        {
            _context = context;
            _applicantRepository = applicantRepository;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task SendSms(string phoneNumber, string message, long formNo, string appSender, CancellationToken cancellationToken = default)
        {
            try
            {
                var applicant = await _applicantRepository.GetApplicantByApplicationNumber(formNo, cancellationToken);

                const string baseUrl = "https://smsc.hubtel.com/v1/messages/send";
                const string senderId = "TTU";
                const string user = "ifrzlixd";
                const string pass = "zrydysvw";

                phoneNumber = string.Concat("+233", phoneNumber.AsSpan(1, 9));
                phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");
                var recipient = phoneNumber;
                var messageText = message;

                var queryParams = $"?clientid={user}&clientsecret={pass}&from={senderId}&to={recipient}&content={messageText}";
                var apiUrl = baseUrl + queryParams;

                Console.WriteLine("URL: " + apiUrl);

                var response = await _httpClient.GetAsync(apiUrl, cancellationToken);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<SMSResponse>(responseContent);

                Console.WriteLine("Response: " + jsonResponse!.status);

                if (jsonResponse.status == 0)
                {
                    var sms = new SmsModel
                    {
                        Recipient = formNo,
                       
                        Message = message,
                        SentBy = appSender,
                        Status = "successful",
                        Applicant = applicant.Id
                    };
                    await _context.SmsModels.AddAsync(sms, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HTTP Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
