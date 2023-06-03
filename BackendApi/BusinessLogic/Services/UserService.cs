using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<Customer> GetByLogin(string login) 
        { 
            var user = await _repositoryWrapper.User.FindByCondition(x => x.Login == login);
            return user.First();
        }

        public async Task Create(Customer model) 
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Login))
            {
                throw new ArgumentException(nameof(model.Login));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Customer model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(string login) 
        {
            var user = await _repositoryWrapper.User.FindByCondition(x =>x.Login == login);

            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
