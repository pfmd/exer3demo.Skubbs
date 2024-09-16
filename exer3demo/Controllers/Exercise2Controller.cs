using exer3demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace exer3demo.Controllers
{
    public class Exercise2Controller : Controller
    {
        public IActionResult Index()
        {
            int maxNumber = 4000000;

            int prevNum = 1;
            int curNum = 2;
            int nextNum = 0;
            int sum = 0;

            List<int> arr = new List<int>();
            arr.Add(prevNum);

            while (curNum <= maxNumber)
            {
                nextNum = prevNum + curNum;
                prevNum = curNum;
                arr.Add(prevNum);
                if (curNum % 2 == 0)
                {
                    sum += curNum;
                }
                curNum = nextNum;

            }
            
            Exercises result = new Exercises();
            result.ListOfNumbers = (string.Join(",", arr));
            result.FinalAnswer = sum.ToString();
            return View(result);
        }
       
    }






    //Console.WriteLine("The sum of the even-valued terms is: " + result);
}
