using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using System;
using System.Data.SqlClient;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[]args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=localhost;Initial Catalog=CustomerOrderView;Integrated Security=True");
                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach(CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: FullName: {1} {2} (Id: {3}) - purchased {4} for {5} (Id: {6})",customerOrderDetailModel.CustomerOrderId,
                            customerOrderDetailModel.FirstName,
                            customerOrderDetailModel.LastName,
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.Description,
                            customerOrderDetailModel.Price,
                            customerOrderDetailModel.ItemId);    
                    }
                }
            }  
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}