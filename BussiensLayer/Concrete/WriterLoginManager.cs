using BussiensLayer.Abstract;
using DataAccessLAyer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerdal;

        public WriterLoginManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerdal.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
