using System;
using System.Net;
using System.Net.Mail;
using EShop.Services.Abstract;
using EShop.Shared.Configurations.Email;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EShop.Services.Concrete
{
    public class EmailManager : IEmailService
    {
        private readonly EmailConfig _emailConfig;

        public EmailManager(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<ResponseDto<NoContent>> SendEmailAsync(string emailTo, string subject, string htmlBody)
        {
            try
            {
                if (string.IsNullOrEmpty(_emailConfig.SmtpServer))
                {
                    return ResponseDto<NoContent>.Fail("SMTP Sunucu Adresi yapılandırmasında sorun var!", StatusCodes.Status500InternalServerError);
                }
                if (string.IsNullOrEmpty(_emailConfig.SmtpUser))
                {
                    return ResponseDto<NoContent>.Fail("SMTP Kullanıcı Adı yapılandırmasında sorun var!", StatusCodes.Status500InternalServerError);
                }
                if (string.IsNullOrEmpty(_emailConfig.SmtpPassword))
                {
                    return ResponseDto<NoContent>.Fail("SMTP Parola yapılandırmasında sorun var!", StatusCodes.Status500InternalServerError);
                }
                if (string.IsNullOrEmpty(emailTo))
                {
                    return ResponseDto<NoContent>.Fail("Alıcı email adresi boş olamaz!", StatusCodes.Status400BadRequest);
                }
                if (!IsValidEmail(emailTo))
                {
                    return ResponseDto<NoContent>.Fail("Hatalı mail adresi!", StatusCodes.Status400BadRequest);
                }
                using var smtpClient = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
                {
                    EnableSsl = false,
                    Timeout = 10000,//10 sn
                    Credentials = new NetworkCredential(_emailConfig.SmtpUser, _emailConfig.SmtpPassword)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.SmtpUser),
                    To = { new MailAddress(emailTo) },
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                await smtpClient.SendMailAsync(mailMessage);
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (SmtpException ex)
            {
                return ResponseDto<NoContent>.Fail($"SMTP HATASI: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail($"HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }

        private bool IsValidEmail(string emailAddress)
        {
            try
            {
                var mailAddress = new MailAddress(emailAddress);
                return mailAddress.Address == emailAddress;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
