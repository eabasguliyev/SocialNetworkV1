using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Helper
{
    static class MailHelper
    {
        public static void ValidateMail(in string mail)
        {
            var mailComponents = mail.Split('@');

            if (mailComponents.Length != 2)
                throw new MailFormatException("Mail format is wrong. Try Again!");

            string id = mailComponents[0];
            string domain = mailComponents[1];

            if (!CheckForbiddenCharacter(id))
                throw new MailFormatException("Mail can not contain any of this chacarters -> !#$%&*()_+-= ");

            if (!CheckForbiddenCharacter(domain))
                throw new MailFormatException("Domain address can not contain any of this chacarters -> !#$%&*()_+-= ");
        }
        public static bool CheckForbiddenCharacter(in string data)
        {
            foreach (var @char in "!#$%&*()_+-=")
            {
                if (data.Contains(@char.ToString()))
                    return false;
            }

            return true;
        }

        public static string GenerateCode()
        {
            var random = new Random();

            return random.Next(1000, 9999).ToString();
        }
    }

    static class UserHelper
    {
        public static bool CheckForbiddenCharacter(in string data)
        {
            foreach (var @char in "1234567890-=!#$%&*()_+")
            {
                if (data.Contains(@char.ToString()))
                    return false;
            }

            return true;
        }

        public static bool CheckAge(in int age)
        {
            if (age >= 18)
                return true;
            return false;
        }

        public static bool CheckUsernameLength(in string username)
        {
            if (username.Length > 5)
                return true;
            return false;
        }

        public static void CheckPasswordStrong(in string password)
        {
            if (password.Length < 6)
                throw new PasswordFormatException("Password length must be minimum 6 characters");

            bool notContain = true;
            foreach (var @char in "!@#$%^&*()-+=_")
            {
                if (password.Contains(@char.ToString()))
                {
                    notContain = false;
                    break;
                }
            }

            if (notContain)
                throw new PasswordFormatException("Password must be contain minimum one special character");
        }
    }

}
