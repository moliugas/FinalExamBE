﻿using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User Get(Guid id);
        public void Delete(Guid id);
    }
}