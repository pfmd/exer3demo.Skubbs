using exer3demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace exer3demo.Controllers
{
    public class Exercise1Controller : Controller
    {
        public IActionResult Index()
        {
            int Max = 1000;
            List<int> arr= new List<int>();
            int sum = 0;
            for (int i = 0; i < Max; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum += i;
                    arr.Add(i);
                }
            }
            Exercises result = new Exercises();
            result.ListOfNumbers =(string.Join(",",arr));
            result.FinalAnswer = sum.ToString();
            return View(result);
        }
    

    }
}
