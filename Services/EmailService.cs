using System.Security.Cryptography.X509Certificates;
using isg_crm.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendPasswordEmailAsync(string toEmail, string password)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("ISG CRM", _config["Email:SmtpUser"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "ISG CRM - Giriş Şifreniz";

        var builder = new BodyBuilder();

        builder.HtmlBody = $@"
        <html>
        <body style='font-family: Arial, sans-serif; background-color: #f6f8fb; padding: 20px;'>
            <div style='max-width: 600px; margin: auto; background: white; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); padding: 20px;'>
                <h2 style='color: #2c3e50;'>Merhaba,</h2>
                <p style='font-size: 16px; color: #333;'>Sisteme giriş yapabilmeniz için otomatik olarak oluşturulan şifreniz aşağıdadır:</p>

                <div style='text-align: center; margin: 20px 0;'>
                    <span style='display: inline-block; background: #2ecc71; color: white; padding: 10px 20px; border-radius: 6px; font-size: 20px; font-weight: bold; letter-spacing: 1px;'>{password}</span>
                </div>

                <p style='font-size: 15px; color: #e74c3c; font-weight: bold;'>⚠ Lütfen ilk girişinizden sonra şifrenizi değiştiriniz.</p>
                
                <hr style='margin: 20px 0; border: none; border-top: 1px solid #ddd;' />
                <p style='font-size: 14px; color: #7f8c8d;'>Bu e-posta otomatik olarak gönderilmiştir. Yanıt vermeyiniz.</p>
            </div>
        </body>
        </html>";

        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_config["Email:SmtpServer"], int.Parse(_config["Email:SmtpPort"]), false);
            await client.AuthenticateAsync(_config["Email:SmtpUser"], _config["Email:SmtpPass"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

    }
    public async Task SendAssignEmailAsync(string toEmail, string companyName, string companyAddress, string employeeName, string description)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("ISG CRM", _config["Email:SmtpUser"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "ISG CRM - Yeni Atama";

        var builder = new BodyBuilder();

        builder.HtmlBody = $@"
        <html>
        <body style='font-family: Arial, sans-serif; background-color: #f6f8fb; padding: 20px;'>
            <div style='max-width: 600px; margin: auto; background: white; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); padding: 20px;'>
                <h2 style='color: #2c3e50;'>Merhaba,</h2>
                <p style='font-size: 16px; color: #333;'>Aşağıdaki şirket ve çalışan için yeni bir atama yapılmıştır:</p>

                <ul style='list-style-type: none; padding: 0;'>
                <li><strong>Açıklama:</strong> {description}</li>
                    <li><strong>Şirket:</strong> {companyName}</li>
                    <li><strong>Şirket Adresi:</strong> {companyAddress}</li>
                    <li><strong>Çalışan:</strong> {employeeName}</li>
                </ul>

                <hr style='margin: 20px 0; border: none; border-top: 1px solid #ddd;' />
                <p style='font-size: 14px; color: #7f8c8d;'>Bu e-posta otomatik olarak gönderilmiştir. Yanıt vermeyiniz.</p>
            </div>
        </body>
        </html>";

        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_config["Email:SmtpServer"], int.Parse(_config["Email:SmtpPort"]), false);
            await client.AuthenticateAsync(_config["Email:SmtpUser"], _config["Email:SmtpPass"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
