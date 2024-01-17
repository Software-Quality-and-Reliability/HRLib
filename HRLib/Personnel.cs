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

        /*  bool ValidName(string Name)
         * 
         *  Είσοδος[1] --> [Name]        Ένα ονοματεπώνυμο σε μορφή κειμένου (string)
         *  Λειτουργία -->               Ελέγχει αν αντιστοιχεί το ονοματεπώνυμο σε κάποιον υπάλληλο σύμφωνα με τις Παραδοχές υλοποίησης
         *  Έξοδος[1]  --> [true/false]  Boolean μεταβλητή που δηλώνει αν το ονοματεπώνυμο αντιστοιχεί σε κάποιον υπάλληλο
         * 
         *  Παραδοχές υλοποίησης:
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
        public bool ValidName(string Name) 
        {
            // ----- [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά -----
            string[] subNames = Name.Split(' ');
            if (subNames.Length != 2)
                return false;

            /**** [2] Ξεχωρίζουμε το όνομα από το επώνυμο με βάση τον χαρακτήρα κενό ' ', όπου ισχύουν οι ίδιες προδιαγραφές και για τα δύο ****/
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


        /*  bool ValidPassword(string Password)
         * 
         *  Είσοδος[1] --> [Password]    Ένας κωδικός πρόσβασης σε μορφή κειμένου
         *  Λειτουργία -->               Ελέγχει αν ο κωδικός πρόσβασης είναι αποδεκτός σύμφωνα με τις Παραδοχές υλοποίησης 
         *  Έξοδος[1]  --> [true/false]  Boolean μεταβλητή που δηλώνει αν ο κωδικός πρόσβασης είναι αποδεκτός 
         *  
         *  Παραδοχές υλοποίησης:
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

            // ----- [6] Πρέπει να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με ψηφίο -----
            if (!(char.IsUpper(Password[0]) && char.IsDigit(Password[Password.Length - 1])))
                return false;

            // ----- Έγκυρος κωδικός πρόσβασης -----
            return true;
        }

        /*  void EncryptPassword(string Password, ref string EncryptedPW)
         *  
         *  Είσοδος[1] --> [Password]    
         *  Λειτουργία -->                 
         *  Έξοδος[1]  --> [EncryptedPW]   
         *  
         *  Παραδοχές υλοποίησης:
         *  
         */
        public void EncryptPassword(string Password, ref string EncryptedPW) 
        {

        }

        /*  void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
         *  
         *  Είσοδος[1] --> [Phone]      Ένα τηλέφωνο σε μορφή κειμένου    
         *  Λειτουργία -->              Ελέγχει αν αντιστοιχεί σε τηλέφωνο σύμφωνα με τις Παραδοχές υλοποίησης   
         *  Έξοδος[1]  --> [TypePhone]  Χαρακτηριστικός αριθμός που δηλώνει την εγκυρότητα του τηλεφώνου (0 για έγκυρο σταθερό τηλέφωνο, 1 για έγκυρο κινητό τηλέφωνο, -1 για άκυρο τηλέφωνο)
         *  Έξοδος[2]  --> [InfoPhone]  Πληροφορίες τηλεφώνου (ζώνη για έγκυρο σταθερό τηλέφωνο, εταιρία κινητής τηλεφωνίας για έγκυρο κινητό τηλέφωνο, null για άκυρο τηλέφωνο)
         *  
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
                        switch (Int32.Parse(Phone.Substring(1, 1)))                                  
                        {
                            case 1:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Μητροπολιτική Περιοχή Αθήνας – Πειραιά -----
                                TypePhone = 0;
                                InfoPhone = "Metropolitan Area of Athens - Piraeus";
                                break;
                            case 2:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου -----
                                TypePhone = 0;
                                InfoPhone = "Eastern Central Greece, Attica, Aegean Islands";
                                break;
                            case 3:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Κεντρική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Central Macedonia";
                                break;
                            case 4:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Θεσσαλία, Δυτική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Thessaly, Western Macedonia";
                                break;
                            case 5:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Θράκη, Ανατολική Μακεδονία -----
                                TypePhone = 0;
                                InfoPhone = "Thrace, Eastern Macedonia";
                                break;
                            case 6:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησο, Ιόνια Νησιά -----
                                TypePhone = 0;
                                InfoPhone = "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands";
                                break;
                            case 7:
                                // ----- Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα -----
                                TypePhone = 0;
                                InfoPhone = "Eastern Peloponnese, Kythera";
                                break;
                            case 8:
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
                            switch (Int32.Parse(Phone.Substring(2, 1)))
                            {
                                case 0:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                case 3:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                case 9:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova -----
                                    TypePhone = 1;
                                    InfoPhone = "Nova";
                                    break;
                                case 4:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone -----
                                case 5:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone -----
                                    TypePhone = 1;
                                    InfoPhone = "Vodafone";
                                    break;
                                case 7:
                                    // ----- Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote -----
                                case 8:
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

        /*   void InfoEmployee(Employee EmpIX, ref int Age, ref int YearsOfExperience)
         *  
         *   Είσοδος[1] --> [EmpIX]    
         *   Λειτουργία -->                 
         *   Έξοδος[1]  --> [Age]
         *   Έξοδος[1]  --> [YearsOfExperience]
         *  
         *   Παραδοχές υλοποίησης:
         *  
         */
        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) 
        {
            
        }

       /*   int LiveinAthens(Employee[] Empls)
        *  
        *   Είσοδος[1] --> [Empls]     
        *   Λειτουργία -->                 
        *   Έξοδος[1]  --> [numEmpls]   
        *  
        *   Παραδοχές υλοποίησης:
        *  
        */
        public int LiveinAthens(Employee[] Empls) 
        {
            return 0;
        }
    }
}
