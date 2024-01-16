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


        /*
         * προδιαγραφες κωδικου(password)
         * [1] Τουλάχιστον 12 χαρακτήρες
         * [2] Tο πολυ 24 χαρακτηρες
         * [3] Συνδυασμός χαρακτηριών
         * [3.1] τουλαχιστον 1 κεφαλαιο 
         * [3.2] τουλαχιστον ενα πεζο
         * [3.3] τουλαχισοτν 1 νουμερο
         * [3.4] τουλαχιαοτν 1 ειδικο συμβολο
         * [4] χαρακτηρες διαφυγης 
         * [5] Τα γράμματα να είναι λατινικοί χαρακτήρες
         * [6] Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό
         * 
         * 
         */
        public bool ValidPassword(string Password) /* THEO */

        {
            char[] passwordArray = Password.ToCharArray();
            // [1] Έλεγχος για μήκος τουλάχιστον 12 χαρακτήρες
            if (Password.Length < 12)
            {
                return false;
            }
            // [2] Tο πολυ 24 χαρακτηρες
            if (Password.Length > 24)
            {
                return false;
            }
            //[3.1] Έλεγχος για κεφαλαία γράμματα
            if (!Password.Any(char.IsUpper))
            {
                return false;
            }
            //[3.2] Έλεγχος για πεζά γράμματα
            if (!Password.Any(char.IsLower))
            {
                return false;
            }
            // [3.3] Έλεγχος για αριθμούς
            if (!Password.Any(char.IsDigit))
            {
                return false;
            }

            // [3.4] τουλαχιαοτν 1 ειδικο συμβολo
            if (!Password.Any(symbol => "!@#$%^&*()_+-=[]{}|;:'\",.<>/?".Contains(symbol)))
            {
                return false;
            }
            // [4] Έλεγχος για χαρακτηρες διαφυγης
            if (Password.Any(char.IsWhiteSpace))
            {
                return false;
            }


            // [5] Τα γράμματα πρέπει να είναι όλα λατινικά
            bool isLatinLetter = true;
            for (int i = 0; i < passwordArray.Length; i++)
            {
                if (char.IsLetter(passwordArray[i]))
                {
                    isLatinLetter = (passwordArray[i] >= 'A' && passwordArray[i] <= 'Z') || (passwordArray[i] >= 'a' && passwordArray[i] <= 'z');
                    if (!isLatinLetter)
                        return false;
                }
            }



            //[6] Έλεγχος ότι ξεκινάει από κεφαλαίο και τελειώνει με αριθμό
            if (!(char.IsUpper(Password[0]) && char.IsDigit(Password[Password.Length - 1])))
            {
                return false;
            }

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
         *      [3.1] Να ανήκει σε ζώνη
         *  [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό
         *      [4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας
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
                // [2] Οι αριθμοί να είναι ακριβώς 10
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
                        // [3.1] Να ανήκει σε ζώνη
                        TypePhone = 0;
                        switch (Int32.Parse(Phone.Substring(1, 1)))                                  
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
                                TypePhone = -1;
                                InfoPhone = null;
                                break;
                        }
                    }
                    else
                    {
                        // [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό
                        if (Phone.StartsWith("69"))
                        {
                            // [4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας
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
                                    TypePhone = -1;
                                    InfoPhone = null;
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

        /*  Προδιαγραφές Birthdate:
         *  
         *  new DateTime(ΧΧΧΧ, ΜΜ, ΗΗ) <=> new DateTime(2004, 04, 23) 
         *  [1] Η ημερομηνία πρέπει να είναι έγκυρη
         *    [1.1] Η ημερομηνία πρέπει να περιλαμβάνει τον χαρακτήρα '-' ακριβώς 3 φορές
         *    [1.2] Η ημερομηνία πρέπει να περιλαμβάνει μόνο ψηφία
         *    [1.3] Το μορφότυπο της ημερομηνίας πρέπει να είναι "ΧΧΧΧ-ΜΜ-ΗΗ"
         *    [1.4] Η ημερομηνία γέννησης θα πρέπει να είναι έγκυρη ως προς την αντιστοιχία ημερών και μήνα
         *           [1.4.1] Με εισαγωγή 04 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 30, καθώς ο μήνας Απρίλιος διαρκεί 30 μέρες
         *           [1.4.2] Με εισαγωγή 2003 στο πεδίο "ΧΧΧΧ" και 02 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 28, 
         *                   καθώς ο Φεβρουάριος διαρκεί 28 μέρες στα μη-δίσεκτα έτη
         *  [2] Η ημερομηνία γέννησης πρέπει να είναι από 1958-01-01 εώς 2006-12-31  
         *  
         *  Προδιαγραφές HiringDate:
         *  
         *  new DateTime(ΧΧΧΧ, ΜΜ, ΗΗ) <=> new DateTime(2004, 04, 23)
         *  [1] Η ημερομηνία πρέπει να είναι έγκυρη
         *    [1.1] Η ημερομηνία πρέπει να περιλαμβάνει τον χαρακτήρα '-' ακριβώς 3 φορές
         *    [1.2] Η ημερομηνία πρέπει να περιλαμβάνει μόνο ψηφία
         *    [1.3] Το μορφότυπο της ημερομηνίας πρέπει να είναι "ΧΧΧΧ-ΜΜ-ΗΗ"
         *    [1.4] Η ημερομηνία γέννησης θα πρέπει να είναι έγκυρη ως προς την αντιστοιχία ημερών και μήνα
         *           [1.4.1] Με εισαγωγή 04 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 30, καθώς ο μήνας Απρίλιος διαρκεί 30 μέρες
         *           [1.4.2] Με εισαγωγή 2003 στο πεδίο "ΧΧΧΧ" και 02 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 28, 
         *                   καθώς ο Φεβρουάριος διαρκεί 28 μέρες στα μη-δίσεκτα έτη
         *    [2] Η ημερομηνία πρόσληψης πρέπει να είναι η ημερομηνία γέννησης // EmpIx.Birthdate = 2004-03-19 // 2022-03-19 (EmpIx.Birthdate.Year + 18) ... 2024-01-16 (DateTime.Now)
         *  
         * 
         */
        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) /* THEO */
        {  
            int birthDay = EmplX.Birthday.Day;
            int birthMonth = EmplX.Birthday.Month;
            int birthYear = EmplX.Birthday.Year;
            int hiringDay = EmplX.HiringDate.Day;
            int hiringMonth = EmplX.HiringDate.Month;
            int hiringYear = EmplX.HiringDate.Year;
            int currentDay = DateTime.Today.Day;
            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;
            DateTime firstBirthDate = new DateTime(1958, 01, 01); // Η 1η έγκυρη ημερομηνία γέννησης
            DateTime lastBirthDate = new DateTime(2006, 12, 31); // Η τελευταία έγκυρη ημερομηνία γέννησης
            DateTime firstHiringDate = EmplX.Birthday.AddYears(18); // new DateTime(EmplX.Birthday.Year + 18, EmplX.Birthday.Month, EmplX.Birthday.Day); // Η 1η έγκυρη ημερομήνια πρόσληψης
            DateTime lastHiringDate = DateTime.Today; //new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); // Η τελευταία ημερομηνία πρόσληψης

            if (firstBirthDate >= EmplX.Birthday && EmplX.Birthday <= lastBirthDate) // firstDate <= EmpIx.Birthdate <= lastDate
            {          
                int ageYear = currentYear - birthYear;
                int ageMonth = currentMonth - birthMonth;
                int ageDay = currentDay - birthDay;
                if (ageMonth < 0 || ageDay < 0) // 2004-01-30 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-30 = -14 (Ο φίλος είναι 20-1=19 χρονών παρά 14!! ημερών)
                    Age = ageYear - 1;  
                else                            // 2004-01-02 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-02 = 14 (Ο φίλος είναι 20 χρονών και 14!! ημερών)
                    Age = ageYear;
            } 
            else
            {
                Age = -1;
            }

            if (firstHiringDate >= EmplX.HiringDate && EmplX.HiringDate <= lastHiringDate) // firstHiringDate <= EmpIx.HiringDate <= lastHiringDate
            {
                int xpYear = currentYear - hiringYear;
                int xpMonth = currentMonth - hiringMonth;
                int xpDay = currentDay - hiringDay;
                if (xpMonth < 0 || xpDay < 0) // 2004-01-30 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-30 = -14 (Ο φίλος έχει 20-1=19 χρόνια παρά 14!! ημέρες υπηρεσία)
                    YearsOfExperience = xpYear - 1;
                else                            // 2004-01-02 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-02 = 14 (Ο φίλος έχει 20 χρόνια και 14 ημέρες υπηρεσίας)
                    YearsOfExperience = xpYear;
            }
            else
            {
                YearsOfExperience = -1;
            }
        }

        public int LiveinAthens(Employee[] Empls) /* OMAR */
        {
            return 0;
        }
    }
}
