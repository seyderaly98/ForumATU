using System.Collections.Generic;
using ForumATU.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Models.Data
{
    public class ForumContext : IdentityDbContext<User>
    {
        public  DbSet<User> Users { get; set; }
        public DbSet<TopicEvent> TopicEvents { get; set; }
        public DbSet<ItemEvent> ItemEvents { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        
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
            
            List<ItemEvent> itemEvents = new List<ItemEvent>()
            {
                new ItemEvent(){Id = 1,Name = "Кейсы и новости",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new ItemEvent(){Id = 2,Name = "Общие вопросы",Description = "Вопросы по использованию ATU studyspace. Информация про новые релизы версии. Ваши отзывы и предложения по улучшению",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new ItemEvent(){Id = 3,Name = "Технические вопросы",Description = "Описание технических вопросов, возникающих во время учебы, и способов их решения",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new ItemEvent(){Id = 4,Name = "Специалистам, работа",Description = "Приглашайте специалистов и специалисты предлагайтесь",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
            };
            
            base.OnModelCreating(builder);
            builder.Entity<ItemEvent>().HasData(itemEvents);

            List<TopicEvent> topicEvents = new List<TopicEvent>()
            {
                new TopicEvent(){Id = 1,ItemEventId = 1,Name = "Примеры реальных проектов",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 2,ItemEventId = 1,Name = "Новые вебинары",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 3,ItemEventId = 1,Name = "Советы",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 4,ItemEventId = 2,Name = "Для чего мне studyspace",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 5,ItemEventId = 2,Name = "Отзывы",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 6,ItemEventId = 2,Name = "Новое (новые версии, обновления, новости)",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 7,ItemEventId = 2,Name = "Как перейти на грант",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 8,ItemEventId = 3,Name = "Факультет Инжиниринга и Информационных Технологий",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 9,ItemEventId = 3,Name = "Факультет Легкой Промышленности и Дизайна",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 10,ItemEventId = 3,Name = "Факультет Пищевых Производств",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 11,ItemEventId = 3,Name = "Факультет экономики и бизнеса",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 12,ItemEventId = 3,Name = "Факультет дистанционного обучения",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                
                new TopicEvent(){Id = 13,ItemEventId = 4,Name = "Специалистам, работа",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 14,ItemEventId = 4,Name = "Вакансии",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},
                new TopicEvent(){Id = 15,ItemEventId = 4,Name = "Резюме",AuthorId = "2d8e581a-3813-44c2-86a4-4d779034541d"},

            };
            base.OnModelCreating(builder);
            builder.Entity<TopicEvent>().HasData(topicEvents);

        }
    }
}