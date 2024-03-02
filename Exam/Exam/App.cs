using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class App
    {
        private List<User> users = new List<User>();

        public void Run()
        {
            int menu;
            LoadUsersFromFile();
            QuizResultList quizResult = new QuizResultList();
            quizResult.LoadResultsFromFile();

            ShowUsers();
            do
            {
                Console.WriteLine("Добро пожаловать в Викторину!");
                Console.WriteLine("1. Войти");
                Console.WriteLine("2. Регистрация");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Login(quizResult);
                        break;
                    case 2:
                        Console.Clear();
                        Register();
                        break;
                    case 0:
                        Console.Clear();
                        SaveUsersToFile();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
                
            } while (menu != 0);
        }

        private void Login(QuizResultList quizResult)
        {
            Console.Write($"Введите Логин: ");
            string username = Console.ReadLine();
            Console.Write($"Введите Пароль: ");
            string password = Console.ReadLine();
            if (Login(username, password))
                ShowMainMenu(username, quizResult);

        }

        private void Register()
        {
            Console.WriteLine("Регистрация нового пользователя.");
            Console.Write($"Введите Логин: ");
            string username = Console.ReadLine();
            Console.Write($"Введите Пароль: ");
            string password = Console.ReadLine();
            Console.Write($"Введите Дату рождения: ");
            string dateBirth = Console.ReadLine();
            Register(username, password, dateBirth);
        }

        private void ShowMainMenu(string username, QuizResultList quizResult)
        {
            int menu = 0;
            do
            {
                Console.WriteLine($"Вы вошли как {username}:");
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Стартовать новую викторину");
                Console.WriteLine("2. Посмотреть результаты своих прошлых викторин");
                Console.WriteLine("3. Посмотреть Топ-20 по конкретной викторине");
                Console.WriteLine("4. Изменить пароль");
                Console.WriteLine("5. Изменить дату рождения");
                Console.WriteLine("0. Выход");

                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        StartNewQuiz(username);
                        break;
                    case 2:
                        Console.Clear();
                        quizResult.DisplayResults(username);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выберите категорию викторины:");
                        Console.WriteLine("1. История");
                        Console.WriteLine("2. География");
                        Console.WriteLine("3. Биология");
                        Console.WriteLine("4. Смешанная");
                        Console.Write("Ваш выбор: ");

                        if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > 4)
                        {
                            Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                            return;
                        }
                        string selectedCategory = string.Empty;
                        switch (categoryChoice)
                        {
                            case 1:
                                selectedCategory = "История";
                                break;
                            case 2:
                                selectedCategory = "География";
                                break;
                            case 3:
                                selectedCategory = "Биология";
                                break;
                            case 4:
                                selectedCategory = "Смешанная";
                                break;
                            default:
                                Console.WriteLine("Произошла ошибка при определении категории.");
                                return;
                        }
                        Console.WriteLine($"Выбрана категория: {selectedCategory}");
                        quizResult.DisplayTopResults(selectedCategory.ToString());
                        break;
                    case 4:
                        Console.Clear();
                        ChangePassword(username);
                        break;
                    case 5:
                        Console.Clear();
                        ChangeDateBirth(username);
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Выход");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }

            } while (menu != 0);
        }

        public void Register(string username, string password, string dateOfBirth)
        {
            if (users.Any(u => u.Username == username))
            {
                Console.Clear();
                Console.WriteLine("Пользователь с таким именем уже существует.");
                return;
            }
            var passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            users.Add(new User { Username = username, Password = passwordHash, DateOfBirth = dateOfBirth });
            Console.Clear();
            Console.WriteLine("Регистрация успешна.");

        }

        public bool Login(string username, string password)
        {
            var passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine("Вход выполнен успешно.");
                return true;
            }
            Console.Clear();
            Console.WriteLine("Неправильное имя пользователя или пароль.");
            return false;
        }

        public void SaveUsersToFile()
        {
            if (File.Exists("dataUsers.txt"))
                File.Delete("dataUsers.txt");

            using (FileStream fs = new FileStream("dataUsers.txt", FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                bw.Write(users.Count);

                foreach (var user in users)
                {
                    bw.Write(user.Username);
                    bw.Write(user.Password);
                    bw.Write(user.DateOfBirth);
                }
                Console.WriteLine("Данные записаны в двоичный файл");
            }
        }

        public void LoadUsersFromFile()
        {
            if (!File.Exists("dataUsers.txt"))
            {
                Console.WriteLine("Файл dataUsers.txt не найден.");
                return;
            }
            users.Clear();

            try
            {
                using (FileStream fs = new FileStream("dataUsers.txt", FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (BinaryReader br = new BinaryReader(bs))
                {
                    int size = br.ReadInt32();
                    users = new List<User>(size);

                    for (int i = 0; i < size; i++)
                    {
                        string username = br.ReadString();
                        string passwordHash = br.ReadString();
                        string dateOfBirth = br.ReadString();

                        User user = new User
                        {
                            Username = username,
                            Password = passwordHash,
                            DateOfBirth = dateOfBirth
                        };

                        users.Add(user);
                    }
                    Console.WriteLine("Данные загружены из файла");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {e.Message}");
            }
        }

        public void ShowUsers() 
        {
            for (int i = 0;i < users.Count;i++)
            {
                Console.WriteLine(users[i]);
            }
        }

        public void ChangePassword(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Введите новый пароль: ");
                string newPassword =Console.ReadLine();
                var passwordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(newPassword));
                user.Password = passwordHash;
                SaveUsersToFile();
            }
        }

        public void ChangeDateBirth(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Введите введите новую дату рождения: ");
                string newDate = Console.ReadLine();
                user.DateOfBirth = newDate;
                SaveUsersToFile();
            }
        }

        public void StartNewQuiz(string username)
        {
            Console.Clear();
            Console.WriteLine("Выберите категорию викторины:");
            Console.WriteLine("1. История");
            Console.WriteLine("2. География");
            Console.WriteLine("3. Биология");
            Console.WriteLine("4. Смешанная");
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > 4)
            {
                Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                return;
            }

            Quiz selectedQuiz = null;

            switch (categoryChoice)
            {
                case 1:
                    selectedQuiz = InitializeHistoryQuiz();
                    break;
                case 2:
                    selectedQuiz = InitializeGeographyQuiz();
                    break;
                case 3:
                    selectedQuiz = InitializeBiologyQuiz();
                    break;
                case 4:
                    selectedQuiz = InitializeMixQuiz();
                    break;
            }

            if (selectedQuiz != null)
            {
                RunQuiz(selectedQuiz, username);
            }
            else
            {
                Console.WriteLine("Произошла ошибка при загрузке викторины.");
            }
        }

        private void RunQuiz(Quiz quiz, string username)
        {
            int score = 0;
            foreach (var question in quiz.Questions)
            {
                Console.Clear();
                Console.WriteLine(question.Text);
                int answerIndex = 1;
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"{answerIndex++}. {answer.Text}");
                }

                Console.Write("Ваш ответ (введите номер ответа): ");
                if (int.TryParse(Console.ReadLine(), out int userAnswer) &&
                    userAnswer > 0 &&
                    userAnswer <= question.Answers.Count &&
                    question.Answers[userAnswer - 1].IsCorrect)
                {
                    Console.WriteLine("Правильный ответ!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Неправильный ответ.");
                }
                Console.WriteLine();
            }
            QuizResult result = new QuizResult(username, quiz.Category.ToString(), score, quiz.Questions.Count);
            QuizResultList resultList = new QuizResultList();
            resultList.AddResult(result);
            resultList.SaveResultsToFile();

            Console.WriteLine($"{username}, ваш результат: {score} из {quiz.Questions.Count}");
        }

        static Quiz InitializeHistoryQuiz()
        {
            return new Quiz
            {
                Title = "Историческая викторина",
                Category = QuizCategory.История,
                Questions = new List<Question>
            {
                new Question
                {
                    Text = "В каком году началась Великая Отечественная война?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "1941", IsCorrect = true },
                        new Answer { Text = "1939", IsCorrect = false },
                        new Answer { Text = "1945", IsCorrect = false },
                        new Answer { Text = "1942", IsCorrect = false }
                    }
                },
                new Question
                {
                    Text = "Кто был первым президентом Российской Федерации?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Владимир Путин", IsCorrect = false },
                        new Answer { Text = "Михаил Горбачёв", IsCorrect = false },
                        new Answer { Text = "Борис Ельцин", IsCorrect = true },
                        new Answer { Text = "Дмитрий Медведев", IsCorrect = false }
                    }
                },
                new Question
                {
                    Text = "В каком году произошла Куликовская битва?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "1380", IsCorrect = true },
                        new Answer { Text = "1410", IsCorrect = false },
                        new Answer { Text = "1242", IsCorrect = false },
                        new Answer { Text = "1480", IsCorrect = false }
                    }
                },
                new Question
                {
                    Text = "Какой город был первой столицей России?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Москва", IsCorrect = false },
                        new Answer { Text = "Санкт-Петербург", IsCorrect = false },
                        new Answer { Text = "Новгород", IsCorrect = false },
                        new Answer { Text = "Киев", IsCorrect = true }
                    }
                },
                new Question
                {
                    Text = "Какой император России отменил крепостное право?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Николай II", IsCorrect = false },
                        new Answer { Text = "Петр I", IsCorrect = false },
                        new Answer { Text = "Александр II", IsCorrect = true },
                        new Answer { Text = "Иван IV", IsCorrect = false }
                    }
                },

                new Question
                {
                    Text = "В каком году была основана Римская империя?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "27 г. до н.э.", IsCorrect = true },
                        new Answer { Text = "753 г. до н.э.", IsCorrect = false },
                        new Answer { Text = "1453 г.", IsCorrect = false },
                        new Answer { Text = "476 г.", IsCorrect = false }
                    }
                },

                new Question
                {
                    Text = "Кто возглавлял Россию во время Великой Октябрьской социалистической революции?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Николай II", IsCorrect = false },
                        new Answer { Text = "Владимир Ленин", IsCorrect = true },
                        new Answer { Text = "Лев Троцкий", IsCorrect = false },
                        new Answer { Text = "Иосиф Сталин", IsCorrect = false }
                    }
                },

                new Question
                {
                    Text = "Какое сражение стало поворотным моментом Второй мировой войны?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Сталинградская битва", IsCorrect = true },
                        new Answer { Text = "Битва за Британию", IsCorrect = false },
                        new Answer { Text = "Операция 'Барбаросса'", IsCorrect = false },
                        new Answer { Text = "Десант в Нормандии", IsCorrect = false }
                    }
                },

                new Question
                {
                    Text = "Как называлась война между Афинами и Спартой в Древней Греции?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Троянская война", IsCorrect = false },
                        new Answer { Text = "Пелопоннесская война", IsCorrect = true },
                        new Answer { Text = "Греко-персидские войны", IsCorrect = false },
                        new Answer { Text = "Война Роз", IsCorrect = false }
                    }
                },

                new Question
                {
                    Text = "Кто из этих деятелей был канцлером Германии во время Второй мировой войны?",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Адольф Гитлер", IsCorrect = true },
                        new Answer { Text = "Уинстон Черчилль", IsCorrect = false },
                        new Answer { Text = "Франклин Рузвельт", IsCorrect = false },
                        new Answer { Text = "Йосип Броз Тито", IsCorrect = false }
                    }
                },

            }

            };
        }
        static Quiz InitializeGeographyQuiz()
        {
            return new Quiz
            {
                Title = "Викторина по географии",
                Category = QuizCategory.История,
                Questions = new List<Question>
            {
                      // Вопрос 1
            new Question
            {
                Text = "Какая река является самой длинной в мире?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Амазонка", IsCorrect = true },
                    new Answer { Text = "Нил", IsCorrect = false },
                    new Answer { Text = "Янцзы", IsCorrect = false },
                    new Answer { Text = "Миссисипи", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Какая страна занимает самую большую площадь в мире?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Канада", IsCorrect = false },
                    new Answer { Text = "США", IsCorrect = false },
                    new Answer { Text = "Китай", IsCorrect = false },
                    new Answer { Text = "Россия", IsCorrect = true }
                }
            },
            new Question
            {
                Text = "Какое море считается самым соленым в мире?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Мертвое море", IsCorrect = true },
                    new Answer { Text = "Красное море", IsCorrect = false },
                    new Answer { Text = "Черное море", IsCorrect = false },
                    new Answer { Text = "Каспийское море", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "В каком городе находится знаменитый Кремль?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Санкт-Петербург", IsCorrect = false },
                    new Answer { Text = "Москва", IsCorrect = true },
                    new Answer { Text = "Новосибирск", IsCorrect = false },
                    new Answer { Text = "Казань", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Какое государство является самым маленьким в мире по населению и площади?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Монако", IsCorrect = false },
                    new Answer { Text = "Лихтенштейн", IsCorrect = false },
                    new Answer { Text = "Сан-Марино", IsCorrect = false },
                    new Answer { Text = "Ватикан", IsCorrect = true }
                }
            },
            new Question
            {
                Text = "Какая страна известна как страна тысячи озер?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Швеция", IsCorrect = false },
                    new Answer { Text = "Финляндия", IsCorrect = true },
                    new Answer { Text = "Норвегия", IsCorrect = false },
                    new Answer { Text = "Канада", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Через какие страны протекает река Дунай?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Германия, Австрия, Венгрия", IsCorrect = false },
                    new Answer { Text = "Германия, Австрия, Словакия, Венгрия, Сербия, Хорватия, Болгария, Румыния, Молдова, Украина", IsCorrect = true },
                    new Answer { Text = "Германия, Чехия, Польша", IsCorrect = false },
                    new Answer { Text = "Австрия, Венгрия, Сербия", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Какой город является столицей Австралии?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Сидней", IsCorrect = false },
                    new Answer { Text = "Мельбурн", IsCorrect = false },
                    new Answer { Text = "Канберра", IsCorrect = true },
                    new Answer { Text = "Перт", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Какие страны имеют выход к Каспийскому морю?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Россия, Казахстан, Иран, Азербайджан, Туркменистан", IsCorrect = true },
                    new Answer { Text = "Россия, Казахстан, Грузия, Азербайджан, Иран", IsCorrect = false },
                    new Answer { Text = "Россия, Украина, Беларусь, Латвия, Литва", IsCorrect = false },
                    new Answer { Text = "Турция, Болгария, Румыния, Украина, Россия", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Где находится самая высокая гора мира, Эверест?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Индия", IsCorrect = false },
                    new Answer { Text = "Непал", IsCorrect = true },
                    new Answer { Text = "Тибет", IsCorrect = false },
                    new Answer { Text = "Китай", IsCorrect = false }
                }
            }
            }

            };
        }
        static Quiz InitializeBiologyQuiz()
        {
            return new Quiz
            {
                Title = "Биологическая викторина",
                Category = QuizCategory.Биология,
                Questions = new List<Question>
    {
        // Вопрос 1
        new Question
        {
            Text = "Какой процесс в клетке отвечает за выработку энергии?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Фотосинтез", IsCorrect = false },
                new Answer { Text = "Гликолиз", IsCorrect = false },
                new Answer { Text = "Дыхание", IsCorrect = true },
                new Answer { Text = "Брожение", IsCorrect = false }
            }
        },
        // Вопрос 2
        new Question
        {
            Text = "Как называется наука о классификации организмов?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Таксономия", IsCorrect = true },
                new Answer { Text = "Анатомия", IsCorrect = false },
                new Answer { Text = "Экология", IsCorrect = false },
                new Answer { Text = "Генетика", IsCorrect = false }
            }
        },
        // Вопрос 3
        new Question
        {
            Text = "Что изучает ботаника?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Животных", IsCorrect = false },
                new Answer { Text = "Растения", IsCorrect = true },
                new Answer { Text = "Микроорганизмы", IsCorrect = false },
                new Answer { Text = "Грибы", IsCorrect = false }
            }
        },
        // Вопрос 4
        new Question
        {
            Text = "Какой орган отвечает за процесс фотосинтеза в растениях?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Корень", IsCorrect = false },
                new Answer { Text = "Стебель", IsCorrect = false },
                new Answer { Text = "Лист", IsCorrect = true },
                new Answer { Text = "Цветок", IsCorrect = false }
            }
        },
        // Вопрос 5
        new Question
        {
            Text = "Как называется процесс образования гамет у организмов?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Митоз", IsCorrect = false },
                new Answer { Text = "Мейоз", IsCorrect = true },
                new Answer { Text = "Фагоцитоз", IsCorrect = false },
                new Answer { Text = "Эндоцитоз", IsCorrect = false }
            }
        },
        // Вопрос 6
        new Question
        {
            Text = "Как называется единица измерения силы света, воспринимаемого растениями?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Люкс", IsCorrect = true },
                new Answer { Text = "Калория", IsCorrect = false },
                new Answer { Text = "Джоуль", IsCorrect = false },
                new Answer { Text = "Паскаль", IsCorrect = false }
            }
        },
        // Вопрос 7
        new Question
        {
            Text = "Какой гормон отвечает за рост и развитие растений?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Ауксин", IsCorrect = true },
                new Answer { Text = "Адреналин", IsCorrect = false },
                new Answer { Text = "Инсулин", IsCorrect = false },
                new Answer { Text = "Тестостерон", IsCorrect = false }
            }
        },
        // Вопрос 8
        new Question
        {
            Text = "Какое вещество является основным пигментом, придающим листьям зеленый цвет?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Хлорофилл", IsCorrect = true },
                new Answer { Text = "Каротин", IsCorrect = false },
                new Answer { Text = "Антоциан", IsCorrect = false },
                new Answer { Text = "Флавоноид", IsCorrect = false }
            }
        },
        // Вопрос 9
        new Question
        {
            Text = "Какое животное является самым крупным на Земле?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Синий кит", IsCorrect = true },
                new Answer { Text = "Африканский слон", IsCorrect = false },
                new Answer { Text = "Белый медведь", IsCorrect = false },
                new Answer { Text = "Жираф", IsCorrect = false }
            }
        },
        // Вопрос 10
        new Question
        {
            Text = "Какое растение считается самым быстрорастущим в мире?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Бамбук", IsCorrect = true },
                new Answer { Text = "Пшеница", IsCorrect = false },
                new Answer { Text = "Кукуруза", IsCorrect = false },
                new Answer { Text = "Сосна", IsCorrect = false }
            }
        }
    }
            };
        }
        static Quiz InitializeMixQuiz()
        {
            return new Quiz
            {
                Title = "Смешанная викторина",
                Category = QuizCategory.Cмешанные,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "Кто из этих фигур был императором России во время Наполеоновских войн?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Петр I", IsCorrect = false },
                            new Answer { Text = "Александр I", IsCorrect = true },
                            new Answer { Text = "Николай I", IsCorrect = false },
                            new Answer { Text = "Иван IV", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Какой континент является самым сухим на Земле?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Азия", IsCorrect = false },
                            new Answer { Text = "Антарктида", IsCorrect = true },
                            new Answer { Text = "Африка", IsCorrect = false },
                            new Answer { Text = "Австралия", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Какие клетки крови отвечают за иммунный ответ?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Эритроциты", IsCorrect = false },
                            new Answer { Text = "Лейкоциты", IsCorrect = true },
                            new Answer { Text = "Тромбоциты", IsCorrect = false },
                            new Answer { Text = "Плазмоциты", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Где была обнаружена армия терракотовых воинов?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "В Индии", IsCorrect = false },
                            new Answer { Text = "В Китае", IsCorrect = true },
                            new Answer { Text = "В Японии", IsCorrect = false },
                            new Answer { Text = "В Монголии", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Какая страна производит больше всего кофе в мире?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Колумбия", IsCorrect = false },
                            new Answer { Text = "Вьетнам", IsCorrect = false },
                            new Answer { Text = "Бразилия", IsCorrect = true },
                            new Answer { Text = "Эфиопия", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Как называется процесс образования новых особей внутри организма матери?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Спорообразование", IsCorrect = false },
                            new Answer { Text = "Бинарное деление", IsCorrect = false },
                            new Answer { Text = "Вивипария", IsCorrect = true },
                            new Answer { Text = "Буддинг", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Какой древний народ построил пирамиды в Центральной Америке?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Майя", IsCorrect = true },
                            new Answer { Text = "Ацтеки", IsCorrect = false },
                            new Answer { Text = "Инки", IsCorrect = false },
                            new Answer { Text = "Ольмеки", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Какое море отделяет Австралию от Новой Зеландии?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Коралловое море", IsCorrect = false },
                            new Answer { Text = "Тасманово море", IsCorrect = true },
                            new Answer { Text = "Южно-Китайское море", IsCorrect = false },
                            new Answer { Text = "Аравийское море", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "Как называется самый крупный мозговой отдел у человека?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Мозжечок", IsCorrect = false },
                            new Answer { Text = "Продолговатый мозг", IsCorrect = false },
                            new Answer { Text = "Большие полушария", IsCorrect = true },
                            new Answer { Text = "Средний мозг", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        Text = "В каком году произошло открытие Америки Христофором Колумбом?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "1492", IsCorrect = true },
                            new Answer { Text = "1502", IsCorrect = false },
                            new Answer { Text = "1488", IsCorrect = false },
                            new Answer { Text = "1512", IsCorrect = false }
                        }
                    }
                }
            };

        }
    }
}
