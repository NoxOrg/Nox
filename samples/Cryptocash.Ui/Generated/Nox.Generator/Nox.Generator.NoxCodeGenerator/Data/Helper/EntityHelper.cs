using Cryptocash.Ui.Domain;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.VendingMachineService;

namespace Cryptocash.Ui.Generated.Data.Helper
{
    /// <summary>
    /// Class to define which Api entity class is being dealt with
    /// </summary>
    public class EntityHelper
    {
        public static IEntityService? GetEntityService<T>()
        {
            if (typeof(T) == typeof(VendingMachine))
            {
                return new VendingMachineService();
            }
            else if (typeof(T) == typeof(Customer))
            {
                return new CustomerService();
            }
            else if (typeof(T) == typeof(Employee))
            {
                return new EmployeeService();
            }

            throw new NotImplementedException();
        }
    }
}