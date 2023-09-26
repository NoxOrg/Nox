using Cryptocash.Ui.Application.Dto;
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
            if (typeof(T) == typeof(VendingMachineDto))
            {
                return new VendingMachineService();
            }
            else if (typeof(T) == typeof(CustomerDto))
            {
                return new CustomerService();
            }
            else if (typeof(T) == typeof(EmployeeDto))
            {
                return new EmployeeService();
            }

            throw new NotImplementedException();
        }
    }
}