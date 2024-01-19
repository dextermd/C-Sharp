using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
	delegate void MyDelegate(); // Делегат
	delegate void MyMessageDelegate(string str); // Делегат
	delegate void MyArgDelegate(object sender, EventArgs args); // .NET - совместный делегат
	delegate void MyEventArgDelegate(object sender, MyEventArgs args); // .NET - совместный делегат
	internal class TestEvent
	{
		public event MyDelegate MySummaEvent; // Событие
		public event MyDelegate MyMultEvent; // Событие

		public event MyMessageDelegate MyMessageEvent; // Событие

		public event MyArgDelegate MyArgEvent;

		public event MyEventArgDelegate MyEqualsEvent;

        private int a;
		private int b;

		public int B
		{
			get { return b; }
			set { b = value; }
		}

		public int A
		{
			get { return a; }
			set { a = value; }
		}

		public void OnSumma() // Метод, инициирущий событие
		{
			if(a + b == 10)
			{
				if(MySummaEvent != null)
				{
                    //MyEvent(); // Конструктор
                    // или 
                    MySummaEvent.Invoke();
				}
			}
		}
		public void OnMultMessage(int m)
		{
			if(a * b == m)
			{
                if (MyMessageEvent != null)
				{
					MyMessageEvent($"MESSAGE: {a} * {b} = {m}");
				}
            }
		}
		public void OnSub(int s)
		{
			if(a - b == s)
			{
                if (MyArgEvent != null)
                {
					MyArgEvent(this, EventArgs.Empty);
					//MyArgEvent.Invoke(this, EventArgs.Empty);
                }
            }
		}
		public void OnMult(int m)
		{
            if (a * b == m)
            {
                if (MyMultEvent != null)
                {
                    //MyMultEvent(); // Конструктор
                    // или 
                    MyMultEvent.Invoke();
                }
            }
        }
		public void OnMyEqualsEvent()
		{
			if (a == b)
			{
				MyEventArgs args = new MyEventArgs();
				if(MyEqualsEvent != null)
				{
					args.value1 = a;
					args.value2 = b;
					MyEqualsEvent(this, args);

                }
			}
		}
	}
}
