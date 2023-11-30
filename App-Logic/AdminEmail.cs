using Azure.Communication.Email;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic
{
    public class AdminEmail
    {
        public async Task<string> SendEmail(string subject, string plainTextContent, string emailAddress)
        {
            string connectionString = "endpoint=https://isa-ieee-communicationservice.unitedstates.communication.azure.com/;accesskey=p/eEvRFgsQVGdGdACB1wInqOKaxSdGOfpoO0g5ybFqp7kKWquqTF4SPsTyfm7EX8nTgfGlGnX7mF3q/SYxrmsQ==";

            EmailClient emailClient = new EmailClient(connectionString);

            EmailContent emailContent = new EmailContent(subject);
            emailContent.PlainText = plainTextContent;

            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress(emailAddress, "Suscriptor de Pet Inc.") };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            EmailMessage emailMessage = new EmailMessage("DoNotReply@fc248c30-351e-4e54-a77b-1859390c2d5b.azurecomm.net", emailRecipients, emailContent);
            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage, CancellationToken.None);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

            return emailSendOperation.Value.Status.ToString();
        }

        public async Task<string> SendOTPEmail(string emailAddress, int otp)
        {

            string subject = "Your OTP";
            string plainTextContent = "Your OTP code is: " + otp;

            return await SendEmail(subject, plainTextContent, emailAddress);
        }


        public async Task<string> SendReservationConfirmationEmail(string emailAddress)
        {

            string subject = "Reservation Confirmation";
            string plainTextContent = "Thank you for your reservation. Your booking is confirmed."; // Cambia esto con el contenido específico de confirmación de reserva

            return await SendEmail(subject, plainTextContent, emailAddress);
        }
    }

}
