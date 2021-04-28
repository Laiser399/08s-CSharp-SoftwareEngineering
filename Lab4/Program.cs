using Lab4.Builders;
using Lab4.Validators;
using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Human[] humans = new Human[]
            {
                new Human(21, "Vasya", DriverLicense.A | DriverLicense.C),
                new Human(21, "Vasya", DriverLicense.A | DriverLicense.B | DriverLicense.C),
                new Human(20, "Vasya", DriverLicense.A | DriverLicense.C),
                new Human(21, "Masha", DriverLicense.A | DriverLicense.C),
                new Human(21, "Vasya", DriverLicense.A | DriverLicense.B),
                new Human(21, "Vasya", DriverLicense.A)
            };

            IValidator<Human> validator = GetTestValidator();

            for (int i = 0; i < humans.Length; i++)
            {
                try
                {
                    validator.Validate(humans[i]);
                    Console.WriteLine($"i = {i}, Ok");
                }
                catch (ValidateException e)
                {
                    Console.WriteLine($"i = {i}, Bad, Message: {e.Message}");
                }
            }
        }

        private static IValidator<Human> GetTestValidator()
        {
            HumanValidatorBuilder builder = new HumanValidatorBuilder();
            builder.SetMinAge(21);
            builder.SetName("Vasya");
            builder.SetDriverLicense(DriverLicense.A | DriverLicense.C);
            return builder.Result;
        }
    }
}
