using System.Collections.Generic;
using System.Linq;
using ForumATU.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Models.Data
{
    public class ForumContext : IdentityDbContext<User>
    {
        public  DbSet<User> Users { get; set; }
        public DbSet<TopicEvent> TopicEvents { get; set; }
        public DbSet<TitleEvent> TitleEvents { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        
        public ForumContext(DbContextOptions<ForumContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "2d8e581a-3813-44c2-86a4-4d779034541d",
                Name = "Admin",
            };
            base.OnModelCreating(builder);
            builder.Entity<User>().HasData(user);

            List<TitleEvent> itemEvents = new List<TitleEvent>()
            {
                new TitleEvent(){Id = 1,Name = "Кейсы и новости",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TitleEvent(){Id = 2,Name = "Общие вопросы",Description = "Вопросы по использованию ATU studyspace. Информация про новые релизы версии. Ваши отзывы и предложения по улучшению",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TitleEvent(){Id = 3,Name = "Технические вопросы",Description = "Описание технических вопросов, возникающих во время учебы, и способов их решения",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TitleEvent(){Id = 4,Name = "Специалистам, работа",Description = "Приглашайте специалистов и специалисты предлагайтесь",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
            };
            
            base.OnModelCreating(builder);
            builder.Entity<TitleEvent>().HasData(itemEvents);

            List<TopicEvent> topicEvents = new List<TopicEvent>()
            {
                new TopicEvent(){Id = 1,TitleEventId = 1,Name = "Примеры реальных проектов",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 2,TitleEventId = 1,Name = "Новые вебинары",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 3,TitleEventId = 1,Name = "Советы",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 4,TitleEventId = 2,Name = "Для чего мне studyspace",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 5,TitleEventId = 2,Name = "Отзывы",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 6,TitleEventId = 2,Name = "Новое (новые версии, обновления, новости)",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 7,TitleEventId = 2,Name = "Как перейти на грант",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 8,TitleEventId = 3,Name = "Факультет инжиниринга и информационных технологий",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 9,TitleEventId = 3,Name = "Факультет легкой промышленности и дизайна",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 10,TitleEventId = 3,Name = "Факультет пищевых производств",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 11,TitleEventId = 3,Name = "Факультет экономики и бизнеса",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 12,TitleEventId = 3,Name = "Факультет дистанционного обучения",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 13,TitleEventId = 4,Name = "Специалистам, работа",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 14,TitleEventId = 4,Name = "Вакансии",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",Description = "Разместите здесь свое предложение о работе",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 15,TitleEventId = 4,Name = "Резюме",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d",Description = "Разместите здесь свое резюме или вопросы, связанные с его составлением",AuthorChangeId = "2d8e581a-3813-44c2-86a4-4d779034541d"},

            };
            base.OnModelCreating(builder);
            builder.Entity<TopicEvent>().HasData(topicEvents);
            
            Statistics _statistics = new Statistics(){Id = 1 ,UserId = "2d8e581a-3813-44c2-86a4-4d779034541d",Topic = (itemEvents.Count + topicEvents.Count),Users = 1};
            base.OnModelCreating(builder);
            builder.Entity<Statistics>().HasData(_statistics);

        }
    }
}