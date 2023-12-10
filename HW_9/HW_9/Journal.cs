using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    internal class Journal
    {
        private string name;
        private int year;
        private string description;
        private string phone;
        private string email;
        private int personalCount;

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Description { get => description; set => description = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int PersonalCount { 
            get => personalCount;
            set 
            {
                personalCount = value;
                if (personalCount < 0)
                    personalCount = 0;
            } 
        }

        public Journal()
        {
            Name = "No Name";
            Year = 0;
            Description = "No Description";
            Phone = "No Phone";
            Email = "No Email";
            PersonalCount = 0;
        }
        public Journal(string name, int year, string description, string phone, string email, int personalCount)
        {
            Name = name;
            Year = year;
            Description = description;
            Phone = phone;
            Email = email;
            PersonalCount = personalCount;
        }
        public Journal(Journal jurnal)
        {
            Name = jurnal.Name;
            Year = jurnal.Year;
            Description = jurnal.Description;
            Phone = jurnal.Phone;
            Email = jurnal.Email;
            PersonalCount = jurnal.PersonalCount;
        }
        
        public static Journal operator +(Journal journal,int count)
        {
            return new Journal() 
            {
                Name = journal.name,
                Year = journal.year,
                Description = journal.description,
                Phone = journal.phone,
                Email = journal.email,
                PersonalCount = journal.PersonalCount + count 
            };
        }
        public static Journal operator -(Journal journal,int count)
        {
            return new Journal() 
            {
                Name = journal.name,
                Year = journal.year,
                Description = journal.description,
                Phone = journal.phone,
                Email = journal.email,
                PersonalCount = journal.PersonalCount - count
            };
        }
        public static bool operator ==(Journal journalLeft, Journal journalRight) 
        {
            return journalLeft.PersonalCount == journalRight.PersonalCount;
        }
        public static bool operator !=(Journal journalLeft, Journal journalRight)
        {
            return journalLeft.PersonalCount != journalRight.PersonalCount;
        }
        public static bool operator <(Journal journalLeft, Journal journalRight)
        {
            return journalLeft.PersonalCount < journalRight.PersonalCount;
        }
        public static bool operator >(Journal journalLeft, Journal journalRight)
        {
            return journalLeft.PersonalCount > journalRight.PersonalCount;
        }
        public override string ToString()
        {
            return $"\nName:              {name}\n" +
                   $"Year:              {year}\n" +
                   $"Description:       {description}\n" +
                   $"Phone:             {phone}\n" +
                   $"Email:             {email}\n" +
                   $"Personal Count:    {personalCount}\n";
        }

        public override bool Equals(object obj)
        {
            return obj is Journal journal &&
                   PersonalCount == journal.PersonalCount;
        }

        public override int GetHashCode()
        {
            return -1645139124 + PersonalCount.GetHashCode();
        }
    }
}
