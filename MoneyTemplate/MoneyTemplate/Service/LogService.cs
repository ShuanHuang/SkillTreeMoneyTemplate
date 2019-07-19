using MoneyTemplate.Models;
using MoneyTemplate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTemplate.Service {
    public class LogService {
        //private readonly SkillTreeHomeworkEntities _db = new SkillTreeHomeworkEntities();
        private readonly Repository<AccountBook> _logRepository;
        public LogService(IUnitOfWork unitOfWork) {
            //_db = new SkillTreeHomeworkEntities();
            _logRepository = new Repository<AccountBook>(unitOfWork);
        }
        public void AddLog(AccountBook data) {
            //_db.AccountBook.Add(data);
            _logRepository.Create(data);
        }
        //public void SaveToLog() {
        //    _db.SaveChanges();
        //}
    }
}