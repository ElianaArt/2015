using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMenager mm = new MailMenager();
            Fax fax = new Fax(mm);
            mm.SimulateNewMail("a","b","c");
            Console.ReadLine();
        }

        internal sealed class Fax
        {
            public Fax(MailMenager mm)
            {
                mm.NewMail += FaxMsg;
            }

            private void FaxMsg(Object sender, NewMailEventArgs e)
            {
               
                try
                {
                    MailMenager mm = (MailMenager)sender;
                    Console.WriteLine("факс получил сообщение: ");
                    Console.WriteLine("From: {0}, To: {1}, Subject: {2}", e.From, e.To, e.Subject);
                   
                    mm.SimulateNewMail("a", "b", "c");
                }
                catch (StackOverflowException ex)
                {
                    MailMenager mm = (MailMenager)sender;
                    Unregister(mm);
                    Console.WriteLine("Отписались");
                }
            }

            public void Unregister(MailMenager mm)
            {
                mm.NewMail -= FaxMsg;
            }
        }

        //Этап определения типа для хрнения информации
        // Которая передается получателям уведомления о событиии

        internal  class NewMailEventArgs : EventArgs
        {
            private readonly String m_from, m_to, m_subject;

            public NewMailEventArgs(String from, String to, String subject)
            {
                m_from = from;
                m_to = to;
                m_subject= subject;
            }

            public String From { get { return m_from; } }
            public String To { get { return m_to; } }
            public String Subject { get { return m_subject; } }

        }

        internal class MailMenager
        {
            public event EventHandler<NewMailEventArgs> NewMail;

            protected virtual void OnNewMail(NewMailEventArgs e)
            {
                EventHandler<NewMailEventArgs> temp = Interlocked.CompareExchange(ref NewMail, null, null);
                if (temp != null)
                    temp(this, e);
            }

            public void SimulateNewMail(String from, String to, String subject)
            {
                NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
                OnNewMail(e);
            }
        }
    }
}
