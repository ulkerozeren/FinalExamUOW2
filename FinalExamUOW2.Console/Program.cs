using FinalExamUOW2.RabbitMQ;
using System;

namespace FinalExamUOW2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new PublisherHelper("userLog", "");
            new ConsumerHelper("userLog");
        }
    }
}
