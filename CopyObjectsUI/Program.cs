using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyObjectsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel firstPerson = new PersonModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                DateOfBirth = new DateTime(1998, 7, 19),
                Addresses = new List<AddressModel>
                {
                    new AddressModel
                    {
                        StreetAddress = "101 State Street",
                        City = "Salt Lake City",
                        State = "UT",
                        ZipCode = "76321"
                    },
                    new AddressModel
                    {
                        StreetAddress = "842 Lawrence Way",
                        City = "Jupiter",
                        State = "FL",
                        ZipCode = "22558"
                    }
                }
            };
            // Remember, object variables are just addresses-they're just pointing to a location. So if you just said secondPerson = firstPerson, you're setting the addresses equal to each other, such that if you change secondPerson.FirstName, you're also changing the value of firstPerson.FirstName

            // Creates a second PersonModel object
            /*            PersonModel secondPerson = null;
            */
            // Set the value of the secondPerson to be a copy of the firstPerson
            // We do this by converting the first person to JSON 

            /*            string temporaryPerson = JsonConvert.SerializeObject(firstPerson); 
            */            // and then deserializing it back into the object, just like we were doing this with APIs.
                          // But if firstPerson had private variables, those would not be copied over to seconPerson.
            /* secondPerson = JsonConvert.DeserializeObject<PersonModel>(temporaryPerson);
 */
            // Update the secondPerson's FirstName to "Bob" 
            /*            secondPerson.FirstName = "Bob";
            */            // and change the Street Address for each of Bob's addresses
                          // to a different value
            /*  secondPerson.Addresses[0].StreetAddress = "2601 W. 64th St.";
              secondPerson.Addresses[1].StreetAddress = "900 E. Main St.";*/




            PersonModel secondPerson = (PersonModel)firstPerson.Clone();



            // Ensure that the following statements are true
            Console.WriteLine($"{ firstPerson.FirstName } != { secondPerson.FirstName }");
            Console.WriteLine($"{ firstPerson.LastName } == { secondPerson.LastName }");
            Console.WriteLine($"{ firstPerson.DateOfBirth.ToShortDateString() } == { secondPerson.DateOfBirth.ToShortDateString() }");
            Console.WriteLine($"{ firstPerson.Addresses[0].StreetAddress } != { secondPerson.Addresses[0].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[0].City } == { secondPerson.Addresses[0].City }");
            Console.WriteLine($"{ firstPerson.Addresses[1].StreetAddress } != { secondPerson.Addresses[1].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[1].City } == { secondPerson.Addresses[1].City }");

            Console.ReadLine(); 
        }
    }

    public class PersonModel : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        public object Clone()
        {
            PersonModel clone = new PersonModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Addresses = this.Addresses.Select(a => new AddressModel
                {
                    StreetAddress = a.StreetAddress,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode
                }).ToList()
            };

            return clone;
        }
    }

    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
