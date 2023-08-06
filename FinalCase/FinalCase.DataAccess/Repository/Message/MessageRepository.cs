using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.DataAccess.Repository;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    private readonly FinalCaseDbContext dbContext;
    public MessageRepository(FinalCaseDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    // Kullanıcının okunmamış mesajlarını getiren metot
    public IEnumerable<Message> GetUnreadMessagesByUserId(int userId)
    {
        return dbContext.Set<Message>().Where(message => message.UserId == userId && !message.IsRead).ToList();    }

    // Belirli bir konuya göre mesajları getiren metot
    public IEnumerable<Message> GetMessagesByTopic(string topic)
    {
        return dbContext.Set<Message>().Where(message => message.Subject == topic).ToList();
    }


}