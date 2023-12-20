using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
	internal abstract class MusicalInstrument
	{
		private string name;
		private string descR;

		public string DescR
		{
			get { return descR; }
			set { descR = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public MusicalInstrument() :this("No Name", "No Desc"){ }
		public MusicalInstrument(string name, string descR)
		{
			Name = name;
			DescR = descR;
		}

		virtual public void Sound() {}
		virtual public void Show() { Console.WriteLine($"Название: {Name}"); }
		virtual public void Desc() { Console.WriteLine($"Оптсание: {DescR}"); }
		virtual public void History() {}

        public override string ToString()
        {
			return $"Name:		{Name}\n" +
				   $"Description:	{DescR}";
        }

    }
}