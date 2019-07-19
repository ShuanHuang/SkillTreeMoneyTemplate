using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyTemplate.Models;
using System.Data.Entity;
using MoneyTemplate.Repository;

namespace MoneyTemplate.Service {
    public class MoneyTemplateService {
        //private readonly SkillTreeHomeworkEntities _db;
        private readonly Repository<AccountBook> _logRepository;
        public MoneyTemplateService(IUnitOfWork unitOfWork) {
            //_db = new SkillTreeHomeworkEntities();
            _logRepository = new Repository<AccountBook>(unitOfWork);
        }
        //public IEnumerable<AccountBook> AccountBookSelect(int? top = null) {
        //    return top == null ? _db.AccountBook.ToList() : _db.AccountBook.Take(top.Value).ToList();
        //}
        public IEnumerable<AccountBook> AccountBookSelect(int? top = null) {
            return top == null ? _logRepository.LookupAll() : _logRepository.LookupTop(top.Value);
        }

        public void Add(AccountBook data) {
            //_db.AccountBook.Add(data);
            _logRepository.Create(data);
        }
        public void Edit(AccountBook pageData, AccountBook oldData) {
            oldData.Categoryyy = pageData.Categoryyy;
            oldData.Amounttt = pageData.Amounttt;
            oldData.Dateee = pageData.Dateee;
        }
        public void Delete(AccountBook data) {
            //_db.AccountBook.Remove(data);
            _logRepository.Remove(data);
        }
        //public void SaveToDB() {
        //    _db.SaveChanges();
        //}
    }
}