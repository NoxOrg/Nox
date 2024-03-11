using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashEmployeeDataSeeder : DataSeederBase<EmployeeDto, Employee>
{
    public CryptocashEmployeeDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashEmployee.json";

    protected override Employee TransformToEntity(EmployeeDto model)
    {
        Employee rtnEmployee = new()
        {
            FirstName = Text.From(model.FirstName!),
            LastName = Text.From(model.LastName!),
            EmailAddress = Email.From(model.EmailAddress!),
            FirstWorkingDay = Date.From(model.FirstWorkingDay!),
            LastWorkingDay = model.LastWorkingDay == null ? null : Date.From(model.LastWorkingDay!.Value),
            Address = StreetAddress.From(model.Address)
        };

        rtnEmployee.EnsureId(model.Id);

        if (model.EmployeePhoneNumbers != null)
        {
            foreach (EmployeePhoneNumberDto currentPhone in model.EmployeePhoneNumbers)
            {
                rtnEmployee.CreateEmployeePhoneNumbers(
                    new()
                    {
                        PhoneNumber = PhoneNumber.From(currentPhone.PhoneNumber),
                        PhoneNumberType = Text.From(currentPhone.PhoneNumberType)
                    }
                );
            }
        }             

        return rtnEmployee;
    }
}