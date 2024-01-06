using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class Personnel
    {
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string Name, string HomePhone, string MobilePhone, DateTime Birthday, DateTime HiringDate)
            {
                this.Name = Name;
                this.HomePhone = HomePhone;
                this.MobilePhone = MobilePhone;
                this.Birthday = Birthday;
                this.HiringDate = HiringDate;
            }
        }

        /* 
         *  Προδιαγραφές ονοματεπώνυμου (Name):
         *  
         *  [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά
         *  [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες προδιαγραφές και για τα δύο
         *      [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3
         *      [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15
         *      [2.3] Πρέπει να περιέχει μόνο γράμματα
         *      [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο
         *      [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά
         *      [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά
         */
        public bool ValidName(string Name) /* TIGER */
        {
            // [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά
            string[] subNames = Name.Split(' ');
            if (subNames.Length != 2)
                return false;

            // [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες προδιαγραφές και για τα δύο
            string firstName = subNames[0];
            string lastName = subNames[1];

            // [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3
            if (firstName.Length < 3)
                return false;
            if (lastName.Length < 3)
                return false;

            // [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15
            if (firstName.Length > 15)
                return false;
            if (lastName.Length > 15)
                return false;

            // [2.3] Πρέπει να περιέχει μόνο γράμματα
            if (!firstName.All(char.IsLetter))
                return false;
            if (!lastName.All(char.IsLetter))
                return false;

            // [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο
            char[] firstNameArray = firstName.ToCharArray();
            char[] lastNameArray = lastName.ToCharArray();
            if (!char.IsUpper(firstNameArray[0]))
                return false;
            if (!char.IsUpper(lastNameArray[0]))
                return false;

            // [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά
            if (!firstName.Substring(1).All(char.IsLower))
                return false;
            if (!lastName.Substring(1).All(char.IsLower))
                return false;

            // [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά
            bool isLatinLetter = true;
            for (int i = 0; i < firstNameArray.Length; i++)
            {
                isLatinLetter = (firstNameArray[i] >= 'A' && firstNameArray[i] <= 'Z') || (firstNameArray[i] >= 'a' && firstNameArray[i] <= 'z');
                if (!isLatinLetter)
                    return false;
            }
            for (int j = 0; j < lastNameArray.Length; j++)
            {
                isLatinLetter = (lastNameArray[j] >= 'A' && lastNameArray[j] <= 'Z') || (lastNameArray[j] >= 'a' && lastNameArray[j] <= 'z');
                if (!isLatinLetter)
                    return false;
            }

            // Έγκυρο ονοματεπώνυμο
            return true;                              
        } 

        public bool ValidPassword(string Password) /* THEO */
        {
            return true;
        }

        public void EncryptPassword(string Password, ref string EncryptedPW) /* OMAR */
        {
            
        }

        /* 
         *  Προδιαγραφές τηλεφώνου (Phone):
         *  
         *  [1] Να περιέχει μόνο αριθμούς
         *  [2] Οι αριθμοί να είναι ακριβώς 10
         *  [3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό
         *  [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό
         */
        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone) /* TIGER */
        {
            // [1] Να περιέχει μόνο αριθμούς
            if (!Phone.All(char.IsDigit))
            {
                TypePhone = -1;
                InfoPhone = null;
            }
            else
            {
                // [2] Οι αριθμοί να είναι τουλάχιστον 10
                if (Phone.Length != 10)
                {
                    TypePhone = -1;
                    InfoPhone = null;
                }
                else
                {
                    // [3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό
                    if (Phone.StartsWith("2"))
                    {
                        TypePhone = 0;
                        switch (Int32.Parse(Phone.Substring(1, 1))) // Έλεγχος της ζώνης που ανήκει το σταθερό τηλέφωνο                                 
                        {
                            case 1:
                                InfoPhone = "Metropolitan Area of Athens - Piraeus";
                                break;
                            case 2:
                                InfoPhone = "Eastern Central Greece, Attica, Aegean Islands";
                                break;
                            case 3:
                                InfoPhone = "Central Macedonia";
                                break;
                            case 4:
                                InfoPhone = "Thessaly, Western Macedonia";
                                break;
                            case 5:
                                InfoPhone = "Thrace, Eastern Macedonia";
                                break;
                            case 6:
                                InfoPhone = "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands";
                                break;
                            case 7:
                                InfoPhone = "Eastern Peloponnese, Kythera";
                                break;
                            case 8:
                                InfoPhone = "Crete";
                                break;
                            default:
                                InfoPhone = "";
                                break;
                        }
                    }
                    else
                    {
                        // [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό
                        if (Phone.StartsWith("69"))
                        {
                            TypePhone = 1;
                            switch (Int32.Parse(Phone.Substring(2, 1))) // Έλεγχος της εταιρίας κινητής τηλεφωνίας που ανήκει το κινητό τηλέφωνο
                            {
                                case 0:
                                case 3:
                                case 9:
                                    InfoPhone = "Nova";
                                    break;
                                case 4:
                                case 5:
                                    InfoPhone = "Vodafone";
                                    break;
                                case 7:
                                case 8:
                                    InfoPhone = "Cosmote";
                                    break;
                                default:
                                    InfoPhone = "";
                                    break;
                            }
                        }
                        else
                        {
                            TypePhone = -1;
                            InfoPhone = null; 
                        }
                    }
                }
            }
        }

        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) /* THEO */
        {
            
        }

        public int LiveinAthens(Employee[] Empls) /* OMAR */
        {
            return 0;
        }
    }
}