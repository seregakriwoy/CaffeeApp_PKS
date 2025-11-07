public class Reservation
{
    private static int nextId = 1;

    public int id;
    public string clientName;
    public int clientPhoneNumber;
    public DateTime reservationStart;
    public DateTime reservationEnd;
    public string comment;
    public int tableId;
    
    public static void CreateReservation(List<Reservation> reservations)
    {
        Console.WriteLine("Введите количество создаваемых бронирований (не меньше 1)");
        int numberOfReservations = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < numberOfReservations; i++)
        {
            Console.WriteLine("Введите имя клиента:");
            string clientNameTemporary =  Console.ReadLine();
            
            Console.WriteLine("Введите номер телефона клиента");
            int clientPhoneNumberTemporary = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите время и дату начала брони (в формате день.месяц.год часы:минуты):");
            DateTime reservationStartTemporary = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите время и дату конца брони (в формате день.месяц.год часы:минуты):");
            DateTime reservationEndTemporary = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите комментарий:");
            string commentTemporary = Console.ReadLine();
            
            Console.WriteLine("Введите id забронированного столика:");
            int tableIdTemporary = Convert.ToInt32(Console.ReadLine());
            
            Reservation reservation = new Reservation();
            
            reservation.id = nextId;
            reservation.clientName =  clientNameTemporary;
            reservation.clientPhoneNumber = clientPhoneNumberTemporary;
            reservation.reservationStart = reservationStartTemporary;
            reservation.reservationEnd = reservationEndTemporary;
            reservation.comment =  commentTemporary;
            reservation.tableId = tableIdTemporary;
            
            nextId++;
            
            reservations.Add(reservation);

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

    public static void EditReservation(List<Reservation> reservations)
    {
        Console.WriteLine("Введите id брони");
        int gotId = Convert.ToInt32(Console.ReadLine());
        int index  = reservations.FindIndex(x => x.id == gotId);
        Reservation editedReservation  = reservations[index];
        
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
            
            int selectedOption = Convert.ToInt32(Console.ReadLine());

            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine("Введите новое имя клиента:");
                    string newClientName = Console.ReadLine();
                    editedReservation.clientName = newClientName;
                    Console.WriteLine("Имя клиента успешно изменено!");
                    break;
                
                case 2:
                    Console.WriteLine("Введите новый номер телефона клиента:");
                    int NewClientPhoneNumber = Convert.ToInt32(Console.ReadLine());
                    editedReservation.clientPhoneNumber = NewClientPhoneNumber;
                    Console.WriteLine("Номер телефона клиента успешно изменён!");
                    break;
                
                case 3:
                    Console.WriteLine("Введите новое время начала брони:");
                    DateTime NewReservationStart = DateTime.Parse(Console.ReadLine());
                    editedReservation.reservationStart = NewReservationStart;
                    Console.WriteLine("Время начала брони успешно изменено!");
                    break;
                
                case 4:
                    Console.WriteLine("Введите новое время окончания брони:");
                    DateTime NewReservationEnd = DateTime.Parse(Console.ReadLine());
                    editedReservation.reservationEnd = NewReservationEnd;
                    Console.WriteLine("Время окончания брони успешно изменено!");
                    break;
                
                case 5:
                    bool commentMenu = true;
                    while (commentMenu)
                    {
                        Console.WriteLine("Что вы конкретно хотите сделать?");
                        Console.WriteLine("1) Удалить комментарий");
                        Console.WriteLine("2) Добавить новый комментарий");
                        Console.WriteLine("0) Закончить редактирование комментария");
                        int selectedCommentOption = Convert.ToInt32(Console.ReadLine());

                        switch (selectedCommentOption)
                        {
                            case 1:
                                editedReservation.comment = "";
                                break;

                            case 2:
                                Console.WriteLine("Введите новый комментарий:");
                                string newComment = Console.ReadLine();
                                editedReservation.comment = editedReservation.comment + "\n" + newComment;
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
                
                case 6:
                    Console.WriteLine("Введите новый id столика:");
                    int newTableId = Convert.ToInt32(Console.ReadLine());
                    editedReservation.tableId = newTableId;
                    Console.WriteLine("Id столика успешно изменено!");
                    break;
                
                case 0:
                    return;
                
                default:
                    Console.WriteLine("Такой опции в меню нет, попробуйте снова");
                    break;
            }
        }
    }

    public static void DeleteReservation(List<Reservation> reservations)
    {
        Console.WriteLine("Введите id бронирования");
        int gotId = Convert.ToInt32(Console.ReadLine());
        int removeCount  = reservations.RemoveAll(x => x.id == gotId);
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
        List<Reservation> reservations = new List<Reservation>();
        //Reservation.createReservation(reservations);
        
        //foreach (Reservation reservation in reservations)
        {
            //Console.WriteLine($"ID: {reservation.id}, Клиент: {reservation.clientName}, " +
                              //$"Столик: {reservation.tableId}, " +
                              //$"Время: {reservation.reservationStart:dd.MM.yy HH:mm} - {reservation.reservationEnd:HH:mm} " +
                              //$"Комментарий: {reservation.comment}");
        }
    }
}
