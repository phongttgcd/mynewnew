namespace COMP1640_WebDev.Services.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(string sendToEmail, string subject, string content);

    }
}
