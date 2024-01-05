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
         *  [1] Να περιέχει γράμματα
         *  [2] Να μην περιέχει οτιδήποτε δεν είναι γράμμα και ο χαρακτήρας ' ' 
         *  [3] Να υπάρχει ο χαρακτήρας διαφυγής κενό ' '
         *  [4] Ο χαρακτήρας κενό ' ' να είναι ανάμεσα στο 1ο και στο τελευταίο γράμμα
         *  [5] Να υπάρχει ο χαρακτήρας κενό ' ' ΑΚΡΙΒΩΣ 1 φορά
         *  [6] Να περιέχει μόνο λατινικά γράμματα
         *  [7] Το πρώτο γράμμα να είναι κεφαλαίο
         *  [8] Το αμέσως επόμενο γράμμα μετά τον χαρακτήρα κενό ' ' να είναι κεφαλαίο
         *  [9] Τα γράμματα από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από τον χαρακτήρα κενό ' ', να είναι μικρά
         *  [10] Τα γράμματα από τον αμέσως επόμενο χαρακτήρα από τον χαρακτήρα κενό ' ' μέχρι τον τελευταίο, να είναι μικρά
         *  [11] Οι χαρακτήρες πριν τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24
         *  [12] Οι χαρακτήρες μετά τον χαρακτήρα κενό ' ' να είναι λιγότεροι ή ίσοι από 24
         */
        public bool ValidName(string Name) /* TIGER */
        {
            int countSpace;                               // Μεταβλητή για τον υπολογισμό των χαρακτήρων κενό ' ' 
            int indexSpace;                               // Η υποτιθέμενη θέση του χαρακτήρα ' '
            bool isLatin;                                 // Μεταβλητή που χρησιμοποιείται για τον έλεγχο "αν το γράμμα είναι λατινικό"
            char[] nameArray = Name.ToCharArray();        // Μετατρέπω το string σε πίνακα χαρακτήρων

            countSpace = 0;                               // Αρχικοποίηση της τιμής υπολογισμού των χαρακτήρων κενό ' '
            indexSpace = -1;                              // Αρχικοποίηση της υποτιθέμενης θέσης του χαρακτήρα κενό ' ' με θέση που είναι εκτός των ορίων του πίνακα 

            for (int i = 0; i < nameArray.Length; i++)    
            {
                if (!char.IsLetter(nameArray[i]))         /* Ο χαρακτήρας i δεν είναι γράμμα */
                {
                    if (nameArray[i] != ' ')              /* Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ δεν είναι ο χαρακτήρας διαφυγής κενό ' ' */
                    {
                        return false;                     // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [2]
                    }
                    else                                  /* Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ είναι ο χαρακτήρας διαφυγής κενό ' ' */
                    {
                        if (i != 0 && i != nameArray.Length - 1)   /* Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ (ο χαρακτήρας i δεν είναι στην 1η θέση του πίνακα ΚΑΙ δεν είναι στην τελευταία) */
                        {
                            countSpace++;                 // Ένδειξη ότι εντοπίστηκε ο χαρακτήρας κενό ' ' που να τηρεί την προδιαγραφή [4]
                            indexSpace = i;               // Αποθήκευση της θέσης του χαρακτήρα κενό ' ' στον πίνακα

                            if (countSpace > 1)           /* Το πλήθος των χαρακτήρων διαφυγής κενό ' ' είναι περισσότερο από 1 */
                                return false;             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [5] 
                        }
                        else                              /* Ο χαρακτήρας i δεν είναι γράμμα ΚΑΙ (ο χαρακτήρας i είναι στην 1η θέση του πίνακα Ή είναι στην τελευταία) */
                        {
                            return false;                 // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [4] 
                        }
                    }
                }
                else                                      /* Ο χαρακτήρας i είναι γράμμα */
                {
                    isLatin = (nameArray[i] >= 'A' && nameArray[i] <= 'Z') || (nameArray[i] >= 'a' && nameArray[i] <= 'z'); // isLatin = Ο χαρακτήρας i βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z]
                    if (!isLatin)                         /* !isLatin = Ο χαρακτήρας i δεν βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z] */
                        return false;                     // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [6] 

                    if (indexSpace != -1)                 /* Η θέση του χαρακτήρα διαφυγής κενό ' ' στον πίνακα έχει βρεθεί */
                    {
                        if (i < indexSpace)               /* Ελέγχουμε τους χαρακτήρες από τον 2ο χαρακτήρα μέχρι τον αμέσως προηγούμενο από το χαρακτήρα κενό ' ' */
                        {
                            if (!char.IsLower(nameArray[i])) /* Ο χαρακτήρας i δεν είναι μικρό */
                                return false;             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [9] 
                        }
                        if (i > indexSpace + 1)           /* Ελέγχουμε τους χαρακτήρες από τον αμέσως επόμενο χαρακτήρα από τον χαρακτήρα κενό ' ', μέχρι τον τελευταίο */
                        {
                            if (!char.IsLower(nameArray[i])) /* Ο χαρακτήρας i δεν είναι μικρό */
                                return false;             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [10] 
                        }
                    }
                    else                                  /* Η θέση του χαρακτήρα διαφυγής κενό ' ' στον πίνακα δεν έχει βρεθεί */
                    {
                        if (i > 0)                        /* Ελέγχουμε τους χαρακτήρες από την αρχή */
                        {
                            if (!char.IsLower(nameArray[i])) /* Ο χαρακτήρας i δεν είναι μικρό */
                                return false;             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [9]
                        }
                    }
                }
            }

            if (indexSpace == -1)                         /* Ένδειξη ότι δεν βρέθηκε ο χαρακτήρας κενό ' ' */
                return false;                             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [3] 

            if (!char.IsUpper(nameArray[0]))              // Το πρώτο γράμμα δεν είναι κεφαλαίο
                return false;                             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [7] */

            if (!char.IsUpper(nameArray[indexSpace + 1])) /* Το αμέσως επόμενο γράμμα μετά τον χαρακτήρα κενό ' ' δεν είναι κεφαλαίο */
                return false;                             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [8] 

            int charsBeforeSpace = (indexSpace - 1) - 0 + 1;                     // Υπολογισμός χαρακτήρων πριν τον χαρακτήρα κενό ' ' (ο τύπος είναι : τελευταία θέση στοιχείου - πρώτη θέση στοιχείου + 1)
            int charsAfterSpace = (nameArray.Length - 1) - (indexSpace - 1) + 1; // Υπολογισμός χαρακτήρων μετά τον χαρακτήρα κενό ' ' (ο τύπος είναι : τελευταία θέση στοιχείου - πρώτη θέση στοιχείου + 1)

            if (charsBeforeSpace >= 24)                   /* Οι χαρακτήρες πριν τον χαρακτήρα κενό ' ' είναι περισσότεροι ή ίσοι από 24 */
                return false;                             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [11] 

            if (charsAfterSpace >= 24)                    /* Οι χαρακτήρες μετά τον χαρακτήρα κενό ' ' είναι περισσότεροι ή ίσοι από 24 */
                return false;                             // Άκυρο Ονοματεπώνυμο - Παραβίαση της προδιαγραφής [12] 

            return true;                                  // Έγκυρο Ονοματεπώνυμο - Το όνομα τηρεί και τις 12 προδιαγραφές 
        } 
        /*
         * προδιαγραφες κωδικου(password)
         * [1] Τουλάχιστον 12 χαρακτήρες
         * [2] Συνδυασμός χαρακτηριών
         * [3] Τα γράμματα να είναι λατινικοί χαρακτήρες
         * [4] Να ξεκινάει από κεφαλαίο γράμμα και να τελειώνει με αριθμό
         */
        public bool ValidPassword(string Password) /* THEO */

        {
            char[] passwordArray = Password.ToCharArray();
            // Έλεγχος για μήκος τουλάχιστον 12 χαρακτήρες
            if (passwordArray.Length <= 12)

            {
                return false;
            }
            if (passwordArray.Length > 24)

            {
                return false;
            }
            // Έλεγχος για κεφαλαία γράμματα
            if (!Password.Any(char.IsUpper))
            {
                return false;
            }
            // Έλεγχος για πεζά γράμματα
            if (!Password.Any(char.IsLower))
            {
                return false;
            }
            // Έλεγχος για αριθμούς
            if (!Password.Any(char.IsDigit))
            {
                return false;
            }
            // Έλεγχος για σύμβολα
            if (!Password.Any(char.IsWhiteSpace))
            {
              return false;
            }
           
            for (int i = 0; i <passwordArray.Length; i++)
            {
               
                bool isLatin = (passwordArray[i] >= 'A' && passwordArray[i] <= 'Z') || (passwordArray[i] >= 'a' && passwordArray[i] <= 'z'); // isLatin = Ο χαρακτήρας i βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z]
                if (!isLatin)                         /* !isLatin = Ο χαρακτήρας i δεν βρίσκεται στο σύνολο [Α,Ζ] Ή στο σύνολο [a,z] */
                    return false;
            }
            
            
            // Έλεγχος ότι ξεκινάει από κεφαλαίο και τελειώνει με αριθμό
            if (!(char.IsUpper(Password[0]) || char.IsDigit(Password[Password.Length - 1])))
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
         *  [1] Να περιέχει αριθμούς
         *  [2] Να μην περιέχει γράμματα ή χαρακτήρες διαφυγής
         *  [3] Οι αριθμοί να είναι το πολύ 10
         *  [4] Να ξεκινάει σε 2 αν πρόκειται για σταθερό
         *  [5] Να ξεκινάει σε 69 αν πρόκειται για κινητό
         */
        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone) /* TIGER */
        {
            bool isHomePhone;                           // Μεταβλητή ελέγχου αν το τηλέφωνο είναι σταθερό
            bool isMobilePhone;                         // Μεταβλητή ελέγχου αν το τηλέφωνο είναι κινητό 
            bool nonDigitPhone;                         // Μεταβλητή ελέγχου αν πρόκειται για τηλέφωνο που δεν περιέχει ψηφία
            bool digitsGreaterThan10;                   // Μεταβλητή ελέγχου αν πρόκειται για τηλέφωνο που περιέχει περισσότερα απο 10 ψηφία
            int zone;                                   // Ζώνη που ανήκει το σταθερό τηλέφωνο
            int mobileNumber;                           // Το ψηφίο του κινητού τηλεφώνου που καθορίζει την εταιρία κινητής τηλεφωνίας
            char[] phoneArray = Phone.ToCharArray();    // Μετατρέπω το τηλέφωνο που έχει δοθεί ως string σε πίνακα χαρακτήρων

            nonDigitPhone = false;                      // Αρχικοποίηση της μεταβλητής ελέγχου αν πρόκειται για τηλέφωνο που δεν περιέχει ψηφία
            digitsGreaterThan10 = false;                // Αρχικοποίηση της μεταβλητής ελέγχου αν πρόκειται για τηλέφωνο που περιέχει περισσότερα από 10 ψηφία

            for (int i = 0; i < phoneArray.Length; i++)
            {
                if (!char.IsDigit(phoneArray[i]))       /* Ο χαρακτήρας i δεν είναι ψηφίο */
                {
                    nonDigitPhone = true;               // Το τηλέφωνο δεν περιέχει μόνο ψηφία
                    break;
                }
            }

            if (phoneArray.Length > 10)                 /* Οι χαρακτήρες του τηλεφώνου είναι περισσότεροι από 10 */
            {
                digitsGreaterThan10 = true;             // Το τηλέφωνο περιέχει περισσότερα από 10 ψηφία
            }

            isHomePhone = Phone.StartsWith("2");        // Αρχικοποίηση της μεταβλητής ελέγχου αν πρόκειται για τηλέφωνο που είναι σταθερό
            isMobilePhone = Phone.StartsWith("69");     // Αρχικοποίηση της μεταβλητής ελέγχου αν πρόκειται για τηλέφωνο που είναι κινητό

            if (!nonDigitPhone && !digitsGreaterThan10 && isHomePhone) /* 
                                                                        * [1] Να περιέχει αριθμούς 
                                                                        * [2] Να μην περιέχει γράμματα ή χαρακτήρες διαφυγής 
                                                                        * [3] Οι αριθμοί να είναι το πολύ 10 
                                                                        * [4] Να ξεκινάει σε 2 αν πρόκειται για σταθερό 
                                                                        */
            {
                TypePhone = 0;                                  // Κωδικός έγκυρου σταθερού τηλεφώνου
                zone = Int32.Parse(Phone.Substring(1, 1));      // Μετατροπή της ζώνης που ανήκει το σταθερό τηλέφωνο σε ακέραιο
                switch (zone)                                   // Έλεγχος της ζώνης που ανήκει το τηλέφωνο για την ανανέωση της πληροφορίας InfoPhone
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
                        InfoPhone = null;
                        break;
                }
            } 
            else                                                             // Μία ή περισσότερες προϋποθέσεις παραβιάζονται [1], [2], [3], [4]
            {
                if (!nonDigitPhone && !digitsGreaterThan10 && isMobilePhone) /* 
                                                                              * [1] Να περιέχει αριθμούς 
                                                                              * [2] Να μην περιέχει γράμματα ή χαρακτήρες διαφυγής 
                                                                              * [3] Οι αριθμοί να είναι το πολύ 10 
                                                                              * [5] Να ξεκινάει σε 69 αν πρόκειται για κινητό 
                                                                              */
                {
                    TypePhone = 1;                                            // Κωδικός έγκυρου κινητού τηλεφώνου
                    mobileNumber = Int32.Parse(Phone.Substring(2, 1));        // Μετατροπή του ψηφίου του κινητού τηλεφώνου που μαρτυρά την εταιρία κινητής τηλεφωνίας σε ακέραιο
                    switch (mobileNumber)                                     // Έλεγχος του ψηφίου του κινητού τηλεφώνου που μαρτυρά την εταιρία κινητής τηλεφωνίας για την ανανέωση της πληροφορίας InfoPhone
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
                            InfoPhone = null;
                            break;
                    }
                }
                else                        // Μία ή περισσότερες προϋποθέσεις παραβιάζονται [1], [2], [3], [5]
                {
                    TypePhone = -1;         // Κωδικός άκυρου τηλεφώνου
                    InfoPhone = null;       // Πληροφορίες άκυρου τηλεφώνου
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