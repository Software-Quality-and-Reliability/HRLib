using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.Personnel;


namespace HRLibUnitTest
{
    [TestClass]
    public class UnitTestPersonnel
    {
        [TestMethod]
        public void TestMethodValidName() 
        {
            // Παραδοχές υλοποίησης
            string firstnameAndSurname = " [1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά";
            string moreThan3Chars = " [2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3";
            string lessThan15Chars = " [2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15";
            string onlyLetters = " [2.3] Πρέπει να περιέχει μόνο γράμματα";
            string firstLetterUpper = " [2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο";
            string restLettersLower = " [2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά";
            string onlyLatin = " [2.6] Τα γράμματα πρέπει να είναι όλα λατινικά";
            string validName = " Έγκυρο ονοματεπώνυμο";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,               "Ονοματεπώνυμο",                 εκτιμώμενη τιμή            "Παραδοχή υλοποίησης"}
            //                                                    επιστροφής της ValidName()                      
                { "1",              "Vasilis",                            false,                firstnameAndSurname },
                { "2",              "Theoxaris",                          false,                firstnameAndSurname },
                { "3",              "Om Alhaz",                           false,                moreThan3Chars },
                { "4",              "Vasilis At",                         false,                moreThan3Chars },
                { "5",              "Georgeeeeeeeeeee Theoxaris",         false,                lessThan15Chars },
                { "6",              "Omar Alhaaaaaaaaaaaaz",              false,                lessThan15Chars },
                { "7",              "Vasilis123 Athanasiou",              false,                onlyLetters },
                { "8",              "George Theo_xaris",                  false,                onlyLetters },
                { "9",              "omar Alhaz",                         false,                firstLetterUpper },
                { "10",             "Vasilis athanasiou",                 false,                firstLetterUpper },
                { "11",             "GeorGe Theoxaris",                   false,                restLettersLower },
                { "12",             "Omar AlhAz",                         false,                restLettersLower },
                { "13",             "Βασίλης Athanasiou",                 false,                onlyLatin },
                { "14",             "George Θεοχάρης",                    false,                onlyLatin },
                { "15",             "Omar Alhaz",                          true,                validName },
                { "16",             "Vasilis Athanasiou",                  true,                validName },
                { "17",             "George Theoxaris",                    true,                validName },
                { "NameError_1",    "Vasileios Evangelos Athanasiou",      true,                firstnameAndSurname }
            };

            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    string Name = (string)testcases[i, 1];
                    bool expectedValue = (bool)testcases[i, 2];  // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidName() για την ημερομηνία i
                    bool actualValue = per.ValidName(Name);      // Η τιμή που επιστρέφει η μέθοδος ValidName() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 3],                                        e.Message);
                    //                        id,                      Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodValidPassword() 
        {
            // Παραδοχές υλοποίησης
            string moreThan12Chars = " [1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12";
            string lessThan24Chars = " [2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24";
            string oneUpper = " [3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα";
            string oneLower = " [3.2] Να περιέχει τουλάχιστον 1 πεζό γράμμα";
            string oneDigit = " [3.3] Να περιέχει τουλάχιστον 1 ψηφίο";
            string oneSymbol = " [3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο";
            string noWhitespaces = " [4] Να μην περιέχει χαρακτήρες διαφυγής";
            string onlyLatin = " [5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες";
            string startsWithUpper = " [6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα";
            string endsWithDigit = " [6.2] Πρέπει να τελειώνει με ψηφίο";
            string validPassword = " Έγκυρος κωδικός πρόσβασης";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            { 
            //  { id,                 "Κωδικός",                      εκτιμώμενη τιμή            "Παραδοχή υλοποίησης"}
            //                                                  επιστροφής της ValidPassword()
                { "1",                "Ako2",                             false,                 moreThan12Chars },
                { "2",                "Akkakbfpaoqweh!@#1224hhff1",       false,                 lessThan24Chars },
                { "3",                "!@#$%^&**&^%$#@!",                 false,                 oneUpper + oneLower + oneDigit + oneSymbol},
                { "4",                "george@12#po12" ,                  false,                 oneUpper },
                { "5",                "OMARGYPAS2!@13",                   false,                 oneLower },
                { "6",                "Ath@n@siouvasil",                  false,                 oneDigit },
                { "7",                "George2001theo13",                 false,                 oneSymbol },
                { "8",                "George!@#13 hf" ,                  false,                 noWhitespaces },
                { "9",                "Γιωργοςπαδα@2024",                 false,                 onlyLatin },
                { "10",               "omara#Alhaz2001",                  false,                 startsWithUpper },
                { "11",               "Koaos1^klpoplkjg",                 false,                 endsWithDigit },
                { "12",               "Georgethe8o@#$9",                  true,                  validPassword },
                { "13",               "Vasilisatha8no#6",                 true,                  validPassword },
                { "14",               "Omar_@Alhaz123",                   true,                  validPassword },
                {"PasswordError_2",   "Pao131908~123",                    true,                  oneSymbol }
            };


            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    string Password = (string)testcases[i, 1];
                    bool expectedValue = (bool)testcases[i, 2];     // Η τιμή που περιμένω να επιστρέψει η μέθοδος ValidPassword() για την ημερομηνία i
                    bool actualValue = per.ValidPassword(Password); // Η τιμή που επιστρέφει η μέθοδος ValidPassword() για την ημερομηνία i
                    Assert.AreEqual(expectedValue, actualValue);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 3],                                         e.Message);
                    //                        id,                      Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,  Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }
    

        [TestMethod]
        public void TestMethodEncryptPassword() 
        {
            // Παραδοχές υλοποίησης
            string invalidPassword = " [1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword()";
            string validPassword = " Έγκυρος κωδικός πρόσβασης";
            string validEncryption = " Σωστή κρυπτογράφηση";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,                   "Κωδικός",                         εκτιμώμενη τιμή                  "Παραδοχή υλοποίησης" }
            //                                                       επιστροφής της EncryptPassword()
                { "1",                  "omar24323",                             null,                       invalidPassword },
                { "2",                  "villys12345",                           null,                       invalidPassword },
                { "3",                  "theodosis123",                          null,                       invalidPassword },
                { "4",                  "Om",                                    null,                       invalidPassword },
                { "5",                  "Tigrhs_sdfdssdfsdsdfsdf@16723",         null,                       invalidPassword },
                { "6",                  "Τρούσσας_123",                          null,                       invalidPassword },
                { "7",                  "G.Theo_@13223",                    "L3YmjtdE68778",                 validPassword + validEncryption },
                { "8",                  "Makh$_@18923",                     "Rfpm)dE6=>78",                  validPassword + validEncryption },
                { "9",                  "Tango_@12093",                     "YfsltdE675>8",                  validPassword + validEncryption },
                { "10",                 "Lanaras_@16723",                   "QfsfwfxdE6;<78",                validPassword + validEncryption },
                { "11",                 "George_!12525",                    "Ljtwljd&67:7:",                 validPassword + validEncryption },
                { "12",                 "Krouska_123456",                   "Pwtzxpfd6789:;",                validPassword + validEncryption }
            };


            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    string TestcasePW = (string)testcases[i, 1];       // Ο κωδικός του testcase i 
                    string ExpectedEnPW = (string)testcases[i, 2];     // Ο κρυπτογραφημένος κωδικός του testcase i που περιμένω να επιστρέψει η EncryptPassword() 
                   

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    string ActualEnPW = "";

                    per.EncryptPassword(TestcasePW, ref ActualEnPW);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedEnPW, ActualEnPW);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 3],                                        e.Message);
                    //                       id,                       Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }
        

        [TestMethod]
        public void TestMethodCheckPhone() 
        {
            // Παραδοχές υλοποίησης
            string onlyDigits = " [1] Να περιέχει μόνο αριθμούς";
            string digits10 = " [2] Οι αριθμοί να είναι ακριβώς 10";
            string startsWith2HomePhone = " [3] Να ξεκινάει σε 2 αν πρόκειται για σταθερό";
            string belongsToZone = " [3.1] Να ανήκει σε ζώνη";
            string validHomePhone = "Έγκυρο σταθερό τηλέφωνο";
            string zone1 = " με ζώνη την Μητροπολιτική Περιοχή Αθήνας - Πειραιά";
            string zone2 = " με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου";
            string zone3 = " με ζώνη την Κεντρική Μακεδονία";
            string zone4 = " με ζώνη την Θεσσαλία, Δυτική Μακεδονία";
            string zone5 = " με ζώνη την Θράκη, Ανατολική Μακεδονία";
            string zone6 = " με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησο, Ιόνια Νησιά";
            string zone7 = " με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα";
            string zone8 = " με ζώνη την Κρήτη";
            string startsWith69MobilePhone = " [4] Να ξεκινάει σε 69 αν πρόκειται για κινητό";
            string belongsToMobileDataComp = " [4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας";
            string validMobilePhone = " Έγκυρο κινητό τηλέφωνο";
            string nova = " με εταιρία κινητής τηλεφωνίας τη Nova";
            string cosmote = " με εταιρία κινητής τηλεφωνίας τη Cosmote";
            string vodafone = " με εταιρία κινητής τηλεφωνίας τη Vodafone";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,                       "Αριθμός Τηλεφώνου",        εκτιμώμενη τιμή επιστροφής           εκτιμώμενη τιμή επιστροφής                           "Παραδοχή υλοποίησης" }
             //                                                        της CheckPhone() στην TypePhone     της CheckPhone() στην InfoPhone   
                { "1",                      "210-124567",                        -1,                                 null,                                         onlyDigits },
                { "2",                      "690A49898c",                        -1,                                 null,                                         onlyDigits },
                { "3",                      "22314",                             -1,                                 null,                                         digits10 },
                { "4",                      "69312",                             -1,                                 null,                                         digits10 },
                { "5",                      "23444444444444",                    -1,                                 null,                                         digits10 },
                { "6",                      "69988888888888",                    -1,                                 null,                                         digits10 },
                { "7",                      "140124567",                         -1,                                 null,                                         startsWith2HomePhone },
                { "8",                      "2001010101",                        -1,                                 null,                                         belongsToZone },
                { "9",                      "2101010101",                         0,                "Metropolitan Area of Athens - Piraeus",                       validHomePhone + zone1 },
                { "10",                     "2201010101",                         0,             "Eastern Central Greece, Attica, Aegean Islands",                 validHomePhone + zone2 },
                { "11",                     "2301010101",                         0,                            "Central Macedonia",                               validHomePhone + zone3 },
                { "12",                     "2401010101",                         0,                        "Thessaly, Western Macedonia",                         validHomePhone + zone4 },
                { "13",                     "2501010101",                         0,                            "Thrace, Eastern Macedonia",                       validHomePhone + zone5 },
                { "14",                     "2601010101",                         0,       "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands",  validHomePhone + zone6 },
                { "15",                     "2701010101",                         0,                        "Eastern Peloponnese, Kythera",                        validHomePhone + zone7 },
                { "16",                     "2801010101",                         0,                                "Crete",                                       validHomePhone + zone8 },
                { "17",                     "2901010101",                        -1,                                  null,                                        belongsToZone },
                { "18",                     "5971476763",                        -1,                                  null,                                        startsWith69MobilePhone },
                { "19",                     "6900101010",                         1,                                 "Nova",                                       validMobilePhone + nova },
                { "20",                     "6910101010",                        -1,                                  null,                                        belongsToMobileDataComp },
                { "21",                     "6920101010",                        -1,                                  null,                                        belongsToMobileDataComp },
                { "22",                     "6930101010",                         1,                                 "Nova",                                       validMobilePhone + nova },
                { "23",                     "6940101010",                         1,                                "Vodafone",                                    validMobilePhone + vodafone },
                { "24",                     "6950101010",                         1,                                "Vodafone",                                    validMobilePhone + vodafone },
                { "25",                     "6960101010",                        -1,                                  null,                                        belongsToMobileDataComp },
                { "26",                     "6970101010",                         1,                                "Cosmote",                                     validMobilePhone + cosmote },
                { "27",                     "6980101010",                         1,                                "Cosmote",                                     validMobilePhone + cosmote },
                { "28",                     "6990101010",                         1,                                 "Nova",                                       validMobilePhone + nova },
                { "PhoneError_4",           "210 28 12 967",                      0,                     "Metropolitan Area of Athens - Piraeus",                  onlyDigits }
            };

            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    string TestcasePhone = (string)testcases[i, 1];       // Το τηλέφωνο του testcase i 
                    int ExpectedTypePhone = (int)testcases[i, 2];         // Ο τύπος τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone() 
                    string ExpectedInfoPhone = (string)testcases[i, 3];   // Οι πληροφορίες τηλεφώνου του testcase i που περιμένω να επιστρέψει η CheckPhone()

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    int ActualTypePhone = 100;
                    string ActualInfoPhone = "";

                    per.CheckPhone(TestcasePhone, ref ActualTypePhone, ref ActualInfoPhone);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedTypePhone, ActualTypePhone);
                    Assert.AreEqual(ExpectedInfoPhone, ActualInfoPhone);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 4],                                        e.Message);
                    //                        id,                      Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodInfoEmployee() 
        {
            // Παραδοχές υλοποίησης
            string ageBetween18And70 = " [1] Η ηλικία πρέπει να είναι από 18-70 χρονών";
            string youngerThan18ForHiring = " [2] Η ημερομηνία πρόσληψης πρέπει να είναι από την ημερομηνία γέννησης μεταγενέστερα κατά 18 χρόνια εώς την τρέχουσα ημερομηνία";
            string validAge = " Έγκυρη ηλικία : ";
            string validXpYears = " Έγκυρα χρόνια προϋπηρεσίας : ";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            //                            "Ονοματεπώνυμο",          "Σταθερό Τηλέφωνο",        "Κινητό Τηλέφωνο",         "Ημερομηνία Γέννησης",           "Ημερομηνία Πρόσληψης
            Employee empl1 = new Employee("George Theocharis",         "2102322751",              "6998843565",         new DateTime(2001, 08, 23),      new DateTime(2022, 05, 08));
            Employee empl2 = new Employee("Panagiotis Petropoulos",    "2102887987",              "6975522693",         new DateTime(1985, 04, 03),      new DateTime(2010, 06, 15));
            Employee empl3 = new Employee("Vasilis Athanasiou",        "2201010101",              "6980101010",         new DateTime(1999, 07, 15),      new DateTime(2020, 08, 15));
            Employee empl4 = new Employee("Evangelos Tsimentas",       "2701010101",              "6990101010",         new DateTime(1990, 03, 04),      new DateTime(2015, 06, 03));
            Employee empl5 = new Employee("Omar Alhaz",                "2301010101",              "6970101010",         new DateTime(2000, 02, 01),      new DateTime(2020, 05, 06));
            Employee empl6 = new Employee("Akrivh Krouska",            "2301110101",              "6970101011",         new DateTime(2000, 02, 01),      new DateTime(2020, 05, 06));
            Employee empl7 = new Employee("Pantelhs Tatsis",           "2601010101",              "6975522897",         new DateTime(2001, 01, 08),      new DateTime(2020, 01, 05));
            Employee empl8 = new Employee("Aristotelis Sifakis",       "2601010801",              "6973298777",         new DateTime(2001, 01, 07),      new DateTime(2019, 05, 08));
            Employee empl9 = new Employee("Antonis Kokkinos",          "2102322751",              "6978899987",         new DateTime(2001, 02, 13),      new DateTime(2021, 05, 02));
            Employee empl10 = new Employee("Katerina Vossoy",          "2105042087",              "6987304875",         new DateTime(2001, 07, 11),      new DateTime(2022, 09, 01));
            Employee empl11 = new Employee("Athina Nikolaou",          "2700101010",              "6975588489",         new DateTime(1997, 02, 27),      new DateTime(2023, 05, 22));
            Employee empl12 = new Employee("Aggelikh Panou",           "2401010101",              "6954848497",         new DateTime(1998, 04, 30),      new DateTime(2019, 06, 07));
            Employee empl13 = new Employee("Hlias Konstantinidis",     "2701010102",              "6935660423",         new DateTime(1950, 09, 25),      new DateTime(1970, 04, 08));
            Employee empl14 = new Employee("George Gomez",             "2501010101",              "6990101010",         new DateTime(2007, 12, 01),      new DateTime(2023, 08, 01));
            Employee empl15 = new Employee("George Santos",            "2105000000",              "6988888888",         new DateTime(1990, 04, 29),      new DateTime(2014, 06, 01));
            Employee empl16 = new Employee("Antonis Varvaris",         "2300000000",              "6955555555",         new DateTime(2000, 01, 10),      new DateTime(2018, 05, 06));
            Employee empl17 = new Employee("Xristos Pilarinos",        "2105555555",              "6987451235",         new DateTime(1999, 05, 21),      new DateTime(2019, 06, 30));
            Employee emplfault1 = new Employee("Aggelos Skandalis",    "2501010102",              "6988558589",         new DateTime(1953, 05, 30),      new DateTime(1977, 02, 03));
            Employee emplfault2 = new Employee("Dimitris Siametis",    "2104588989",              "6999999999",         new DateTime(2006, 01, 02),      new DateTime(2024, 01, 01));


            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,                  "Υπάλληλος",            εκτιμώμενη τιμή επιστροφής,          εκτιμώμενη τιμή επιστροφής,                     "Παραδοχή υλοποίησης" }
             //                                                της InfoEmployee() στην Age     της InfoEmployee() στην YearsOfExperience              
                { "1",                   empl1,                          22,                                     1,                                 validAge + "22" + validXpYears + "1" },
                { "2",                   empl2,                          38,                                    13,                                 validAge + "38" + validXpYears + "13" },
                { "3",                   empl3,                          24,                                     3,                                 validAge + "24" + validXpYears + "3" },
                { "4",                   empl4,                          33,                                     8,                                 validAge + "33" + validXpYears + "8" },
                { "5",                   empl5,                          24,                                     3,                                 validAge + "24" + validXpYears + "3" },
                { "6",                   empl6,                          24,                                     3,                                 validAge + "24" + validXpYears + "3" },
                { "7",                   empl7,                          23,                                     4,                                 validAge + "23" + validXpYears + "4" },
                { "8",                   empl8,                          23,                                     4,                                 validAge + "23" + validXpYears + "4" },
                { "9",                   empl9,                          23,                                     2,                                 validAge + "23" + validXpYears + "2" },
                { "10",                  empl10,                         22,                                     1,                                 validAge + "22" + validXpYears + "1" },
                { "11",                  empl11,                         27,                                     0,                                 validAge + "26" + validXpYears + "0" },
                { "12",                  empl12,                         25,                                     4,                                 validAge + "25" + validXpYears + "4" },
                { "13",                  empl13,                         -1,                                    53,                                 ageBetween18And70 },
                { "14",                  empl14,                         -1,                                    -1,                                 youngerThan18ForHiring },
                { "15",                  empl15,                         33,                                     9,                                 validAge + "33" + validXpYears + "9" },
                { "16",                  empl16,                         24,                                     5,                                 validAge + "24" + validXpYears + "5" },
                { "17",                  empl17,                         24,                                     4,                                 validAge + "24" + validXpYears + "4" },
                { "AgeError_5",          emplfault1,                     70,                                    47,                                 ageBetween18And70 },
                { "YearsOfXpError_6",    emplfault2,                     18,                                     0,                                 youngerThan18ForHiring }

            };

            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    Employee TestcaseEmployee = (Employee)testcases[i, 1];       // Ο υπάλληλος του testcase i 
                    int ExpectedAge = (int)testcases[i, 2];                      // Η ηλικία του υπαλλήλου του testcase i που περιμένω να επιστρέψει η InfoEmployee() 
                    int ExpectedYearsOfExperience = (int)testcases[i, 3];        // Τα χρόνια υπηρεσίας του υπαλλήλου του testcase i που περιμένω να επιστρέψει η InfoEmployee()

                    // Δήλωση και αρχικοποίηση ref μεταβλητών μεθόδου
                    int ActualAge = 0;
                    int ActualYearsOfExperience = 100;
                    
                    // Κλήση της InfoEmployee με χρήση ref για να επιστραφούν οι τιμές ActualAge και ActualYearsOfExperience
                    // καθώς και η μορφοποίηση της ημερομηνίας FormattedDate
                    per.InfoEmployee(TestcaseEmployee, ref ActualAge, ref ActualYearsOfExperience);

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedAge, ActualAge);
                    Assert.AreEqual(ExpectedYearsOfExperience, ActualYearsOfExperience);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 4],                                        e.Message);
                    //                       id,                       Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodLiveInAthens() 
        {
            // Παραδοχές υλοποίησης
            string numAthensEmps = " Υπάλληλοι που κατοικούν στην Αθήνα : ";

            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            Employee[] empls1 = new Employee[]
            {
                //           "Ονοματεπώνυμο",     "Σταθερό Τηλέφωνο",  "Κινητό Τηλέφωνο",       "Ημερομηνία Γέννησης",                 "Ημερομηνία Πρόσληψης"
                new Employee("George Theoxaris",    "2202625345",        "6971345456",          new DateTime(2001, 08, 23),           new DateTime(2023, 07, 03)),
                new Employee("Vasilis Athanasiou",  "2302324901",        "6981314145",          new DateTime(2001, 03, 19),           new DateTime(2024, 01, 02)),
                new Employee("Omar Alhaz",          "2401234681",        "6945678789",          new DateTime(2001, 03, 24),           new DateTime(2023, 12, 20))
            };
            Employee[] empls2 = new Employee[]
            {
                //           "Ονοματεπώνυμο",     "Σταθερό Τηλέφωνο",  "Κινητό Τηλέφωνο",       "Ημερομηνία Γέννησης",                 "Ημερομηνία Πρόσληψης
                new Employee("Tom Hanks",           "2102625345",         "6971345456",        new DateTime(1959, 07, 09),           new DateTime(1989, 06, 09)),
                new Employee("Leonardo DiCaprio",   "2102324901",         "6981314145",        new DateTime(1974, 11, 11),           new DateTime(1995, 03, 15)),
                new Employee("Meryl Streep",        "2801234681",         "6945678789",        new DateTime(1955, 06, 22),           new DateTime(1975, 05, 05)),
                new Employee("Robert Downey",       "2102625345",         "6971345456",        new DateTime(1965, 04, 04),           new DateTime(1984, 08, 23)),
                new Employee("Johnny Depp",         "2102324901",         "6981314145",        new DateTime(1963, 06, 09),           new DateTime(1984, 09, 10)),
                new Employee("Angelina Jolie",      "2801234681",         "6945678789",        new DateTime(1975, 06, 04),           new DateTime(1994, 10, 12)),
                new Employee("Chris Hemsworth",     "2102324901",         "6981314145",        new DateTime(1983, 08, 11),           new DateTime(2002, 03, 18)),
            };
            Employee[] empls3 = new Employee[]
            {
                //           "Ονοματεπώνυμο",     "Σταθερό Τηλέφωνο",  "Κινητό Τηλέφωνο",       "Ημερομηνία Γέννησης",                 "Ημερομηνία Πρόσληψης
                new Employee("Brad Pitt",           "2702625345",        "6971345456",        new DateTime(1963, 12, 18),            new DateTime(1987, 05, 20)),
                new Employee("Jennifer Aniston",    "2602324901",        "6981314145",        new DateTime(1969, 02, 11),            new DateTime(1992, 07, 15)),
                new Employee("Tom Cruise",          "2801234681",        "6945678789",        new DateTime(1962, 07, 03),            new DateTime(1981, 10, 10)),
                new Employee("George Clooney",      "2102625345",        "6971345456",        new DateTime(1961, 05, 06),            new DateTime(1982, 09, 22)),
                new Employee("Julia Roberts",       "2102324901",        "6981314145",        new DateTime(1967, 10, 28),            new DateTime(1988, 07, 15)),
                new Employee("Denzel Washington",   "2801234681",        "6945678789",        new DateTime(1954, 12, 28),            new DateTime(1978, 06, 12)),
                new Employee("Scarlett Johansson",  "2102625345",        "6971345456",        new DateTime(1984, 11, 22),            new DateTime(2003, 05, 10)),
                new Employee("Robert Pattinson",    "2801234681",        "6945678789",        new DateTime(1986, 05, 13),            new DateTime(2004, 11, 07))
            };
            Employee[] empls4 = new Employee[]
            {
                //           "Ονοματεπώνυμο",             "Σταθερό Τηλέφωνο",  "Κινητό Τηλέφωνο",             "Ημερομηνία Γέννησης",                  "Ημερομηνία Πρόσληψης"
                new Employee("George Theoxaris",           "2102625345",          "6971345456",             new DateTime(2001, 08, 23),              new DateTime(2023, 07, 03)),
                new Employee("Vasilis Athanasiou",         "2102324901",          "6981314145",             new DateTime(2001, 03, 19),              new DateTime(2024, 01, 02)),
                new Employee("Omar Alhaz",                 "2801234681",          "6945678789",             new DateTime(2001, 03, 24),              new DateTime(2023, 12, 20)),
                new Employee("Christos Troussas",          "2131414567",          "6941296963",             new DateTime(1994, 11, 15),              new DateTime(2024, 01, 01)),
                new Employee("Akrivi Krouska",             "2215678901",          "6901234345",             new DateTime(1998, 05, 19),              new DateTime(2023, 12, 20)),
                new Employee("Ioannis Vogiatzis",          "2801234681",          "6945678789",             new DateTime(2001, 03, 24),              new DateTime(2023, 12, 20)),
                new Employee("George Meletiou",            "2461345679",          "6931345450",             new DateTime(1980, 06, 04),              new DateTime(2023, 11, 03)),
                new Employee("Panagiotis Giannakopoulos",  "2151234510",          "6901234342",             new DateTime(1978, 06, 10),              new DateTime(2024, 02, 20)),
                new Employee("Stavros Fatouros",           "2612828456",          "6951616987",             new DateTime(1990, 01, 24),              new DateTime(2023, 03, 11))
            };
            Employee[] empls5 = new Employee[]
            {
                //           "Ονοματεπώνυμο",            "Σταθερό Τηλέφωνο",    "Κινητό Τηλέφωνο",            "Ημερομηνία Γέννησης",                  "Ημερομηνία Πρόσληψης"
                new Employee("Bartlomiej Dragowski",       "2145678901",          "6905678901",             new DateTime(1997, 08, 19),              new DateTime(2024, 01, 19)),
                new Employee("Tin Jedvaj",                 "2156789012",          "6935678901",             new DateTime(1995, 11, 28),              new DateTime(2023, 07, 14)),
                new Employee("Filip Mladenovic",           "2167890123",          "6995678901",             new DateTime(1991, 08, 15),              new DateTime(2023, 07, 01)),
                new Employee("Giannis Kotsiras",           "2178901234",          "6945678901",             new DateTime(1992, 12, 16),              new DateTime(2021, 07, 01)),
                new Employee("Willian Arao",               "2189012345",          "6955678901",             new DateTime(1992, 03, 12),              new DateTime(2023, 08, 17)),
                new Employee("Carlos Zeca",                "2190123456",          "6975678901",             new DateTime(1988, 08, 21),              new DateTime(2023, 07, 01)),
                new Employee("Bernard Duarte",             "2101234567",          "6985678901",             new DateTime(1992, 09, 08),              new DateTime(2022, 08, 21)),
                new Employee("Anastasios Bakasetas",       "2112345678",          "6935678901",             new DateTime(1993, 06, 28),              new DateTime(2024, 01, 22)),
                new Employee("Adam Cerin",                 "2123456789",          "6945678901",             new DateTime(1999, 07, 16),              new DateTime(2022, 07, 02)),
                new Employee("Sebastian Palacios",         "2134567890",          "6975678901",             new DateTime(1992, 01, 20),              new DateTime(2021, 08, 31)),
                new Employee("Fotis Ioannidis",            "2145678901",          "6985678901",             new DateTime(2000, 01, 10),              new DateTime(2020, 08, 10))
            };
            Employee[] empls6 = new Employee[]
            {
                //           "Ονοματεπώνυμο",             "Σταθερό Τηλέφωνο",    "Κινητό Τηλέφωνο",            "Ημερομηνία Γέννησης",                "Ημερομηνία Πρόσληψης"
                new Employee("George Theoxaris",           "2102625345",          "6971345456",             new DateTime(2001, 08, 23),              new DateTime(2023, 07, 03)),
                new Employee("Vasilis Athanasiou",         "2402324901",          "6981314145",             new DateTime(2001, 03, 19),              new DateTime(2024, 01, 02)),
                new Employee("Omar Alhaz",                 "2501234681",          "6945678789",             new DateTime(2001, 03, 24),              new DateTime(2023, 12, 20)),
                new Employee("Dimitra Papadopoulou",       "2604567890",          "6934567890",             new DateTime(2000, 01, 15),              new DateTime(2023, 06, 20)),
                new Employee("Thanasis Papanikolaou",      "2705678901",          "6945678901",             new DateTime(1999, 11, 28),              new DateTime(2019, 03, 05)),
                new Employee("Eirini Nikolaou",            "2806789012",          "6956789012",             new DateTime(2001, 09, 8),               new DateTime(2023, 08, 12)),
                new Employee("Panagiotis Georgopoulos",    "2107890123",          "6907890123",             new DateTime(2000, 07, 22),              new DateTime(2019, 01, 01))
            };
            Employee[] empls7 = new Employee[]
            {
                //           "Ονοματεπώνυμο",           "Σταθερό Τηλέφωνο",     "Κινητό Τηλέφωνο",             "Ημερομηνία Γέννησης",                  "Ημερομηνία Πρόσληψης"
                new Employee("Despina Vandi",             "2201234567",          "6931234567",               new DateTime(1964, 07, 22),              new DateTime(1998, 10, 01)),
                new Employee("Sakis Rouvas",              "2102345678",          "6942345678",               new DateTime(1972, 01, 05),              new DateTime(1990, 05, 15)),
                new Employee("Kostas Martakis",           "2703456789",          "6953456789",               new DateTime(1974, 09, 14),              new DateTime(2000, 12, 30)),
                new Employee("Elena Paparizou",           "2804567890",          "6944567890",               new DateTime(1982, 01, 31),              new DateTime(2010, 02, 20)),
                new Employee("Giorgos Liagas",            "2605678901",          "6975678901",               new DateTime(1974, 10, 26),              new DateTime(2001, 07, 10))
            };


            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,               "Λίστα Υπαλλήλων",    εκτιμώμενη τιμή επιστροφής,           "Παραδοχή υλοποίησης"}
            //                                                της LiveInAthens()              
                { "1",                  empls1,                        0,                       numAthensEmps + "0/3" },
                { "2",                  empls2,                        5,                       numAthensEmps + "5/7" },
                { "3",                  empls3,                        3,                       numAthensEmps + "3/8" },
                { "4",                  empls4,                        4,                       numAthensEmps + "3/9" },
                { "5",                  empls5,                       11,                       numAthensEmps + "11/11" },
                { "6",                  empls6,                        2,                       numAthensEmps + "3/7" },
                { "7",                  empls7,                        1,                       numAthensEmps + "1/5" }

            };

            // Αρχικοποίηση δείκτη περιπτώσεων ελέγχου (Test Cases)
            int i = 0;
            bool failed = false;

            // Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            // Για κάθε περίπτωση ελέγχου (Test Case), δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    Employee[] TestcaseEmpls = (Employee[])testcases[i, 1];          // Η λίστα των υπαλλήλων του testcase i 
                    int ExpectedAthensHabitants = (int)testcases[i, 2];              // Οι κάτοικοι Αθήνας του testcase i που περιμένω να επιστρέψει η LiveInAthens() 
                    int ActualAthensHabitants = per.LiveinAthens(TestcaseEmpls);     // Οι κάτοικοι Αθήνας του testcase i που επιστρέφει η LiveInAthens() 

                    // Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    // δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    Assert.AreEqual(ExpectedAthensHabitants, ActualAthensHabitants);
                }
                catch (Exception e)
                {
                    // Απέτυχε το Test Case
                    failed = true;
                    // Καταγράφουμε το Test Case που απέτυχε
                    Console.WriteLine("Αποτυχημένο Test Case: {0} \n \t Παραδοχή: {1} \n \t Εξαίρεση: {2} ",
                                             (string)testcases[i, 0], (string)testcases[i, 3],                                        e.Message);
                    //                       id,                       Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }
    }
}
