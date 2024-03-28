using System;
using System.Linq;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (IsNameEmptyOrNull(firstName)|| IsNameEmptyOrNull(lastName))
            {
                return false;
            }

            if (IsEmailUncorrect(email))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (CorrectYourAge(now,dateOfBirth)) age--;

            if (IsPersonAnAdult(dateOfBirth))
            {
                return false;
            }


            var client = GetClientFromDatabase(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            SetImportanceOfClients(user,client);
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool IsNameEmptyOrNull(String name)
        {
            return string.IsNullOrEmpty(name);
        }

        private bool IsEmailUncorrect(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }

        private bool IsPersonAnAdult(DateTime dateTime)
        {
            return dateTime.Year - DateTime.Today.Year < 21;
        }

        private bool CorrectYourAge(DateTime now, DateTime dateOfBirth)
        {
            return now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day);
        }

        private void SetImportanceOfClients(User user, Client client)
        {
            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient": 
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                    }
                    break;
                default:
                    user.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        user.CreditLimit = creditLimit;
                    }
                    break;
            }
        }

        private Client GetClientFromDatabase(int clientId)
        {
            var clientRepository = new ClientRepository();
            return clientRepository.GetById(clientId);
        }
    }
}
