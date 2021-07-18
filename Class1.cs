using System;
//4.	If at least 2 data points are available out of the 48, calculate the floor and the ceiling based on the following:
//a.Ceiling = avg(x) + 1.96 * StDev(x)//
//b.Floor = avg(x) – 1.96 * StDev(x)
//5.If only 1 data point(say x) is available out of the 48, assign a floor and ceiling by giving a bandwidth of +- 75%  i.e.:
//a.Ceiling = data point + 0.75 * x
//b.Floor = data point – 0.75 * x
//6.If no data points are available to run test against, data is considered valid and no standard deviation test is run for that data point
//7.	Compare the current data point being entered against the floor and ceiling
//•	If the data is within the floor and the ceiling, it is considered valid and the test is passed
//	Floor<=current data point <= Ceiling
//•	If the data is outside the floor or the ceiling, the test fails, and is reflected in the open tests
//Current data point < floor or Current data point > ceiling
//variance calculation
// var stdate_usage = from inv in invoices where inv.Month == stDate select inv.Usage;
foreach (var invoice in stdate_usage)
{

    int currentMonth_usage = invoice;
    Console.WriteLine("startdate usage: " + invoice);
    var variant = (sd - currentMonth_usage / sd) * 100;
    Console.WriteLine("Variance : " + variant);

}

public class Class1
{
	public Class1()
	{
        public static double StandardDeviationInvoiceUser(List<Invoice> invoices)
        {
            Console.WriteLine("Invoice Date using Json Convert");
            string InvoiceData = JsonConvert.SerializeObject(invoices, Formatting.Indented);
            // Console.WriteLine(InvoiceData);

            // JArray invoiceDetails = JArray.Parse(InvoiceData);

            var userDate = Console.ReadLine();

            double mean, sum = 0, sd;
            var totalInvoice = 0;
            foreach (var invoice in invoices)
            {
                // Console.WriteLine(invoice.Usage);
                if (userDate == invoice.Month)
                {
                    foreach (var inv in )
                        totalInvoice = totalInvoice + invoice.Usage;
                }
            }

            // mean = sMarks.Average();
            // sum = sMarks.Sum(d => Math.Pow(d - mean, 2));
            //sd = Math.Sqrt((sum) / (sMarks.Count() - 1));
            //mean = invoices.Average();

            mean = totalInvoice / invoices.Count();
            foreach (var invoice in invoices)
            {

                sum = sum + (invoice.Usage - mean);

            }
            sd = Math.Sqrt((sum) / (invoices.Count() - 1));

            return sd;

        }
    }
    List<double> studentMarks = new List<double>() { 80, 88, 65, 69, 74, 92, 46, 99, 49 };
    IEnumerable<int> primeNumbers;
    double standarddeviation = StandardDeviation(studentMarks);
    //  Console.WriteLine("The Standard deviation: " + standarddeviation);
    static double StandardDeviation(List<double> sMarks)
    {
        double mean, sum, sd;
        mean = sMarks.Average();
        sum = sMarks.Sum(d => Math.Pow(d - mean, 2));
        sd = Math.Sqrt((sum) / (sMarks.Count() - 1));
        return sd;

    }
}
//Using AddDays(-1) worked for me until I tried to cross months. When I tried to subtract 2 days from 2017-01-01 the result was 2016-00-30. It could not handle the month change correctly (though the year seemed to be fine).

//I used:  date = Convert.ToDateTime(date).Subtract(TimeSpan.FromDays(2)).ToString("yyyy-mm-dd"); and have no issues.
