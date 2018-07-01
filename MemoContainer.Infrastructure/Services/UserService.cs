using System;
using System.Threading.Tasks;
using AutoMapper;
using MemoContainer.Core.Domain;
using MemoContainer.Core.Repositories;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ITokenProvider tokenProvider, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
            _mapper = mapper;
        }

        public async Task RegisterAsync(Guid userId, string nickname, string email, string firstName, string lastName, string password, string role = "user")
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }

            user = await _userRepository.GetByNicknameAsync(nickname);
            if (user != null)
            {
                throw new Exception($"User with nickname: {nickname} already exists.");
            }
            
            user = new User(userId, nickname, firstName, lastName, role, email, password);
            await _userRepository.AddAsync(user);
        }

        public async Task<TokenDTO> LoginByEmailAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if(user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }

            return _tokenProvider.GetToken(user.Id, user.Role);
        }

        public async Task<TokenDTO> LoginByNicknameAsync(string nickname, string password)
        {
            var user = await _userRepository.GetByNicknameAsync(nickname);

            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }

            return _tokenProvider.GetToken(user.Id, user.Role);
        }

        public async Task<UserDTO> GetUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"User with id: {userId} doesn't exists.");
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}