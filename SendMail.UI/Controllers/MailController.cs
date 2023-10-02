using Microsoft.AspNetCore.Mvc;
using SendMail.UI.DAL.Interface;
using SendMail.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.UI.Controllers
{
    public class MailController : Controller
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IMailService _mailService;

        public MailController(IRabbitMQService rabbitMQService, IMailService mailService)
        {
            _rabbitMQService = rabbitMQService;
            _mailService = mailService;
        }

        public IActionResult MailAction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MailAction(MailDTO mailDTO)
        {
            string mailAdres = mailDTO.mailAdres;
            string textArea = mailDTO.TextArea;

            // Burada yapılacak işlemler...

            // RabbitMQ'ya mesaj gönder (asenkron)
            await Task.Run(() => _rabbitMQService.SendMessage($"Mail Adresi: {mailAdres}, İçerik: {textArea}"));

            // Mail gönder (asenkron)
            await _mailService.SendEmailAsync(mailAdres, "Konu", textArea);

            return View();
        }
    }
}
