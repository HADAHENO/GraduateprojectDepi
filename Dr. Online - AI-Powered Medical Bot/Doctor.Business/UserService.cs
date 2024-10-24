using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctor.Data;
using Doctor.Model;
using Doctor.Model.App;
using Microsoft.Extensions.Logging;

namespace Doctor.Business
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public ApplicationUser GetUserById(int Id)
        {
            var user = _userRepository.GetById(Id);
            if (user == null)
            {
                _logger.LogError($"User with ID {Id} not found.");
                return null;
            }
            return user;
        }

        public void UpdateUser(ApplicationUser updatedUser)
        {
            var user = _userRepository.GetById(updatedUser.Id);
            if (user == null)
            {
                _logger.LogError($"User with ID {updatedUser.Id} not found.");
                return;
            }

            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;

            _userRepository.Add(user);
        }
    }
}


