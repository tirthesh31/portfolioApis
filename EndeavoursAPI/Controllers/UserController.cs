using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endeavours.DAL;
using Endeavours.Entities;
using Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndeavoursAPI.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public FirstPageView Get(int id)
        {
            UserRepository repo = new UserRepository();
            FirstPageView page = repo.GetFirstPageView(id);
            List<OtherUserView> users = repo.GetTopSixUsers();
            page.OtherUsers = users;
            return page;
        }

        // POST api/<UserController>
        [HttpPost]
        public int Post(RegistrationClass register)
        {
            UserRepository repo = new UserRepository();
            int last_insert_id =repo.Register(register.user,register.profile);
            return last_insert_id;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, User user)
        {
            UserRepository repository = new UserRepository();
            repository.Update(user,id);
        }

        


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("LoginPage/{email},{password}")]
        public int LoginPage(string email, string password)
        { 
            UserRepository userRepository = new UserRepository();
            int row = userRepository.GetByEmailPassword(email,password);
            return row;
        }

        [HttpGet("CheckUser/{username}")]
        public bool CheckUserExists(string username)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.CheckUserNameExists(username);
        }

        [HttpGet("CheckEmail/{email}")]
        public bool CheckEmailExists(string email)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.CheckEmailExists(email);
        }

        [HttpGet("ForgotPassword/{email},{OTP}")]
        public IActionResult SendMailToUserForOTP(string email,int OTP)
        {
            try
            {
                UserRepository repo = new UserRepository();
                string usernameFullName = repo.GetUserNameAndFullNamefromEmail(email);

                if (usernameFullName == null)
                    return BadRequest("user does not exists");

                Mailer mailer = new Mailer();
                string Subject = "Otp for forgot password";
                string Body = @"
                                <!DOCTYPE html>
                                <html>
                                <head>
                                    <meta charset=""utf-8"">
                                    <title>Email Template</title>
                                    <style>
                                        body {
                                            font-family: Arial, sans-serif;
                                            background-color: #f2f2f2;
                                            margin: 0;
                                            padding: 0;
                                        }

                                        .container {
                                            max-width: 600px;
                                            margin: 0 auto;
                                            background-color: #ffffff;
                                            padding: 20px;
                                        }

                                        h1 {
                                            color: #333333;
                                        }

                                        p {
                                            color: #555555;
                                            margin-bottom: 20px;
                                        }

                                        .button {
                                            display: inline-block;
                                            padding: 10px 20px;
                                            background-color: #007bff;
                                            color: #ffffff;
                                            text-decoration: none;
                                            border-radius: 4px;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class=""container"">
                                        <h1>Hey there {{{@Username}}}!</h1>
                                        <p>It seems like you have forgotten your password, do not worry enter this otp</p>
                                        <p>{{{@OTP}}} and do not share this with anybody</p>
                                    </div>
                                </body>
                            </html>
                            ";

                Body = Body.Replace("{{{@OTP}}}",OTP.ToString());
                Body = Body.Replace("{{{@Username}}}", usernameFullName);
                mailer.SendMail(Subject,Body,email);
                return Ok();
            }
            catch (Exception error)
            { 
                return BadRequest("sorry some server side error has occured");
            }
        }

    }
}
