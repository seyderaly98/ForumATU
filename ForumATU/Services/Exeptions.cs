using System;
using System.Collections.Generic;
using System.Linq;
using ForumATU.Models;

namespace ForumATU.Services
{
    internal static class Exeptions
    {
        internal static int GetMessageCount(this List<Topic> topics)
        {
            int messageCount = 0;
            try
            {
                messageCount += topics.Sum(topic => topic.AnswerNumber);
                return messageCount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
           
        }
        
        
    }
}