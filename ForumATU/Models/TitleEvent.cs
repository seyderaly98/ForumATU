using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ForumATU.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumATU.Models
{
    public class TitleEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CrateDate { get; } = DateTime.Now;
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public virtual List<TopicEvent> TopicEvents { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }

    public class TopicEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TopicNumber { get; set; }
        public int MessageNumber { get; set; }
        public DateTime CrateDate { get; } = DateTime.Now;
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public virtual List<Topic> Topics { get; set; }
        
        public string AuthorChangeId { get; set; }
        public virtual User AuthorChange { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        public int TitleEventId { get; set; }
        public virtual TitleEvent TitleEvent { get; set; }

    }

    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AnswerNumber { get; set; }
        public int ViewsNumber { get; set; }
        public DateTime CrateDate { get; set; } = DateTime.Now;
        public DateTime ChangeDate { get;  } = DateTime.Now;
        /// <summary>
        /// Метки 
        /// </summary>
        /// Несколько меток разделены запятыми.
        public string Marks { get; set; }

        public DateTime DateLastMessage { get; set; }

        public virtual List<Message> Messages { get; set; }
        
        public string AuthorLastMessageId { get; set; }
        public virtual User AuthorLastMessage { get; set; }
        
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        public int TopicEventId { get; set; }
        public virtual TopicEvent TopicEvent { get; set; }
        
        public Topic(){}
        public Topic(TopicViewModel model,string authorId)
        {
            Name = model.TopicTitle;
            Marks = model.Marks;
            Description = model.Description;
            TopicEventId = model.TopicEventId;
            AuthorId = authorId;
        }
        
    }

    public class Message
    {
        public int Id { get; set;  }
        public string Text { get; set; }
        public DateTime CrateDate { get; set; } = DateTime.Now;
        public DateTime ChangeDate { get;  } = DateTime.Now;

        public string UserId { get; set; }
        public virtual User Author { get; set; }
        
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}