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


        /*  Παραδοχές υλοποίησης:
         *    
         *  [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά
         *  [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες παραδοχές υλοποίησης και για τα δύο
         *      [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3
         *      [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15
         *      [2.3] Πρέπει να περιέχει μόνο γράμματα
         *      [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο
         *      [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά
         *      [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά
         */
        public bool ValidName(string Name) 
        {
            // ----- [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά -----
            string[] subNames = Name.Split(' ');
            if (subNames.Length != 2)
                return false;

            /**** [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες παραδοχές υλοποίησης και για τα δύο ****/
            string firstName = subNames[0];
            string lastName = subNames[1];

            // ----- [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3 -----
            if (firstName.Length < 3)
                return false;
            if (lastName.Length < 3)
                return false;

            // ----- [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15 -----
            if (firstName.Length > 15)
                return false;
            if (lastName.Length > 15)
                return false;

            // ----- [2.3] Πρέπει να περιέχει μόνο γράμματα -----
            if (!firstName.All(char.IsLetter))
                return false;
            if (!lastName.All(char.IsLetter))
                return false;

            // ----- [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο -----
            char[] firstNameArray = firstName.ToCharArray();
            char[] lastNameArray = lastName.ToCharArray();
            if (!char.IsUpper(firstNameArray[0]))
                return false;
            if (!char.IsUpper(lastNameArray[0]))
                return false;

            // ----- [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά -----
            if (!firstName.Substring(1).All(char.IsLower))
                return false;
            if (!lastName.Substring(1).All(char.IsLower))
                return false;

            // ----- [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά -----
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

            // ----- Έγκυρο ονοματεπώνυμο -----
            return true;                              
        }



        /*  Παραδοχές υλοποίησης:
         *  
         *  [1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12
         *  [2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24
         *  [3] Συνδυασμός χαρακτήρων
         *      [3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα 
         *      [3.2] Να περιέχει τουλάχιστον ένα πεζό γράμμα
         *      [3.3] Να περιέχει τουλάχιστον 1 ψηφίο
         *      [3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο
         *  [4] Να μην περιέχει χαρακτήρες διαφυγής 
         *  [5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες
         *  [6] Πρέπει να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με ψηφίο
         *      [6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα
         *      [6.2] Πρέπει να τελειώνει με ψηφίο
         * 
         */
        public bool ValidPassword(string Password) 
        {
            // ----- [1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12 -----
            if (Password.Length < 12)
                return false;
            
            // ----- [2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24 -----
            if (Password.Length > 24)
                return false;

            /**** [3] Συνδυασμός χαρακτηρών ****/
            // ----- [3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα -----
            if (!Password.Any(char.IsUpper))
                return false;
            
            // ----- [3.2] Να περιέχει τουλάχιστον ένα πεζό γράμμα -----
            if (!Password.Any(char.IsLower))
                return false;
            
            // ----- [3.3] Να περιέχει τουλάχιστον 1 ψηφίο -----
            if (!Password.Any(char.IsDigit))
                return false;

            // ----- [3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο -----
            if (!Password.Any(symbol => "!@#$%^&*()_+-=[]{}|;:'\",.<>/?".Contains(symbol)))
                return false;
            
            // ----- [4] Να μην περιέχει χαρακτήρες διαφυγής -----
            if (Password.Any(char.IsWhiteSpace))
                return false;

            // ----- [5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες -----
            char[] passwordArray = Password.ToCharArray();
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

            /**** [6] Πρέπει να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με ψηφίο ****/
            // ----- [6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα -----
            if (!char.IsUpper(Password[0]))
                return false;
            
            // ----- [6.2] Πρέπει να τελειώνει με ψηφίο -----
            if (!char.IsDigit(Password[Password.Length - 1]))
                return false;
            
            // ----- Έγκυρος κωδικός πρόσβασης -----
            return true;
        }



       /*  Παραδοχές υλοποίησης:
        *  
        *  [1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword
        *  
        */
        public void EncryptPassword(string Password, ref string EncryptedPW) 
        {
            bool isValidPassword = this.ValidPassword(Password);

            // ----- [1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές της ValidPassword -----
            if (isValidPassword)
            {
                // ----- Έγκυρος κωδικός πρόσβασης -----
                int alphabetSize = 128;
                int shift = 5;

                foreach (char character in Password)
                {
                    char encryptedChar = (char)((character + shift) % alphabetSize);
                    EncryptedPW += encryptedChar;
                }
            }
            else
            {
                // ----- Άκυρος κωδικός πρόσβασης -----
                EncryptedPW = "";
            }
        }

       /*  
        *  Παραδοχές υλοποίησης:
        *  
        *  [1] Να περιέχει μόνο αριθμούς
        *  [2] Οι αριθμοί να είναι ακριβώς 10
        *  [3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό
        *      [3.1] Να ανήκει σε ζώνη
        *  [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό
        *      [4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας
        */
        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone) 
        {
            // ----- [1] Να περιέχει μόνο αριθμούς -----
            if (!Phone.All(char.IsDigit))
            {
                // ----- Άκυρο τηλέφωνο -----
                TypePhone = -1;
                InfoPhone = null;
            }
            else
            {
                // ----- [2] Οι αριθμοί να είναι ακριβώς 10 -----
                if (Phone.Length != 10)
                {
                    // ----- Άκυρο τηλέφωνο -----
                    TypePhone = -1;
                    InfoPhone = null;
                }
                else
                {
                    /**** [3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό ****/
                    if (Phone.StartsWith("2"))
                    {
                        // ----- [3.1] Να ανήκει σε ζώνη -----
                        switch (Phone[1])                                  
                        {
                            case '1':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Μητροπολιτική Περιοχή Αθήνας – Πειραιά -----
                                TypePhone = 0;
                                InfoPhone = "Metropolitan Area of Athens - Piraeus";
                                break;
                            case '2':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου -----
                                TypePhone = 0;
                                InfoPhone = "Eastern Central Greece, Attica, Aegean Islands";
                                break;
                            case '3':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Κεντρική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Central Macedonia";
                                break;
                            case '4':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Θεσσαλία, Δυτική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Thessaly, Western Macedonia";
                                break;
                            case '5':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Θράκη, Ανατολική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Thrace, Eastern Macedonia";
                                break;
                            case '6':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησο, Ιόνια Νησιά -----
                                TypePhone = 0;
                                InfoPhone = "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands";
                                break;
                            case '7':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα -----
                                TypePhone = 0;
                                InfoPhone = "Eastern Peloponnese, Kythera";
                                break;
                            case '8':
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Κρήτη -----
                                TypePhone = 0;
                                InfoPhone = "Crete";
                                break;
                            default:
                                // ----- Άκυρο τηλέφωνο -----
                                TypePhone = -1;
                                InfoPhone = null;
                                break;
                        }
                    }
                    else
                    {
                        /**** [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό ****/
                        if (Phone.StartsWith("69"))
                        {
                            // ----- [4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας -----
                            switch (Phone[2])
                            {
                                case '0':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                case '3':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                case '9':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                    TypePhone = 1;
                                    InfoPhone = "Nova";
                                    break;
                                case '4':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone -----
                                case '5':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone -----
                                    TypePhone = 1;
                                    InfoPhone = "Vodafone";
                                    break;
                                case '7':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote -----
                                case '8':
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote -----
                                    TypePhone = 1;
                                    InfoPhone = "Cosmote";
                                    break;
                                default:
                                    // ----- Άκυρο τηλέφωνο -----
                                    TypePhone = -1;
                                    InfoPhone = null;
                                    break;
                            }
                        }
                        else
                        {
                            // ----- Άκυρο τηλέφωνο -----
                            TypePhone = -1;
                            InfoPhone = null; 
                        }
                    }
                }
            }
        }


        /*  
         *  Παραδοχές υλοποίησης:
         *    
         *   [1] Η ημερομηνία πρέπει να είναι έγκυρη
         *       [1.1] Η ημερομηνία πρέπει να περιλαμβάνει τον χαρακτήρα '-' ακριβώς 3 φορές
         *       [1.2] Η ημερομηνία πρέπει να περιλαμβάνει μόνο ψηφία
         *       [1.3] Το μορφότυπο της ημερομηνίας πρέπει να είναι "ΧΧΧΧ-ΜΜ-ΗΗ"
         *       [1.4] Η ημερομηνία γέννησης θα πρέπει να είναι έγκυρη ως προς την αντιστοιχία ημερών και μήνα
         *       [1.4.1] Με εισαγωγή 04 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 30, καθώς ο μήνας Απρίλιος διαρκεί 30 μέρες
         *       [1.4.2] Με εισαγωγή 2003 στο πεδίο "ΧΧΧΧ" και 02 στο πεδίο "ΜΜ", οι έγκυρες εισαγωγές στο πεδίο "ΗΗ" είναι από 1 εώς 28, 
         *               καθώς ο Φεβρουάριος διαρκεί 28 μέρες στα μη-δίσεκτα έτη
         *   [2] Η ημερομηνία γέννησης πρέπει να είναι από 1958-01-01 εώς 2006-12-31
         *   [3] Η ημερομηνία πρόσληψης πρέπει να είναι από την ημερομηνία γέννησης μεταγενέστερα κατά 18 χρόνια εώς την τρέχουσα ημερομηνία 
         * 
         */
        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) 
        {
            int ageYear, ageMonth, ageDay;
            int xpYear, xpMonth, xpDay;
            
            DateTime firstBirthDate = new DateTime(1958, 01, 01);   // Η 1η έγκυρη ημερομηνία γέννησης
            DateTime lastBirthDate = new DateTime(2006, 12, 31);    // Η τελευταία έγκυρη ημερομηνία γέννησης
            DateTime firstHiringDate = EmplX.Birthday.AddYears(18); // Η 1η έγκυρη ημερομήνια πρόσληψης  // new DateTime(EmplX.Birthday.Year + 18, EmplX.Birthday.Month, EmplX.Birthday.Day); 
            DateTime lastHiringDate = DateTime.Today;               // Η τελευταία ημερομηνία πρόσληψης  //new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            if (EmplX.Birthday >= firstBirthDate && EmplX.Birthday <= lastBirthDate) 
            {
                ageYear = DateTime.Today.Year - EmplX.Birthday.Year;
                ageMonth = DateTime.Today.Month - EmplX.Birthday.Month;
                ageDay = DateTime.Today.Day - EmplX.Birthday.Day;
                if (ageMonth < 0 || ageDay < 0)     // 2004-01-30 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-30 = -14 (Ο φίλος είναι 20-1=19 χρονών παρά 14!! ημερών)
                    Age = ageYear - 1;
                else                                // 2004-01-02 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-02 = 14 (Ο φίλος είναι 20 χρονών και 14!! ημερών)
                    Age = ageYear;
            }
            else
            {
                Age = -1;
            }

            if (EmplX.HiringDate >= firstHiringDate && EmplX.HiringDate <= lastHiringDate) 
            {
                xpYear = DateTime.Today.Year - EmplX.HiringDate.Year;
                xpMonth = DateTime.Today.Month - EmplX.HiringDate.Month;
                xpDay = DateTime.Today.Day - EmplX.HiringDate.Day;
                if (xpMonth < 0 || xpDay < 0)           // 2004-01-30 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-30 = -14 (Ο φίλος έχει 20-1=19 χρόνια παρά 14!! ημέρες υπηρεσία)
                    YearsOfExperience = xpYear - 1;
                else                                    // 2004-01-02 ... 2024-01-16 ==> 2024-2004 = 20... 01-01 = 0 ... 16-02 = 14 (Ο φίλος έχει 20 χρόνια και 14 ημέρες υπηρεσίας)
                    YearsOfExperience = xpYear;
            }
            else
            {
                YearsOfExperience = -1;
            }
        }



        /*   Παραδοχές υλοποίησης:
         *  
         *   [1] Το όνομα πρέπει να είναι έγκυρο σύμφωνα με τις παραδοχές υλοποίησης της ValidName()
         *   [2] Η ημερομηνία γέννησης πρέπει να είναι έγκυρη σύμφωνα με τις παραδοχές υλοποίησης της InfoEmployee()
         *   [3] Η ημερομηνία πρόσληψης πρέπει να είναι έγκυρη σύμφωνα με τις παραδοχές υλοποίησης της InfoEmployee()
         *   [4] Το σταθερό τηλέφωνο πρέπει να είναι έγκυρο ως προς τον τύπο τηλεφώνου (TypePhone) σύμφωνα με τις παραδοχές υλοποίησης της CheckPhone()
         *   [5] Το σταθερό τηλέφωνο πρέπει να είναι έγκυρο ως προς τις πληροφορίες τηλεφώνου (InfoPhone) σύμφωνα με τις παραδοχές υλοποίησης της CheckPhone()
         */
        public int LiveinAthens(Employee[] Empls) 
        {
            int countAthens = 0;
           
            foreach (var emp in Empls)
            {
                int Age = 0;
                int YearsOfExperience = 0;
                int TypePhone = 0;
                string InfoPhone = "";

                bool isValidName = this.ValidName(emp.Name);
                this.InfoEmployee(emp, ref Age, ref YearsOfExperience);
                this.CheckPhone(emp.HomePhone, ref TypePhone, ref InfoPhone);
                // ----- [1] Το όνομα πρέπει να είναι έγκυρο σύμφωνα με τις παραδοχές υλοποίησης της ValidName() -----
                // ----- [2] Η ημερομηνία γέννησης πρέπει να είναι έγκυρη σύμφωνα με τις παραδοχές υλοποίησης της InfoEmployee() -----
                // ----- [3] Η ημερομηνία πρόσληψης πρέπει να είναι έγκυρη σύμφωνα με τις παραδοχές υλοποίησης της InfoEmployee() -----
                // ----- [4] Το σταθερό τηλέφωνο πρέπει να είναι έγκυρο ως προς τον τύπο τηλεφώνου (TypePhone) σύμφωνα με τις παραδοχές υλοποίησης της CheckPhone() -----
                // ----- [5] Το σταθερό τηλέφωνο πρέπει να είναι έγκυρο ως προς τις πληροφορίες τηλεφώνου (InfoPhone) σύμφωνα με τις παραδοχές υλοποίησης της CheckPhone() -----
                if (isValidName && Age != -1 && YearsOfExperience != -1 && TypePhone == 0 && InfoPhone != null)
                {
                    // ----- Έγκυρο όνομα, ημερομηνία γέννησης, ημερομηνία πρόσληψης, τύπος τηλεφώνου, πληροφορίες τηλεφώνου -----
                    if (InfoPhone.Equals("Metropolitan Area of Athens - Piraeus"))
                        // ----- Υπάλληλος που κατοικεί στην Αθήνα ----- 
                        countAthens++;
                }
                else
                {
                    // ----- Άκυρο όνομα ή ημερομηνία γέννησης ή ημερομηνία πρόσληψης ή τύπος τηλεφώνου ή πληροφορίες τηλεφώνου -----
                    return -1;
                }
            }

            return countAthens;
        }
    }
}
