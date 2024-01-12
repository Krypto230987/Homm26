using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homm26._2
{
    using System;

    class MyMessage
    {
        public string MessageType { get; }
        public string Message { get; }

        public MyMessage(string type, string message)
        {
            MessageType = type;
            Message = message;
        }
    }

    class Phone
    {

        MessageManager messageManager = new MessageManager();
        private void ReceiveSms(MyMessage msg)
        {
            if (msg.MessageType == "sms")
            {
                Console.WriteLine($"Получил смс {msg.Message}");
            }
        }
        public void Sms()
        {
            messageManager.NewMessage += ReceiveSms;
        }
    }

    class Mail
    {
        MessageManager messageManager = new MessageManager();
        private void ReceiveMail(MyMessage msg)
        {
            if (msg.MessageType == "email")
            {
                Console.WriteLine($"Получил письмо {msg.Message}");
            }
        }
        public void Email()
        {
            messageManager.NewMessage += ReceiveMail;
        }
    }

    class MessageManager
    {
        public event Action<MyMessage> NewMessage;

        public void SendMessage(MyMessage message)
        {
            NewMessage?.Invoke(message);
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            MessageManager messageManager = new MessageManager();

            Phone phone = new Phone();
            Mail mail = new Mail();

            phone.Sms();
            mail.Email();

            Console.WriteLine("Отправка сообщения");
            Console.Write("Введите тип сообщения: ");
            string messageType = Console.ReadLine();
            Console.Write("Введите сообщение: ");
            string messageText = Console.ReadLine();

            MyMessage message = new MyMessage(messageType, messageText);
            messageManager.SendMessage(message);

            Console.ReadLine();
        }
    }
}
