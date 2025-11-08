public class Reservation
{
    private static int _nextId = 1; // счётчик id, благодаря которому все id уникальные 

    private int _id; // id бронирования
    private string ClientName; // имя клиента
    private int ClientPhoneNumber; // номер телефона клиента
    private DateTime ReservationStart; // время начала брони
    private DateTime ReservationEnd; // время окончания брони
    private string Comment; // комментарий
    private int TableId; // id забронированного столика
    
    public static void CreateReservation(List<Reservation> reservations) // метод создания брони
    {
        Console.WriteLine("Введите количество создаваемых бронирований (не меньше 1)");
        int numberOfReservations = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < numberOfReservations; i++) // создаем n броней
        {
            //ввод имени клиента
            bool clientNameAttempt = true;
            string clientNameTemporary = "";
            while (clientNameAttempt)
            {
                Console.WriteLine("Введите имя клиента:");
                clientNameTemporary = Console.ReadLine();
                if (clientNameTemporary == null)
                {
                    Console.WriteLine("Вы должны ввести имя клиента для создания брони! Попробуйте ещё раз");
                }
                else
                {
                    clientNameAttempt = false;
                }
            }
            
            // ввод номера телефона клиента
            bool clientPhoneNumberAttempt = true;
            int clientPhoneNumberTemporary = 0;
            while (clientNameAttempt)
            {
                try
                {
                    Console.WriteLine("Введите номер телефона клиента");
                    clientPhoneNumberTemporary = Convert.ToInt32(Console.ReadLine());
                    clientPhoneNumberAttempt = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите номер телефона в численном формате! Попробуйте ещё раз");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Вы должны ввести номер телефона для создания брони! Попробуйте ещё раз");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Вы ввели слишком большое число! Попробуйте ещё раз");
                }
            }
            
            // ввод времени начала бронирования
            bool reservationStartAttempt = true;
            DateTime reservationStartTemporary = DateTime.MinValue;
            while (reservationStartAttempt)
            {
                try
                {
                    Console.WriteLine("Введите время и дату начала брони (в формате день.месяц.год часы:минуты):");
                    reservationStartTemporary = DateTime.Parse(Console.ReadLine());
                    if (reservationStartTemporary < DateTime.Now)
                    {
                        Console.WriteLine("Это время уже в прошлом, введите другую дату. Попробуйте ещё раз");
                    }
                    else
                    {
                        reservationStartAttempt = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите дату и время в корректном формате!  Попробуйте ещё раз");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Вы должны ввести дату время начала брони для создания брони! Попробуйте ещё раз");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Дата вне диапазона! Попробуйте ещё раз");
                }
            }
            
            // ввод времени окончания брони
            bool reservationEndAttempt = true;
            DateTime reservationEndTemporary = DateTime.MaxValue;
            while (reservationEndAttempt)
            {
                try
                {
                    Console.WriteLine("Введите время и дату конца брони (в формате день.месяц.год часы:минуты):");
                    reservationEndTemporary = DateTime.Parse(Console.ReadLine());
                    if (reservationEndTemporary < reservationStartTemporary)
                    {
                        Console.WriteLine("Время окончания брони должно быть больше времени начала! Попробуйте ещё раз!");
                    }
                    else
                    {
                        reservationEndAttempt = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите дату и время в корректном формате!  Попробуйте ещё раз");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Вы должны ввести дату время начала брони для создания брони! Попробуйте ещё раз");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Дата вне диапазона! Попробуйте ещё раз");
                }
            }
            
            // ввод комментария
            Console.WriteLine("Введите комментарий:");
            string commentTemporary = Console.ReadLine();
            if (commentTemporary == null)
            {
                commentTemporary = "—";
            }
            
            // ввод id стола
            bool tableIdAttempt = true;
            int tableIdTemporary = 0;
            while (tableIdAttempt)
            {
                try
                {
                    //напишите здесь проверку на наличие стола + наличие стола на выбранное время
                    Console.WriteLine("Введите id забронированного столика:");
                    tableIdTemporary = Convert.ToInt32(Console.ReadLine());
                    tableIdAttempt = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите номер стола в численном формате! Попробуйте ещё раз");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Вы должны ввести номер стола для создания брони! Попробуйте ещё раз");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Вы ввели слишком большое число! Попробуйте ещё раз");
                }
            }
            
            // создание объекта класса Reservation с введенными параметрами
            Reservation reservation = new Reservation();
            
            reservation._id = _nextId;
            reservation.ClientName =  clientNameTemporary;
            reservation.ClientPhoneNumber = clientPhoneNumberTemporary;
            reservation.ReservationStart = reservationStartTemporary;
            reservation.ReservationEnd = reservationEndTemporary;
            reservation.Comment =  commentTemporary;
            reservation.TableId = tableIdTemporary;
            
            _nextId++;
            
            // добавление объекта в список всех броней
            reservations.Add(reservation);
            
            // проверка на наличие оставшихся к созданию броней
            if (i != (numberOfReservations - 1))
            {
                Console.WriteLine("Создаем следующую бронь!");
            }
            else
            {
                Console.WriteLine("Все бронирования были созданы!");
            }
        }
    }

    public static void EditReservation(List<Reservation> reservations) // метод изменения брони
    {
        // получение брони, которую мы хотим изменить
        Console.WriteLine("Введите id брони");
        int gotId = Convert.ToInt32(Console.ReadLine());
        int index  = reservations.FindIndex(x => x._id == gotId);
        Reservation editedReservation  = reservations[index];
        
        //меню редактирования брони
        while(true)
        {
            Console.WriteLine("Выберете какой параметр хотите редактировать:");
            Console.WriteLine("1) Имя клиента");
            Console.WriteLine("2) Номер телефона клиента");
            Console.WriteLine("3) Время начала брони");
            Console.WriteLine("4) Время окончания брони");
            Console.WriteLine("5) Комментарий");
            Console.WriteLine("6) Назначенный столик");
            Console.WriteLine("0) Закончить редактирование");

            try
            {
                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    // редактирование имени клиента
                    case 1:
                        bool clientNameAttempt = true;
                        string newClientName = "";
                        while (clientNameAttempt)
                        {
                            Console.WriteLine("Введите новое имя клиента:");
                            newClientName = Console.ReadLine();
                            if (newClientName == null)
                            {
                                Console.WriteLine(
                                    "Вы должны ввести имя клиента для создания брони! Попробуйте ещё раз");
                            }
                            else
                            {
                                editedReservation.ClientName = newClientName;
                                Console.WriteLine("Имя клиента успешно изменено!");
                                clientNameAttempt = false;
                            }
                        }

                        break;
                    
                    // редактирование номера телефона клиента
                    case 2:
                        bool clientPhoneNumberAttempt = true;
                        int NewClientPhoneNumber = 0;
                        while (clientPhoneNumberAttempt)
                        {
                            try
                            {
                                Console.WriteLine("Введите новый номер телефона клиента:");
                                NewClientPhoneNumber = Convert.ToInt32(Console.ReadLine());
                                editedReservation.ClientPhoneNumber = NewClientPhoneNumber;
                                Console.WriteLine("Номер телефона клиента успешно изменён!");
                                clientPhoneNumberAttempt = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(
                                    "Ошибка! Введите номер телефона в численном формате! Попробуйте ещё раз");
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(
                                    "Вы должны ввести номер телефона для создания брони! Попробуйте ещё раз");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Вы ввели слишком большое число! Попробуйте ещё раз");
                            }
                        }

                        break;
                    
                    // редактирование времени начала брони
                    case 3:
                        bool reservationStartAttempt = true;
                        DateTime NewReservationStart = DateTime.MinValue;
                        while (reservationStartAttempt)
                        {
                            try
                            {
                                Console.WriteLine("Введите новое время начала брони:");
                                NewReservationStart = DateTime.Parse(Console.ReadLine());
                                if (NewReservationStart < DateTime.Now)
                                {
                                    Console.WriteLine(
                                        "Это время уже в прошлом, введите другую дату. Попробуйте ещё раз");
                                }
                                else
                                {
                                    editedReservation.ReservationStart = NewReservationStart;
                                    Console.WriteLine("Время начала брони успешно изменено!");
                                    reservationStartAttempt = false;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(
                                    "Ошибка! Введите дату и время в корректном формате!  Попробуйте ещё раз");
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(
                                    "Вы должны ввести дату время начала брони для создания брони! Попробуйте ещё раз");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Дата вне диапазона! Попробуйте ещё раз");
                            }
                        }

                        break;
                    
                    // редактирование времени окончания брони
                    case 4:
                        bool reservationEndAttempt = true;
                        DateTime NewReservationEnd = DateTime.MaxValue;
                        while (reservationEndAttempt)
                        {
                            try
                            {
                                Console.WriteLine("Введите новое время окончания брони:");
                                NewReservationEnd = DateTime.Parse(Console.ReadLine());
                                if (NewReservationEnd < editedReservation.ReservationStart)
                                {
                                    Console.WriteLine(
                                        "Время окончания брони должно быть больше времени начала! Попробуйте ещё раз!");
                                }
                                else
                                {
                                    editedReservation.ReservationEnd = NewReservationEnd;
                                    Console.WriteLine("Время окончания брони успешно изменено!");
                                    reservationEndAttempt = false;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(
                                    "Ошибка! Введите дату и время в корректном формате!  Попробуйте ещё раз");
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(
                                    "Вы должны ввести дату время начала брони для создания брони! Попробуйте ещё раз");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Дата вне диапазона! Попробуйте ещё раз");
                            }
                        }

                        break;
                    
                    // редактирование комментария
                    case 5:
                        bool commentMenu = true;
                        while (commentMenu)
                        {
                            // меню для редактирования комментария
                            Console.WriteLine("Что вы конкретно хотите сделать?");
                            Console.WriteLine("1) Удалить комментарий");
                            Console.WriteLine("2) Добавить новый комментарий");
                            Console.WriteLine("0) Закончить редактирование комментария");
                            int selectedCommentOption = Convert.ToInt32(Console.ReadLine());

                            switch (selectedCommentOption)
                            {
                                case 1:
                                    editedReservation.Comment = "—";
                                    break;

                                case 2:
                                    Console.WriteLine("Введите новый комментарий:");
                                    string newComment = Console.ReadLine();
                                    if (newComment == null || newComment == "" || newComment == " ")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        editedReservation.Comment = editedReservation.Comment + "\n" + newComment;
                                    }

                                    break;

                                case 0:
                                    commentMenu = false;
                                    break;

                                default:
                                    Console.WriteLine("Такой опции в меню нет, попробуйте снова");
                                    break;
                            }
                        }

                        break;
                    
                    // редактирование id забронированного столика
                    case 6:
                        bool tableIdAttempt = true;
                        int newTableId = 0;
                        while (tableIdAttempt)
                        {
                            try
                            {
                                //напишите здесь проверку на наличие стола + наличие стола на выбранное время
                                Console.WriteLine("Введите новый id столика:");
                                newTableId = Convert.ToInt32(Console.ReadLine());
                                editedReservation.TableId = newTableId;
                                Console.WriteLine("Id столика успешно изменено!");
                                tableIdAttempt = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(
                                    "Ошибка! Введите номер стола в численном формате! Попробуйте ещё раз");
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine(
                                    "Вы должны ввести номер стола для создания брони! Попробуйте ещё раз");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Вы ввели слишком большое число! Попробуйте ещё раз");
                            }
                        }

                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Такой опции в меню нет, попробуйте снова");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введите введите номер пункта меню в численном формате! Попробуйте ещё раз");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Вы должны ввести номер пункта меню для взаимодействия с меню! Попробуйте ещё раз");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели слишком большое число! Попробуйте ещё раз");
            }
        }
    }

    public static void DeleteReservation(List<Reservation> reservations) // метод удаления брони
    {
        Console.WriteLine("Введите id бронирования");
        int gotId = Convert.ToInt32(Console.ReadLine());
        int removeCount  = reservations.RemoveAll(x => x._id == gotId); // получение брони по заданному id 
        if (removeCount != 0)
        {
            Console.WriteLine("Выбранное бронирование отменено!");
        }
        else
        {
            Console.WriteLine("Бронирования с таким id не существует!");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Reservation> reservations = new List<Reservation>(); // создание списка бронированний
    }
}
