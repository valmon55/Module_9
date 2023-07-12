namespace CS_Basic.Task_1
{
    internal class Program
    {
        public class MyException : Exception
        {
            public MyException(string exception_message) : base(exception_message) { }
        }
        static void Main(string[] args)
        {
            Exception[] My_5_exceptions = new Exception[5] { new ArgumentOutOfRangeException(),
                                           new InsufficientMemoryException(),
                                           new AccessViolationException(),
                                           new MyException("Моё исключние"),
                                           new OutOfMemoryException()
                                          };

            foreach (Exception exception in My_5_exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Catch {exception.Message} exception");
                }
                catch (InsufficientMemoryException)
                {
                    Console.WriteLine($"Catch {exception.Message} exception");
                }
                catch (AccessViolationException)
                {
                    Console.WriteLine($"Catch {exception.Message} exception");
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine($"Catch {exception.Message} exception");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Catch {ex.Message} exception");
                }
                finally
                {
                    Console.WriteLine("В блоке Finally определено, что ");
                    Console.WriteLine($"эта ошибка возникла в {exception.StackTrace}");
                }
            }
            Console.ReadKey();
        }
    }
}