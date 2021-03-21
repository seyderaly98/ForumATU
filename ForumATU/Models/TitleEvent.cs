using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumATU.Models
{
    public class TitleEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CrateDate { get; } = DateTime.Now;
        public List<TopicEvent> TopicEvents { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
    }

    public class TopicEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TopicNumber { get; set; }
        public int MessageNumber { get; set; }
        public DateTime CrateDate { get; } = DateTime.Now;
        public DateTime ChangeDate { get;  } = DateTime.Now;
        
        public List<Topic> Topics { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public int TitleEventId { get; set; }
        public TitleEvent TitleEvent { get; set; }

    }

    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnswerNumber { get; set; }
        public int ViewsNumber { get; set; }
        public DateTime CrateDate { get; set; } = DateTime.Now;
        public DateTime ChangeDate { get;  } = DateTime.Now;

        public DateTime DateLastMessage { get; set; }

        public List<Message> Messages { get; set; }
        
        public string AuthorLastMessageId { get; set; }
        public User AuthorLastMessage { get; set; }
        
        public string AuthorId { get; set; }
        public User Author { get; set; }
        
    }

    public class Message
    {
        public int Id { get; set;  }
        public string Text { get; set; }
        public DateTime CrateDate { get; set; } = DateTime.Now;
        public DateTime ChangeDate { get;  } = DateTime.Now;

        public string UserId { get; set; }
        public User Author { get; set; }
        
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}