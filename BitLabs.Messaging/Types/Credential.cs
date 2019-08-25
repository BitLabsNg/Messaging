using System;
using System.Collections.Generic;
using System.Text;

namespace BitLabs.Messaging.Types
{
    public class Credential
    {
        public string CredentialHash { get; private set; }
        public string Username { get; private set; }
        public Credential(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), $"{nameof(username)} is required");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), $"{nameof(password)} is required");

            CredentialHash = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        }
    }
}
