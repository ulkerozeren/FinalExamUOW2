using FinalExamUOW2.Data.Interfaces;
using FinalExamUOW2.Data.Models;
using FinalExamUOW2.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FinalExamUOW2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.UserRepository.List();
            return new JsonResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_unitOfWork.UserRepository.Find(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(int id, [FromBody] List<User> users)
        {
            foreach (var user in users)
            {
                var result = _unitOfWork.UserRepository.Find(user.Id);

                if (result == null)
                {
                    _unitOfWork.UserRepository.Insert(user);
                    _unitOfWork.Complete();

                    //InsertLog(user);
                   
                    new PublisherHelper("userLog", user.FirstName + " " + user.LastName);
                    //var consumerHelper = new ConsumerHelper("userLog");
                }
            }

            return new JsonResult(users);
        }

        private void InsertLog(User user)
        {
            UserLog userLog = new UserLog()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreateDate = DateTime.UtcNow
            };

            _unitOfWork.UserLogRepository.Insert(userLog);
            _unitOfWork.Complete();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new JsonResult(new Tuple<bool, int>(_unitOfWork.UserRepository.Delete(id), _unitOfWork.Complete()));
        }
    }
}