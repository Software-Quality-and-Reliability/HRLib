using System;
using System.Linq;

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


		/*  Implementation Assumptions:
		 *    
		 *  [1] There must be exactly one space character ' '.
		 *  [2] We separate the first name from the last name based on the space character ' ', with the same implementation assumptions for both:
		 *      [2.1] The number of characters must be at least 3.
		 *      [2.2] The number of characters must be at most 15.
		 *      [2.3] It must contain only letters.
		 *      [2.4] The first letter must be uppercase.
		 *      [2.5] All letters, except the first, must be lowercase.
		 *      [2.6] All letters must be Latin.
		 */
		public bool ValidName(string Name) 
		{
			// ----- [1] There must be exactly one space character ' ' -----
			string[] subNames = Name.Split(' ');
			if (subNames.Length != 2)
				return false;

			/**** [2] Separate the first name from the last name using the space character ****/
			string firstName = subNames[0];
			string lastName = subNames[1];

			// ----- [2.1] The number of characters must be at least 3 -----
			if (firstName.Length < 3)
				return false;
			if (lastName.Length < 3)
				return false;

			// ----- [2.2] The number of characters must be at most 15 -----
			if (firstName.Length > 15)
				return false;
			if (lastName.Length > 15)
				return false;

			// ----- [2.3] It must contain only letters -----
			if (!firstName.All(char.IsLetter))
				return false;
			if (!lastName.All(char.IsLetter))
				return false;

			// ----- [2.4] The first letter must be uppercase -----
			if (!char.IsUpper(firstName[0]))
				return false;
			if (!char.IsUpper(lastName[0]))
				return false;

			// ----- [2.5] All letters except the first must be lowercase -----
			if (!firstName.Substring(1).All(char.IsLower))
				return false;
			if (!lastName.Substring(1).All(char.IsLower))
				return false;

			// ----- [2.6] All letters must be Latin -----
			char[] firstNameArray = firstName.ToCharArray();
			char[] lastNameArray = lastName.ToCharArray();
			bool isLatinLetter = true;
			for (int i = 0; i < firstNameArray.Length; i++)
			{
				isLatinLetter = (firstNameArray[i] >= 'A' && firstNameArray[i] <= 'Z') || 
								(firstNameArray[i] >= 'a' && firstNameArray[i] <= 'z');
				if (!isLatinLetter)
					return false;
			}
			for (int j = 0; j < lastNameArray.Length; j++)
			{
				isLatinLetter = (lastNameArray[j] >= 'A' && lastNameArray[j] <= 'Z') || 
								(lastNameArray[j] >= 'a' && lastNameArray[j] <= 'z');
				if (!isLatinLetter)
					return false;
			}

			// ----- Valid full name -----
			return true;                              
		}




		/*  Implementation Assumptions:
		 *  
		 *  [1] The number of characters must be at least 12.
		 *  [2] The number of characters must be at most 24.
		 *  [3] Character composition:
		 *      [3.1] It must contain at least 1 uppercase letter.
		 *      [3.2] It must contain at least 1 lowercase letter.
		 *      [3.3] It must contain at least 1 digit.
		 *      [3.4] It must contain at least 1 special symbol.
		 *  [4] It must not contain any whitespace characters.
		 *  [5] All letters must be Latin characters.
		 *  [6] It must start with an uppercase letter and end with a digit.
		 *      [6.1] It must start with an uppercase letter.
		 *      [6.2] It must end with a digit.
		 */
		public bool ValidPassword(string Password) 
		{
			// [1] The number of characters must be at least 12.
			if (Password.Length < 12)
				return false;
			
			// [2] The number of characters must be at most 24.
			if (Password.Length > 24)
				return false;

			/**** [3] Character composition ****/
			// [3.1] It must contain at least 1 uppercase letter.
			if (!Password.Any(char.IsUpper))
				return false;
			
			// [3.2] It must contain at least 1 lowercase letter.
			if (!Password.Any(char.IsLower))
				return false;
			
			// [3.3] It must contain at least 1 digit.
			if (!Password.Any(char.IsDigit))
				return false;

			// [3.4] It must contain at least 1 special symbol.
			if (!Password.Any(symbol => "!@#$%^&*()_+-=[]{}|;:'\",.<>/?".Contains(symbol)))
				return false;
			
			// [4] It must not contain any whitespace characters.
			if (Password.Any(char.IsWhiteSpace))
				return false;

			// [5] All letters must be Latin characters.
			char[] passwordArray = Password.ToCharArray();
			bool isLatinLetter = true;
			for (int i = 0; i < passwordArray.Length; i++)
			{
				if (char.IsLetter(passwordArray[i]))
				{
					isLatinLetter = (passwordArray[i] >= 'A' && passwordArray[i] <= 'Z') || 
									(passwordArray[i] >= 'a' && passwordArray[i] <= 'z');
					if (!isLatinLetter)
						return false;
				}
			}

			/**** [6] It must start with an uppercase letter and end with a digit ****/
			// [6.1] It must start with an uppercase letter.
			if (!char.IsUpper(Password[0]))
				return false;
			
			// [6.2] It must end with a digit.
			if (!char.IsDigit(Password[Password.Length - 1]))
				return false;
			
			// Valid password
			return true;                              
		}



		/* Implementation Assumptions:
		 *  
		 * [1] The password must be valid according to the implementation assumptions of ValidPassword()
		 */
		public void EncryptPassword(string Password, ref string EncryptedPW) 
		{
			bool isValidPassword = this.ValidPassword(Password);

			// ----- [1] The password must be valid according to the assumptions in ValidPassword() -----
			if (isValidPassword)
			{
				// ----- Valid password -----
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
				// ----- Invalid password -----
				EncryptedPW = null;
			}
		}


		/*  
		 * Implementation Assumptions:
		 *  
		 * [1] It must contain only digits.
		 * [2] The number must be exactly 10 digits.
		 * [3] It must start with "2" if it is a landline.
		 *      [3.1] It must belong to an area code.
		 * [4] It must start with "69" if it is a mobile phone.
		 *      [4.1] It must belong to a mobile phone company.
		 */
		public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone) 
		{
			// ----- [1] It must contain only digits -----
			if (!Phone.All(char.IsDigit))
			{
				// ----- Invalid phone -----
				TypePhone = -1;
				InfoPhone = null;
			}
			else
			{
				// ----- [2] The number must be exactly 10 digits -----
				if (Phone.Length != 10)
				{
					// ----- Invalid phone -----
					TypePhone = -1;
					InfoPhone = null;
				}
				else
				{
					/**** [3] It must start with "2" if it is a landline ****/
					if (Phone.StartsWith("2"))
					{
						// ----- [3.1] It must belong to an area -----
						switch (Phone[1])                                  
						{
							case '1':
								// ----- Valid landline phone in the Metropolitan Area of Athens - Piraeus -----
								TypePhone = 0;
								InfoPhone = "Metropolitan Area of Athens - Piraeus";
								break;
							case '2':
								// ----- Valid landline phone in Eastern Central Greece, Attica, Aegean Islands -----
								TypePhone = 0;
								InfoPhone = "Eastern Central Greece, Attica, Aegean Islands";
								break;
							case '3':
								// ----- Valid landline phone in Central Macedonia -----
								TypePhone = 0;
								InfoPhone = "Central Macedonia";
								break;
							case '4':
								// ----- Valid landline phone in Thessaly, Western Macedonia -----
								TypePhone = 0;
								InfoPhone = "Thessaly, Western Macedonia";
								break;
							case '5':
								// ----- Valid landline phone in Thrace, Eastern Macedonia -----
								TypePhone = 0;
								InfoPhone = "Thrace, Eastern Macedonia";
								break;
							case '6':
								// ----- Valid landline phone in Epirus, Western Central Greece, Western Peloponnese, Ionian Islands -----
								TypePhone = 0;
								InfoPhone = "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands";
								break;
							case '7':
								// ----- Valid landline phone in Eastern Peloponnese, Kythera -----
								TypePhone = 0;
								InfoPhone = "Eastern Peloponnese, Kythera";
								break;
							case '8':
								// ----- Valid landline phone in Crete -----
								TypePhone = 0;
								InfoPhone = "Crete";
								break;
							default:
								// ----- Invalid landline phone -----
								TypePhone = -1;
								InfoPhone = null;
								break;
						}
					}
					else
					{
						/**** [4] It must start with "69" if it is a mobile phone ****/
						if (Phone.StartsWith("69"))
						{
							// ----- [4.1] It must belong to a mobile phone company -----
							switch (Phone[2])
							{
								case '0':
								case '3':
								case '9':
									// ----- Valid mobile phone with Nova -----
									TypePhone = 1;
									InfoPhone = "Nova";
									break;
								case '4':
								case '5':
									// ----- Valid mobile phone with Vodafone -----
									TypePhone = 1;
									InfoPhone = "Vodafone";
									break;
								case '7':
								case '8':
									// ----- Valid mobile phone with Cosmote -----
									TypePhone = 1;
									InfoPhone = "Cosmote";
									break;
								default:
									// ----- Invalid mobile phone -----
									TypePhone = -1;
									InfoPhone = null;
									break;
							}
						}
						else
						{
							// ----- Invalid phone -----
							TypePhone = -1;
							InfoPhone = null; 
						}
					}
				}
			}
		}



		/* 
		 * Implementation Assumptions:
		 * 
		 * [1] The age must be between 18 and 70 years.
		 * [2] The hiring date must be from the birthday plus 18 years up to the current date.
		 */
		public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience) 
		{
			int ageYear, ageMonth, ageDay;
			int xpYear, xpMonth, xpDay;
			int firstYear, lastYear;

			firstYear = DateTime.Today.Year - 70;
			lastYear = DateTime.Today.Year - 18;
			DateTime firstBirthday = new DateTime(firstYear, 01, 01); 
			DateTime lastBirthday = new DateTime(lastYear, 12, 31);   
			DateTime firstHiringDate = EmplX.Birthday.AddYears(18);  
			DateTime lastHiringDate = DateTime.Today;

			// ----- [1] The age must be between 18 and 70 years ----- 
			if (EmplX.Birthday >= firstBirthday && EmplX.Birthday <= lastBirthday)
			{
				ageYear = DateTime.Today.Year - EmplX.Birthday.Year;
				ageMonth = DateTime.Today.Month - EmplX.Birthday.Month;
				ageDay = DateTime.Today.Day - EmplX.Birthday.Day;
				if (ageMonth < 0 || ageDay < 0)     // For example, if Birthday is 2004-01-30 and Today is 2024-01-16,
												  // then 2024-2004 = 20, but month difference is 0 and day difference is -14,
												  // meaning the employee is 20-1 = 19 years old (not yet 20).
					Age = ageYear - 1;
				else                                // Otherwise, e.g., if Birthday is 2004-01-02 and Today is 2024-01-16,
												  // the employee is exactly 20 years and 14 days old.
					Age = ageYear;
			}
			else
			{
				// ----- Invalid birthday -----
				Age = -1;
			}

			// ----- [2] The hiring date must be from the birthday plus 18 years up to the current date -----
			if (EmplX.HiringDate >= firstHiringDate && EmplX.HiringDate <= lastHiringDate)
			{
				xpYear = DateTime.Today.Year - EmplX.HiringDate.Year;
				xpMonth = DateTime.Today.Month - EmplX.HiringDate.Month;
				xpDay = DateTime.Today.Day - EmplX.HiringDate.Day;
				if (xpMonth < 0 || xpDay < 0)           // Similar example as above for service years.
					YearsOfExperience = xpYear - 1;
				else
					YearsOfExperience = xpYear;
			}
			else
			{
				// ----- Invalid hiring date -----
				YearsOfExperience = -1;
			}
		}




		/*  
		 * Implementation Assumptions:
		 *  
		 * [1] The landline must start with "21" for residents of Athens.
		 *     [1.1] The phone information must be "Metropolitan Area of Athens - Piraeus" for residents of Athens.
		 */
		public int LiveinAthens(Employee[] Empls) 
		{
			int countAthens = 0;
		   
			foreach (var emp in Empls)
			{
				int TypePhone = 0;
				string InfoPhone = "";

				// ----- [1] The landline must start with "21" for residents of Athens -----
				this.CheckPhone(emp.HomePhone, ref TypePhone, ref InfoPhone);
				if (TypePhone == 0)
					// ----- [1.1] The phone information must be "Metropolitan Area of Athens - Piraeus" for residents of Athens -----
					if (InfoPhone.Equals("Metropolitan Area of Athens - Piraeus"))
						countAthens++;
			}

			return countAthens;
		}

    }
}
