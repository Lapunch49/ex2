namespace Calc
{
    public class Reflection
    {
        public void GetDataNow()
        {
            var now = DateTime.Now;

            Type type=now.GetType();
            var props=type.GetProperties();

            foreach(var p in props)
            {
                Console.WriteLine(p.Name + " - "+p.GetValue(now));
            }

        }
    }
}
