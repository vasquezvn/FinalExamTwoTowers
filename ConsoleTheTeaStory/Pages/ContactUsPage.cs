using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTheTeaStory.Pages
{
    public class ContactUsPage
    {
        public static ContactUsCommand SetName(string name)
        {
            return new ContactUsCommand().SetName(name);
        }

        public static bool IsMessageSend(string message)
        {
            return new ContactUsCommand().IsMessageSend(message);
        }
    }
}
