using BussiensLayer.Abstract;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public List<Message> AllMessage()
        {
            return _messagedal.List();
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p);
        }
        public List<Message> GetListSendbox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messagedal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }
    }
}
