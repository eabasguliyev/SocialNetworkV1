﻿using System;
using Exceptions;
using Network;

namespace Account
{
    struct UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserCredentials(ref string username, ref string password)
        {
            Username = username;
            Password = Hash.Hash.GetHashSha256(password);
        }
    }

    class CreateAccountSession
    {
        private string ConfirmationCode { get; set; }
        public void Registration(ref Database.Database db, ref User.User user)
        {
            try
            {
                db.AddUser(ref user);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SendConfirmationCode(in string mail)
        {
            ConfirmationCode = Helper.MailHelper.GenerateCode();
            Mail.SendMail(mail, "There is last step to do.", $"Confirmation code is {ConfirmationCode}");
        }

        public bool ConfirmAccount(ref User.User user, in string code)
        {
            if (code == ConfirmationCode)
            {
                user.Activation = true;
                return true;
            }

            return false;
        }
    }

    class LoginAccountSession
    {
        public bool Status { get; set; }
        public User.User User{ get; set; }

        public void Login(in Database.Database db, UserCredentials credentials)
        {
            var user = Array.Find(db.Users, user1 => user1.Username == credentials.Username);

            if (user == null)
                throw new LoginException($"There is no account associated this username -> {credentials.Username}");

            if (user.Password != credentials.Password)
                throw new LoginException($"Password is wrong!");

            User = user;
            Status = true;
        }

        public void Logout()
        {
            Status = false;
        }
    }
}
