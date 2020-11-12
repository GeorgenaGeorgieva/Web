namespace FriendsAdventure.Services.Implementations.Validations
{
    using System;

    internal static class Validator
    {
        internal static void NameValidate(string name)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.");
            }

            if (name.Length > 30)
            {
                throw new ArgumentException("Name cannot be more than 30 symbols.");
            }
        }

        internal static void DescriptionValidate(string description)
        {
            if (description.Length > 200)
            {
                throw new ArgumentException("Description cannot be more than 200 symbols.");
            }
        }
    }
}
