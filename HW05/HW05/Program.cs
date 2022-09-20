using System;
using System.Linq;
using System.Collections.Generic;

namespace HW05
{
    public static class Program
    {
        public static void Main()
        {
            //создаем объект класса Quadcopter и вызываем метод Charge
            Quadcopter quadcopter = new Quadcopter();
            quadcopter.Charge();
            //получаем коллекцию компонентов класса 
            List<string> robots = quadcopter.getComponents();
            foreach (string robot in robots)
            {
                Console.WriteLine(robot);
            }
            //вызываем мeтод getRobotType
            Console.WriteLine(((IRobot)quadcopter).getRobotType());
            Console.WriteLine(((IFlyingRobot)quadcopter).getRobotType());

        }
    }

    public interface IRobot
    {
        public string getInfo();

        public List<string> getComponents();

        public string getRobotType() => "I am a simple robot";
        
    }

    public interface IChargeable
    {
        void Charge();

        string getInfo();
    }

    public interface IFlyingRobot : IRobot
    {
        new public string getRobotType() => "I am a flying robot";
   
    }

    class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };

        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> getComponents() => _components;

        public string getInfo()
        {
            throw new NotImplementedException();
        }
    }
}


