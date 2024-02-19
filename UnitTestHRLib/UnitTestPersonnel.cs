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
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,               "Ονοματεπώνυμο",          εκτιμώμενη τιμή       "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                             επιστροφής της ValidName                      
                { "1",              "VasilisAthanasiou",          false,             "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { "2",              "George Theo Xaris",          false,             "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { "3",              "Om Alhaz",                   false,             "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { "4",              "Vasilis At",                 false,             "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { "5",              "Georgeeeeeeeeeee Theoxaris", false,             "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { "6",              "Omar Alhaaaaaaaaaaaaz",      false,             "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { "7",              "Vasilis123 Athanasiou",      false,             "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { "8",              "George Theo_xaris",          false,             "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { "9",              "omar Alhaz",                 false,             "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { "10",             "Vasilis athanasiou",         false,             "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { "11",             "GeorGe Theoxaris",           false,             "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { "12",             "Omar AlhAz",                 false,             "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { "13",             "Βασίλης Athanasiou",         false,             "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { "14",             "George Θεοχάρης",            false,             "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { "15",             "Omar Alhaz",                 true,              "Έγκυρο ονοματεπώνυμο" },
                { "16",             "Vasilis Athanasiou",         true,              "Έγκυρο ονοματεπώνυμο" },
                { "17",             "George Theoxaris",           true,              "Έγκυρο ονοματεπώνυμο" },
                
                { "latinFault1",    "Ακριβή Κρούσκα",             true,              "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
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
                                             (string)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id, Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodValidPassword() 
        { 
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            { 
            //  { id,    "Κωδικός",                      εκτιμώμενη τιμή           "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                      επιστροφής της ValidPassword
                { "1",      "Ako2",                             false,                 "[1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12" },
                { "2",      "Akkakbfpaoqweh!@#1224hhff1",       false,                 "[2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24" },
                { "3",      "!@#$%^&**&^%$#@!",                 false,                 "[3] Συνδυασμός χαρακτήρων"},
                { "4",      "george@12#po12" ,                  false,                 "[3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα"},
                { "5",      "OMARGYPAS2!@13",                   false,                 "[3.2] Να περιέχει τουλάχιστον ένα πεζό γράμμα"},
                { "6",      "Ath@n@siouvasil",                  false,                 "[3.3] Να περιέχει τουλάχιστον 1 ψηφίο"},
                { "7",      "George2001theo13",                 false,                 "[3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο"},
                { "8",      "George!@#13 hf" ,                  false,                 "[4] Να μην περιέχει χαρακτήρες διαφυγής"},
                { "9",      "Γιωργοςπαδα@2024",                 false,                 "[5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες"},
                { "10",     "omara#Alhaz2001",                  false,                 "[6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα"},
                { "11",     "Koaos1^klpoplkjg",                 false,                 "[6.2] Πρέπει να τελειώνει με ψηφίο" },
                { "12",     "Georgethe8o@#$9",                  true,                  "Έγκυρος κωδικός πρόσβασης" },
                { "13",     "Vasilisatha8no#6",                 true,                  "Έγκυρος κωδικός πρόσβασης" },
                { "14",     "Omar_@Alhaz123",                   true,                  "Έγκυρος κωδικός πρόσβασης" },
                
                {"Fault1",   "pao131908@123",                   true,                  "o κωδικός πρεπει να ξεκινα με κεφαλαίο"},
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
                                             (string)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }
    

        [TestMethod]
        public void TestMethodEncryptPassword() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,                      "Κωδικός",                      εκτιμώμενη τιμή                  "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                                       επιστροφής της EncryptPassword
                { "1",                  "Omar_@Alhaz123",                  "TrfwdEFqmf678",                  "Λανθασμένη κρυπτογράφηση" },
                { "2",                  "theodosis123",                          null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword" },
                { "3",                  "Tigrhs_@16723",                   "YnlwmxdE6;<78",                  "Λανθασμένη κρυπτογράφηση" },
                { "4",                  "G.Theo_@13223",                   "L3YmjtdE68778",                  "Λανθασμένη κρυπτογράφηση" },
                { "5",                  "Makh$_@18923",                    "Rfpm)dE6=>78",                   "Λανθασμένη κρυπτογράφηση" },
                { "6",                  "Tango_@12093",                    "YfsltdE675>8",                   "Λανθασμένη κρυπτογράφηση" },
                { "7",                  "Lanaras_@16723",                  "QfsfwfxdE6;<78",                 "Λανθασμένη κρυπτογράφηση" },
                { "8",                  "omar24323",                             null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword" },
                { "9",                  "villys12345",                           null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword" },

                { "encryptFault3",      "George_!12525",                   "Ljtwljd&57:7:",                  "Λανθασμένη κρυπτογράφηση" }
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
                                             (string)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }
        

        [TestMethod]
        public void TestMethodCheckPhone() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,                       "Αριθμός Τηλεφώνου",        εκτιμώμενη τιμή επιστροφής           εκτιμώμενη τιμή επιστροφής                              "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                                        της CheckPhone() στην TypePhone     της CheckPhone() στην InfoPhone   
                { "1",                      "210-124567",                        -1,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { "2",                      "690A49898c",                        -1,                                 null,                                         "[1] Να περιέχει μόνο αριθμούς" },
                { "3",                      "22314",                             -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { "4",                      "69312",                             -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { "5",                      "23444444444444",                    -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { "6",                      "69988888888888",                    -1,                                 null,                                         "[2] Οι αριθμοί να είναι ακριβώς 10" },
                { "7",                      "140124567",                         -1,                                 null,                                         "[3] Να ξεκινάει σε 21 αν πρόκειται για σταθερό" },
                { "8",                      "2001010101",                        -1,                                 null,                                         "[3.1] Να ανήκει σε ζώνη" },
                { "9",                      "2101010101",                         0,                "Metropolitan Area of Athens - Piraeus",                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Μητροπολιτική Περιοχή Αθήνας - Πειραιά" },
                { "10",                     "2201010101",                         0,             "Eastern Central Greece, Attica, Aegean Islands",                 "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
                { "11",                     "2301010101",                         0,                            "Central Macedonia",                               "Έγκυρο σταθερό τηλέφωνο με ζώνη την Κεντρική Μακεδονία" },
                { "12",                     "2401010101",                         0,                        "Thessaly, Western Macedonia",                         "Έγκυρο σταθερό τηλέφωνο με ζώνη την Θεσσαλία, Δυτική Μακεδονία" },
                { "13",                     "2501010101",                         0,                            "Thrace, Eastern Macedonia",                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Θράκη, Ανατολική Μακεδονία" },
                { "14",                     "2601010101",                         0,       "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands",  "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ήπειρο, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησο, Ιόνια Νησιά" },
                { "15",                     "2701010101",                         0,                        "Eastern Peloponnese, Kythera",                        "Έγκυρο σταθερό τηλέφωνο με ζώνη την Ανατολική Πελοπόννησο, Κύθηρα" },
                { "16",                     "2801010101",                         0,                                "Crete",                                       "Έγκυρο σταθερό τηλέφωνο με ζώνη την Κρήτη" },
                { "17",                     "2901010101",                        -1,                                  null,                                        "[3.1] Να ανήκει σε ζώνη" },
                { "18",                     "5971476763",                        -1,                                  null,                                        "[4] Να ξεκινάει σε 69 αν πρόκειται για κινητό" },
                { "19",                     "6900101010",                         1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { "20",                     "6910101010",                        -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { "21",                     "6920101010",                        -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { "22",                     "6930101010",                         1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},
                { "23",                     "6940101010",                         1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { "24",                     "6950101010",                         1,                                "Vodafone",                                    "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Vodafone"},
                { "25",                     "6960101010",                        -1,                                  null,                                        "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" },
                { "26",                     "6970101010",                         1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { "27",                     "6980101010",                         1,                                "Cosmote",                                     "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Cosmote"},
                { "28",                     "6990101010",                         1,                                 "Nova",                                       "Έγκυρο κινητό τηλέφωνο με εταιρία κινητής τηλεφωνίας τη Nova"},

                { "onlyDigits4",            "210 28 12 967",                      0,                     "Metropolitan Area of Athens - Piraeus",                  "[1] Να περιέχει μόνο αριθμούς" },
                { "belongsToMobileData5",   "6968765123",                        -1,                                "Cosmote",                                     "[4.1] Να ανήκει σε εταιρία κινητής τηλεφωνίας" }
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
                                             (string)testcases[i, 0], (string)testcases[i, 4], e.Message);
                    //                        id, Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου, Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();
        }

        [TestMethod]
        public void TestMethodInfoEmployee() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            //                            "Ονοματεπώνυμο",       "Σταθερό Τηλέφωνο",   "Κινητό Τηλέφωνο",  "Ημερομηνία Γέννησης",        "Ημερομηνία Πρόσληψης
            Employee empl1 = new Employee("George Theocharis",     "2102322751",        "6998843565",       new DateTime(2001, 03, 01),   new DateTime(2023, 01, 02));
            Employee empl2 = new Employee("Vasilis Athaniasiou",   "2201010101",        "6980101010",       new DateTime(1990, 06, 08),   new DateTime(2015, 02, 05));
            Employee empl3 = new Employee("Evangelos Tsimentas",   "2701010101",        "6990101010",       new DateTime(1959, 02, 15),   new DateTime(1990, 05, 15));
            Employee empl4 = new Employee("Omar Alhaz",            "2301010101",        "6970101010",       new DateTime(1957, 09, 25),   new DateTime(1975, 06,  01));
            
            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,      "Υπάλληλος",            εκτιμώμενη τιμή επιστροφής,          εκτιμώμενη τιμή επιστροφής,                      "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                    της InfoEmployee() στην Age     της InfoEmployee() στην YearsOfExperience              
                { "1",          empl1,                          22,                                    1,                                  "Ο υπάλληλος είναι 22 χρονών και έχει 1  χρόνο υπηρεσίας "},
                { "2",          empl2,                          33,                                    9,                                  "Ο υπάλληλος ειναι 33 χρονών και εχει 9  χρόνια υπηρεσίας"},
                { "3",          empl3,                          65,                                    33,                                 "O υπάλληλος ειναι 65 χρονών και έχει 33 χρόνια υπηρεσίας"},
                { "4",          empl4,                          67,                                    48,                                 "Ο υπάλληλος ειναι 67 χρονών και έχει 48 χρόνια υπηρεσίας"},
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
                                             (string)testcases[i, 0], (string)testcases[i, 4], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }

        [TestMethod]
        public void TestMethodLiveInAthens() 
        {
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            Employee[] empl1 = new Employee[]
            {
                //           "Ονοματεπώνυμο", "Σταθερό Τηλέφωνο", "Κινητό Τηλέφωνο", "Ημερομηνία Γέννησης", "Ημερομηνία Πρόσληψης
                new Employee("George Theoxaris", "2102322751", "6998843565", new DateTime(2001, 03, 01), new DateTime(2023, 01, 02)),
                // new Employee(...)
            };
            Employee[] empl2 = new Employee[]
            {
                //           "Ονοματεπώνυμο", "Σταθερό Τηλέφωνο", "Κινητό Τηλέφωνο", "Ημερομηνία Γέννησης", "Ημερομηνία Πρόσληψης
                new Employee("Vasilis Athanasiou", "2132322751", "6998843565", new DateTime(2001, 03, 01), new DateTime(2023, 01, 02)),
                // new Employee(...)
            };
            Employee[] empl3 = new Employee[]
            {
                //           "Ονοματεπώνυμο", "Σταθερό Τηλέφωνο", "Κινητό Τηλέφωνο", "Ημερομηνία Γέννησης", "Ημερομηνία Πρόσληψης
                new Employee("Omar Alhaz", "2102322751", "6998843565", new DateTime(2001, 03, 01), new DateTime(2023, 01, 02)),
                // new Employee(...)
            };
            /*
            Employee[] empl4 = new Employee[]
            {
                //           "Ονοματεπώνυμο", "Σταθερό Τηλέφωνο", "Κινητό Τηλέφωνο", "Ημερομηνία Γέννησης", "Ημερομηνία Πρόσληψης
                new Employee("...", "...", "...", new DateTime(..., ..., ...), new DateTime(..., ..., ...)),
                // new Employee(...)
            };
            */


            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
             // { id,          "Λίστα Υπαλλήλων",    εκτιμώμενη τιμή επιστροφής,          "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                           της LiveInAthens()              
                { 1,                empl1,                        1,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 1" },
                { 2,                empl2,                        1,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 1" },
                { 3,                empl3,                        1,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 1" },
             // { 4,                empl4,                       ...,                      "..."}
             // ...
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
                                             (int)testcases[i, 0], (string)testcases[i, 3], e.Message);
                    //                       id,                   Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου,         Μήνυμα του exception 
                }
            }

            // Στην περίπτωση που κάποιο Test Case απέτυχε, πέταξε exception.
            if (failed)
                Assert.Fail();

        }

    }
}
