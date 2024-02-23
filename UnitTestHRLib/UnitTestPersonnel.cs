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
            //  { id,               "Ονοματεπώνυμο",                 εκτιμώμενη τιμή            "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                                    επιστροφής της ValidName()                      
                { "1",              "VasilisAthanasiou",                  false,                "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { "2",              "George Theo Xaris",                  false,                "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" },
                { "3",              "Om Alhaz",                           false,                "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { "4",              "Vasilis At",                         false,                "[2.1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 3" },
                { "5",              "Georgeeeeeeeeeee Theoxaris",         false,                "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { "6",              "Omar Alhaaaaaaaaaaaaz",              false,                "[2.2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 15" },
                { "7",              "Vasilis123 Athanasiou",              false,                "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { "8",              "George Theo_xaris",                  false,                "[2.3] Πρέπει να περιέχει μόνο γράμματα" },
                { "9",              "omar Alhaz",                         false,                "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { "10",             "Vasilis athanasiou",                 false,                "[2.4] Το 1ο γράμμα πρέπει να είναι κεφαλαίο" },
                { "11",             "GeorGe Theoxaris",                   false,                "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { "12",             "Omar AlhAz",                         false,                "[2.5] Τα γράμματα εκτός από το 1ο, πρέπει να είναι πεζά" },
                { "13",             "Βασίλης Athanasiou",                 false,                "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { "14",             "George Θεοχάρης",                    false,                "[2.6] Τα γράμματα πρέπει να είναι όλα λατινικά" },
                { "15",             "Omar Alhaz",                          true,                "Έγκυρο ονοματεπώνυμο" },
                { "16",             "Vasilis Athanasiou",                  true,                "Έγκυρο ονοματεπώνυμο" },
                { "17",             "George Theoxaris",                    true,                "Έγκυρο ονοματεπώνυμο" },
                { "NameError_1",    "Vasileios Evangelos Athanasiou",      true,                "[1] Να υπάρχει ο χαρακτήρας κενό ' ' ακριβώς μία φορά" }
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
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            { 
            //  { id,                 "Κωδικός",                      εκτιμώμενη τιμή            "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                                  επιστροφής της ValidPassword()
                { "1",                "Ako2",                             false,                 "[1] Το πλήθος των χαρακτήρων πρέπει να είναι τουλάχιστον 12" },
                { "2",                "Akkakbfpaoqweh!@#1224hhff1",       false,                 "[2] Το πλήθος των χαρακτήρων πρέπει να είναι το πολύ 24" },
                { "3",                "!@#$%^&**&^%$#@!",                 false,                 "[3] Συνδυασμός χαρακτήρων"},
                { "4",                "george@12#po12" ,                  false,                 "[3.1] Να περιέχει τουλάχιστον 1 κεφαλαίο γράμμα"},
                { "5",                "OMARGYPAS2!@13",                   false,                 "[3.2] Να περιέχει τουλάχιστον ένα πεζό γράμμα"},
                { "6",                "Ath@n@siouvasil",                  false,                 "[3.3] Να περιέχει τουλάχιστον 1 ψηφίο"},
                { "7",                "George2001theo13",                 false,                 "[3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο"},
                { "8",                "George!@#13 hf" ,                  false,                 "[4] Να μην περιέχει χαρακτήρες διαφυγής"},
                { "9",                "Γιωργοςπαδα@2024",                 false,                 "[5] Τα γράμματα πρέπει να είναι λατινικοί χαρακτήρες"},
                { "10",               "omara#Alhaz2001",                  false,                 "[6.1] Πρέπει να ξεκινάει από κεφαλαίο γράμμα"},
                { "11",               "Koaos1^klpoplkjg",                 false,                 "[6.2] Πρέπει να τελειώνει με ψηφίο" },
                { "12",               "Georgethe8o@#$9",                  true,                  "Έγκυρος κωδικός πρόσβασης" },
                { "13",               "Vasilisatha8no#6",                 true,                  "Έγκυρος κωδικός πρόσβασης" },
                { "14",               "Omar_@Alhaz123",                   true,                  "Έγκυρος κωδικός πρόσβασης" },
                {"PasswordError_2",   "Pao131908~123",                    true,                  "[3.4] Να περιέχει τουλάχιστον 1 ειδικό σύμβολο"}
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
            // Δημιουργία ενός αντικειμένου της κλάσης Personnel του HRLib.dll που θέλουμε να τεστάρουμε
            HRLib.Personnel per = new HRLib.Personnel();

            // Δημιουργία Περιπτώσεων Ελέγχου (Test Cases)
            object[,] testcases =
            {
            //  { id,                   "Κωδικός",                         εκτιμώμενη τιμή                  "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                                       επιστροφής της EncryptPassword()
                { "1",                  "Omar_@Alhaz123",                  "TrfwdEFqmf678",                  "Λανθασμένη κρυπτογράφηση" },
                { "2",                  "theodosis123",                          null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword()" },
                { "3",                  "Tigrhs_@16723",                   "YnlwmxdE6;<78",                  "Λανθασμένη κρυπτογράφηση" },
                { "4",                  "G.Theo_@13223",                   "L3YmjtdE68778",                  "Λανθασμένη κρυπτογράφηση" },
                { "5",                  "Makh$_@18923",                    "Rfpm)dE6=>78",                   "Λανθασμένη κρυπτογράφηση" },
                { "6",                  "Tango_@12093",                    "YfsltdE675>8",                   "Λανθασμένη κρυπτογράφηση" },
                { "7",                  "Lanaras_@16723",                  "QfsfwfxdE6;<78",                 "Λανθασμένη κρυπτογράφηση" },
                { "8",                  "omar24323",                             null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword()" },
                { "9",                  "villys12345",                           null,                       "[1] Ο κωδικός πρέπει να είναι έγκυρος σύμφωνα με τις παραδοχές υλοποίησης της ValidPassword()" },
                { "10",                 "George_!12525",                   "Ljtwljd&67:7:",                  "Λανθασμένη κρυπτογράφηση" }
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
                { "PhoneError_3",           "210 28 12 967",                      0,                     "Metropolitan Area of Athens - Piraeus",                  "[1] Να περιέχει μόνο αριθμούς" }
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
             // { id,                  "Υπάλληλος",            εκτιμώμενη τιμή επιστροφής,          εκτιμώμενη τιμή επιστροφής,                     "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
             //                                                της InfoEmployee() στην Age     της InfoEmployee() στην YearsOfExperience              
                { "1",                   empl1,                          22,                                     1,                                 "Ο υπάλληλος είναι 22 χρόνων και έχει 1 χρόνο προϋπηρεσίας"},
                { "2",                   empl2,                          38,                                    13,                                 "Ο υπάλληλος είναι 38 χρόνων και έχει 13 χρόνια προϋπηρεσίας"},
                { "3",                   empl3,                          24,                                     3,                                 "Ο υπάλληλος είναι 24 χρόνων και έχει 3 χρόνια προϋπηρεσίας"},
                { "4",                   empl4,                          33,                                     8,                                 "Ο υπάλληλος είναι 33 χρόνων και έχει 8 χρόνια προϋπηρεσίας"},
                { "5",                   empl5,                          24,                                     3,                                 "Ο υπάλληλος είναι 24 χρόνων και έχει 3 χρόνια προϋπηρεσίας"},
                { "6",                   empl6,                          24,                                     3,                                 "Ο υπάλληλος είναι 24 χρόνων και έχει 3 χρόνια προϋπηρεσίας"},
                { "7",                   empl7,                          23,                                     4,                                 "Ο υπάλληλος είναι 23 χρόνων και έχει 4 χρόνια προϋπηρεσίας"},
                { "8",                   empl8,                          23,                                     4,                                 "Ο υπάλληλος είναι 23 χρόνων και έχει 4 χρόνια προϋπηρεσίας"},
                { "9",                   empl9,                          23,                                     2,                                 "Ο υπάλληλος είναι 23 χρόνων και έχει 2 χρόνια προϋπηρεσίας"},
                { "10",                  empl10,                         22,                                     1,                                 "Ο υπάλληλος είναι 22 χρόνων και έχει 1 χρόνο προϋπηρεσίας"},
                { "11",                  empl11,                         26,                                     0,                                 "Ο υπάλληλος είναι 26 χρόνων και είναι στον 1ο χρόνο προϋπηρεσίας"},
                { "12",                  empl12,                         25,                                     4,                                 "Ο υπάλληλος είναι 25 χρόνων και έχει 4 χρόνια προϋπηρεσίας"},
                { "13",                  empl13,                         -1,                                    53,                                 "[1] Η ηλικία πρέπει να είναι από 18-70 χρονών" },
                { "14",                  empl14,                         -1,                                    -1,                                 "[2] Η ημερομηνία πρόσληψης πρέπει να είναι από την ημερομηνία γέννησης μεταγενέστερα κατά 18 χρόνια εώς την τρέχουσα ημερομηνία" },
                { "15",                  empl15,                         33,                                     9,                                 "Ο υπάλληλος είναι 33 χρόνων και έχει 9 χρόνια προϋπηρεσίας" },
                { "16",                  empl16,                         24,                                     5,                                 "Ο υπάλληλος είναι 24 χρόνων και έχει 5 χρόνια προϋπηρεσίας" },
                { "17",                  empl17,                         24,                                     4,                                 "Ο υπάλληλος είναι 24 χρόνων και έχει 4 χρόνια προϋπηρεσίας" },
                { "AgeError_4",          emplfault1,                     70,                                    47,                                 "[1] Η ηλικία πρέπει να είναι από 18-70 χρονών"},
                { "YearsOfXpError_5",    emplfault2,                     18,                                     0,                                 "[2] Η ημερομηνία πρόσληψης πρέπει να είναι από την ημερομηνία γέννησης μεταγενέστερα κατά 18 χρόνια εώς την τρέχουσα ημερομηνία"}

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
             // { id,               "Λίστα Υπαλλήλων",    εκτιμώμενη τιμή επιστροφής,           "Παραδοχή υλοποίησης που παραβιάζεται ή μήνυμα έγκυρου ελέγχου"}
            //                                                της LiveInAthens()              
                { "1",                  empls1,                        0,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 0" },
                { "2",                  empls2,                        5,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 5" },
                { "3",                  empls3,                        3,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 3" },
                { "4",                  empls4,                        4,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 4" },
                { "5",                  empls5,                       11,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 11" },
                { "6",                  empls6,                        2,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 2" },
                { "7",                  empls7,                        1,                       "Υπάλληλοι που κατοικούν στην Αθήνα : 1" }

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
